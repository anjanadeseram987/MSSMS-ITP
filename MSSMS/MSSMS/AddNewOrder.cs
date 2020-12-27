using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class AddNewOrder : Form
    {
        private OrderItem orderItemToAdd = null;
        private List<Buyer> buyers = new List<Buyer>();
        private List<Brand> brands = new List<Brand>();
        private List<Contract> contracts = new List<Contract>();
        private List<Order> orders = new List<Order>();
        private List<ProductionPlan> productionPlans = new List<ProductionPlan>();
        private List<ShippingDetails> shippingDetails = new List<ShippingDetails>();
        private List<OrderItemContent> orderItemContents = new List<OrderItemContent>();
        private OrderDBHandler orderDBHandler = new OrderDBHandler();
        private BuyerDBHandler buyerDBHandler = new BuyerDBHandler();
        private ShippingDBHandler shippingDBHandler = new ShippingDBHandler();
        private ProductionDBHandler productionDBHandler = new ProductionDBHandler();
        private Boolean isManualNumbeing = false;

        public AddNewOrder()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void AddNewOrder_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            resetForm();
        }

        private void btnAddBuyer_Click(object sender, EventArgs e)
        {
            FormHandler.openChildForm(this.Name, this, "AddOrderItemContents", ChildFormType.ADD, null); 
        }

        private void checkBoxMCNumbering_CheckStateChanged(object sender, EventArgs e)
        {
            if(checkBoxMCNumbering.Checked == true)
            {
                textBoxMCFirst.ReadOnly = false;
                textBoxMCLast.ReadOnly = false;
                textBoxMCQuantity.Text = "";
                textBoxMCFirst.Text = "";
                textBoxMCLast.Text = "";
                isManualNumbeing = false;
            } 
            else
            {
                textBoxMCFirst.ReadOnly = true;
                textBoxMCLast.ReadOnly = true;
                textBoxMCFirst.Text = "";
                textBoxMCLast.Text = "";
                isManualNumbeing = false;
            }
        }

        private void checkBoxNewOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNewOrder.Checked == true)
            {
                comboBoxOrderNumber.SelectedItem = "\0";
                comboBoxOrderNumber.Text = "";
                comboBoxOrderNumber.Enabled = false;
            }
            else
            {
                comboBoxOrderNumber.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Form Resetted.", NotificationStates.SUCCESS);
        }

        public void resetForm()
        {
            comboBoxOrderNumber.Items.Clear();
            comboBoxProductionPlan.Items.Clear();
            comboBoxBuyer.Items.Clear();
            comboBoxBrand.Items.Clear();
            comboBoxContractNumber.Items.Clear();
            comboBoxProductInfo.Items.Clear();
            comboBoxSA.Items.Clear();
            textBoxLocation.Clear();
            textBoxMCQuantity.Clear();
            textBoxMCFirst.Clear();
            textBoxMCLast.Clear();
            textBoxRemarks.Clear();
            checkBoxMCNumbering.Checked = false;
            checkBoxNewOrder.Checked = false;
            comboBoxContractNumber.Items.Add("N/A");
            comboBoxProductionPlan.Items.Add("N/A");
            comboBoxSA.Text = "";
            labelMCInfo.Text = "";
            labelProductInfo.Text = "";
            getComboBoxFillData();
        }

        private void getComboBoxFillData()
        {
            try
            {
                buyers = buyerDBHandler.getAllBuyers();
                brands = buyerDBHandler.getAllBrands();
                orderItemContents = buyerDBHandler.getAllOrderItemContents();
                orders = orderDBHandler.getAllOrders();
                shippingDetails = orderDBHandler.getAllShippingAddressDetails();
                contracts = shippingDBHandler.getAllContracts();
                productionPlans = productionDBHandler.getAllProductionPlans();

                foreach (ProductionPlan productionPlan in productionPlans)
                {
                    if (string.Equals(productionPlan.status, "Pending", StringComparison.InvariantCultureIgnoreCase) && !ValidationHandler.IsBeforeDate(productionPlan.start_date)) {
                        comboBoxProductionPlan.Items.Add(productionPlan.productionplan_id);
                    }
                }

                foreach (Buyer buyer in buyers)
                {
                    comboBoxBuyer.Items.Add(buyer.buyerName);
                }

                foreach (Contract contract in contracts)
                {
                    if (!string.Equals(contract.contract_status, "Completed", StringComparison.InvariantCultureIgnoreCase))
                    {
                        comboBoxContractNumber.Items.Add(contract.contract_no);
                    }
                }

                comboBoxContractNumber.SelectedItem = "N/A";
                comboBoxProductionPlan.SelectedItem = "N/A";

            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
        }

        private void comboBoxBuyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxBrand.Items.Clear();
            comboBoxProductInfo.Items.Clear();
            comboBoxSA.Items.Clear();
            comboBoxOrderNumber.Items.Clear();
            comboBoxSA.Text = "";
            textBoxLocation.Text = "";
            labelProductInfo.Text = "";

            string selectedBuyerName = comboBoxBuyer.Text.ToString();
            string selectedBuyerId = null;

            foreach (Buyer buyer in buyers)
            {
                if(string.Equals(buyer.buyerName, selectedBuyerName, StringComparison.InvariantCultureIgnoreCase))
                {
                    selectedBuyerId = buyer.buyerId;

                    foreach (Brand brand in brands)
                    {
                        if (string.Equals(selectedBuyerId, brand.buyerId, StringComparison.InvariantCultureIgnoreCase))
                        {
                            comboBoxBrand.Items.Add(brand.brandName);
                        }
                    }

                    foreach(ShippingDetails shippingDetail in shippingDetails)
                    {
                        if(string.Equals(shippingDetail.buyerId, selectedBuyerId, StringComparison.InvariantCultureIgnoreCase))
                        {
                            comboBoxSA.Items.Add(shippingDetail.address);
                        }
                    }

                    foreach(Order order in orders)
                    {
                        if(string.Equals(order.buyer.buyerId, selectedBuyerId, StringComparison.InvariantCultureIgnoreCase) && string.Equals(order.order_status, "Pending", StringComparison.InvariantCultureIgnoreCase))
                        {
                            comboBoxOrderNumber.Items.Add(order.order_no);
                        }
                    }

                    break;
                }
            }
        }

        private void comboBoxBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxProductInfo.Items.Clear();
            labelProductInfo.Text = "";

            string selectedBrandName = comboBoxBrand.SelectedItem.ToString();
            string selectedBrandId = null;
            
            foreach(Brand brand in brands)
            {
                if(string.Equals(brand.brandName, selectedBrandName, StringComparison.InvariantCultureIgnoreCase))
                {

                    selectedBrandId = brand.brandId;

                    foreach (OrderItemContent orderItemContent in orderItemContents)
                    {
                        if (string.Equals(orderItemContent.brandId,selectedBrandId, StringComparison.InvariantCultureIgnoreCase))
                        {
                            comboBoxProductInfo.Items.Add(orderItemContent.barcode); //orderItemContent.barcode + " " + orderItemContent.teaproduct.teaProductName + " " + orderItemContent.teaproduct.teaProductflavor + " (" + orderItemContent.teaproduct.teaProductserialNo + ") [" + orderItemContent.teabagWeight + "g X" + orderItemContent.teabagQuantity
                        }
                    }

                    break;
                }
            }
        }

        private void comboBoxProductInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelProductInfo.Text = "";
            labelMCInfo.Text = "";
            string selectedComboBoxProductInfo = comboBoxProductInfo.SelectedItem.ToString();

            foreach (OrderItemContent orderItemContent in orderItemContents)
            {
                string productInfo = orderItemContent.barcode;

                if (string.Equals(productInfo, selectedComboBoxProductInfo, StringComparison.InvariantCultureIgnoreCase))
                {
                    labelProductInfo.Text = "Barcode: " + orderItemContent.barcode + "\nProduct Details: " + orderItemContent.teaproduct.teaProductName + " " + orderItemContent.teaproduct.teaProductflavor + "(" + orderItemContent.teaproduct.teaProductserialNo + ")\nTeabag Details: " + orderItemContent.teabagWeight + "g X" + orderItemContent.teabagQuantity + "Bags Per Inner Carton.\nMC Details: " + orderItemContent.MCMinWeight + " (MC Min Weight) " + orderItemContent.MCMaxWeight + " (MC Max Weight)\nInner Cartons Per MC:\t" + orderItemContent.icQuantity;
                    
                    if(textBoxMCQuantity.Text != "")
                    {
                        try
                        {
                            int typedMCQuantity = int.Parse(textBoxMCQuantity.Text);
                            labelMCInfo.Text = (typedMCQuantity * orderItemContent.icQuantity * orderItemContent.teabagQuantity) + "Tea bags in total.";
                        }
                        catch (Exception)
                        {
                            //do nothing
                        }
                    }

                    break;
                }
            }


        }

        private void comboBoxSA_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSAAddress = comboBoxSA.SelectedItem.ToString();
            textBoxLocation.Text = "";

            foreach(ShippingDetails shippingDetail in shippingDetails)
            {
                if (string.Equals(selectedSAAddress, shippingDetail.address, StringComparison.InvariantCultureIgnoreCase))
                {
                    textBoxLocation.Text = shippingDetail.location;
                    break;
                }
            }
        }

        private void textBoxMCQuantity_TextChanged(object sender, EventArgs e)
        {
            labelMCInfo.Text = "";

            try
            {
                int typedMCQuantity = int.Parse(textBoxMCQuantity.Text);
                int innerCartonQuantity = 0;


                if (comboBoxProductInfo.Text.ToString() != null || comboBoxProductInfo.Text.ToString() != "")
                {
                    string selectedProductInfo = comboBoxProductInfo.Text.ToString();

                    foreach(OrderItemContent orderItemContent in orderItemContents)
                    {
                        if(string.Equals(selectedProductInfo, orderItemContent.barcode, StringComparison.InvariantCultureIgnoreCase))
                        {
                            labelMCInfo.Text = (typedMCQuantity * orderItemContent.icQuantity * orderItemContent.teabagQuantity) + " Tea Bags in Total.";
                            break;
                        }
                    }
                }

                if (checkBoxMCNumbering.Checked == false)
                {
                    textBoxMCFirst.Text = "1";
                    textBoxMCLast.Text = typedMCQuantity.ToString();
                }
            } 
            catch (Exception)
            {
                //do nothig 
            }
        }

        private void textBoxMCFirst_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxMCNumbering.Checked == true)
            {
                if (textBoxMCLast.Text == "" || textBoxMCFirst.Text == "")
                {
                    textBoxMCQuantity.Text = "";
                }
                else
                {
                    if (ValidationHandler.IsValidNumber(textBoxMCFirst.Text) || ValidationHandler.IsValidNumber(textBoxMCLast.Text))
                    {
                        int newMCQuantity = int.Parse(textBoxMCLast.Text) - int.Parse(textBoxMCFirst.Text);
                        if (newMCQuantity > 0)
                        {
                            textBoxMCQuantity.Text = newMCQuantity + "";
                        }
                    }
                    else
                    {
                        textBoxMCQuantity.Text = "";
                    }
                }
            }
        }

        private void textBoxMCLast_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxMCNumbering.Checked == true)
            {
                if (textBoxMCLast.Text == "" || textBoxMCFirst.Text == "")
                {
                    textBoxMCQuantity.Text = "";
                }
                else
                {
                    if (ValidationHandler.IsValidNumber(textBoxMCFirst.Text) || ValidationHandler.IsValidNumber(textBoxMCLast.Text))
                    {
                        int newMCQuantity = int.Parse(textBoxMCLast.Text) - int.Parse(textBoxMCFirst.Text);
                        if (newMCQuantity > 0)
                        {
                            textBoxMCQuantity.Text = newMCQuantity + "";
                        }
                    }
                    else
                    {
                        textBoxMCQuantity.Text = "";
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            String selectedBuyerId = null;
            String selectedBrandId = null;
            String selectedProductBarcode = null;
            String selectedShippingAddressId = null;
            String selectedShippingAddress = null;
            String selectedOrderNumber = null;
            String selectedContractNumber = null;
            String selectedProductionPlanId = null;
            int selectedMCStart = 0;
            int selectedMCEnd = 0;
            Boolean isNewOrder = false;
            Boolean isNewAddress = false;
            Boolean isManualMCNumbering = false;


            //front-end validation
            if (string.IsNullOrWhiteSpace(comboBoxBuyer.Text) || string.IsNullOrEmpty(comboBoxBuyer.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Buyer name cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxBrand.Text) || string.IsNullOrEmpty(comboBoxBrand.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Brand name cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxProductInfo.Text) || string.IsNullOrEmpty(comboBoxProductInfo.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Productn Details cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxSA.Text) || string.IsNullOrEmpty(comboBoxSA.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Shipping Details cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxLocation.Text) || string.IsNullOrEmpty(textBoxLocation.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Location cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (checkBoxNewOrder.Checked == false)
            {
                if (string.IsNullOrWhiteSpace(comboBoxOrderNumber.Text) || string.IsNullOrEmpty(comboBoxOrderNumber.Text))
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "An Order Number should be provided.", NotificationStates.WARNING);
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(comboBoxContractNumber.Text) || string.IsNullOrEmpty(comboBoxContractNumber.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Contract Number cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (checkBoxMCNumbering.Checked == false)
            {
                if (string.IsNullOrWhiteSpace(textBoxMCQuantity.Text) || string.IsNullOrEmpty(textBoxMCQuantity.Text))
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Master Carton Quantity cannot be empty.", NotificationStates.WARNING);
                    return;
                }

                if (ValidationHandler.IsValidNumber(textBoxMCQuantity.Text) == false)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid MC Quantity.", NotificationStates.WARNING);
                    return;
                }
            } 
            else
            {
                if (string.IsNullOrWhiteSpace(textBoxMCFirst.Text) || string.IsNullOrEmpty(textBoxMCFirst.Text))
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "First MC number should be clearly mentioned.", NotificationStates.WARNING);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxMCLast.Text) || string.IsNullOrEmpty(textBoxMCLast.Text))
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Last MC number should be clearly mentioned.", NotificationStates.WARNING);
                    return;
                }

                if (ValidationHandler.IsValidNumber(textBoxMCFirst.Text) == false)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid MC Starting number.", NotificationStates.WARNING);
                    return;
                }

                if (ValidationHandler.IsValidNumber(textBoxMCLast.Text) == false)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid MC Ending number.", NotificationStates.WARNING);
                    return;
                }

                if (int.Parse(textBoxMCLast.Text) - int.Parse(textBoxMCFirst.Text) <= 0)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "There should be at least one Mastor Carton. Please check the range and try again.", NotificationStates.WARNING);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxMCQuantity.Text) || string.IsNullOrEmpty(textBoxMCQuantity.Text))
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Master Carton Quantity cannot be empty.", NotificationStates.WARNING);
                    return;
                }

                if (ValidationHandler.IsValidNumber(textBoxMCQuantity.Text) == false)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid MC Quantity.", NotificationStates.WARNING);
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(comboBoxProductionPlan.Text) || string.IsNullOrEmpty(comboBoxProductionPlan.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Production Plan ID cannot be empty.", NotificationStates.WARNING);
                return;
            }

            foreach (Buyer buyer in buyers)
            {
                if (string.Equals(buyer.buyerName, comboBoxBuyer.SelectedItem.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    selectedBuyerId = buyer.buyerId;
                    break;
                }
            }

            foreach (Brand brand in brands)
            {
                if (string.Equals(brand.brandName, comboBoxBrand.SelectedItem.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    selectedBrandId = brand.brandId;
                    break;
                }
            }

            foreach (OrderItemContent orderItemContent in orderItemContents)
            {
                if (string.Equals(orderItemContent.barcode, comboBoxProductInfo.SelectedItem.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    selectedProductBarcode = orderItemContent.barcode;
                    break;
                }
            }

            foreach (ShippingDetails shippingDetail in shippingDetails)
            {
                if (string.Equals(shippingDetail.address, comboBoxSA.Text, StringComparison.InvariantCultureIgnoreCase))
                {
                    selectedShippingAddressId = shippingDetail.addressId;
                    isNewAddress = false;
                    break;
                }
                else
                {
                    isNewAddress = true;
                }
            }

            if (checkBoxNewOrder.Checked == true)
            {
                isNewOrder = true;
            }
            else
            {
                isNewOrder = false;

                foreach (Order order in orders)
                {
                    if(string.Equals(order.order_no, comboBoxOrderNumber.SelectedItem.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedOrderNumber = order.order_no;
                    }

                }
            }

            foreach (Contract contract in contracts)
            {
                if (string.Equals(contract.contract_no, comboBoxContractNumber.SelectedItem.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    selectedContractNumber = contract.contract_no;
                    break;
                }
            }

            foreach (ProductionPlan productionPlan in productionPlans)
            {
                if (string.Equals(productionPlan.productionplan_id, comboBoxProductionPlan.SelectedItem.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    selectedProductionPlanId = productionPlan.productionplan_id;
                    break;
                }
            }

            if(checkBoxMCNumbering.Checked == true)
            {
                isManualMCNumbering = true;
                selectedMCStart = int.Parse(textBoxMCFirst.Text);
                selectedMCEnd = int.Parse(textBoxMCLast.Text);
            } 
            else
            {
                isManualMCNumbering = false;
                selectedMCStart = 1;
                selectedMCEnd = int.Parse(textBoxMCQuantity.Text);
            }


            try
            {
                if (isNewOrder == true && isNewAddress == true)
                {
                    ShippingDetails newShippingDetails = new ShippingDetails("",textBoxLocation.Text, comboBoxSA.Text, selectedBuyerId);
                    orderItemToAdd = new OrderItem("", "", selectedContractNumber, selectedBuyerId, selectedBrandId, selectedProductBarcode, newShippingDetails, int.Parse(textBoxMCQuantity.Text), selectedMCStart, selectedMCEnd, selectedProductionPlanId, textBoxRemarks.Text);


                    if (orderDBHandler.addOrderItemWithNewOrderAndAddress(orderItemToAdd) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Order placed successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }

                }
                else if (isNewOrder == true && isNewAddress == false)
                {
                    ShippingDetails oldShippingDetails = new ShippingDetails(selectedShippingAddressId, "", "", selectedBuyerId);
                     orderItemToAdd = new OrderItem("", "", selectedContractNumber, selectedBuyerId, selectedBrandId, selectedProductBarcode, oldShippingDetails, int.Parse(textBoxMCQuantity.Text), selectedMCStart, selectedMCEnd, selectedProductionPlanId, textBoxRemarks.Text);


                     if (orderDBHandler.addOrderItemWithNewOrder(orderItemToAdd) == true)
                     {
                         NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Order placed successfully.", NotificationStates.SUCCESS);
                         resetForm();
                     }
                }
                else if (isNewOrder == false && isNewAddress == true)
                {
                    ShippingDetails newShippingDetails = new ShippingDetails(textBoxLocation.Text, comboBoxSA.Text);
                    orderItemToAdd = new OrderItem("", selectedOrderNumber, selectedContractNumber, selectedBuyerId, selectedBrandId, selectedProductBarcode, newShippingDetails, int.Parse(textBoxMCQuantity.Text), selectedMCStart, selectedMCEnd, selectedProductionPlanId, textBoxRemarks.Text);


                    if (orderDBHandler.addOrderItemWithNewAddress(orderItemToAdd) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Order placed successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }
                else if (isNewOrder == false && isNewAddress == false)
                {
                    ShippingDetails oldShippingDetails = new ShippingDetails(selectedShippingAddressId, "", "", selectedBuyerId);
                    orderItemToAdd = new OrderItem("", selectedOrderNumber, selectedContractNumber, selectedBuyerId, selectedBrandId, selectedProductBarcode, oldShippingDetails, int.Parse(textBoxMCQuantity.Text), selectedMCStart, selectedMCEnd, selectedProductionPlanId, textBoxRemarks.Text);


                    if (orderDBHandler.addOrderItem(orderItemToAdd) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Order placed successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }
                else
                {
                    //do nothing
                }

            }
            catch (MSSMUIException ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                return;
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                return;
            }


        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            comboBoxBuyer.SelectedIndex = 0;
            comboBoxBrand.SelectedIndex = 0;
            comboBoxProductInfo.SelectedIndex = 0;
            comboBoxSA.Text = "3/23 Drive, Miami, USA";
            textBoxLocation.Text = "USA";
            comboBoxOrderNumber.SelectedIndex = 0;
            comboBoxProductionPlan.SelectedItem = "N/A";
            comboBoxContractNumber.SelectedItem = "N/A";
            textBoxMCQuantity.Text = "2152";
            textBoxRemarks.Text = "Use Best Quality Teabag materials. No Scratched MCs allowed.";
            checkBoxNewOrder.Checked = true;
        }
    }
}
