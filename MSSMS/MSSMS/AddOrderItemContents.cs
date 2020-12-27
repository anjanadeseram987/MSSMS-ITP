using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Properties;
using MSSMS.Utilities;
using System;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class AddOrderItemContents : Form
    {
        OrderItemContent orderItemContentToAdd = null;
        OrderItemContent orderItemContentToUpdate = null;
        OrderItemContentComboBoxData comboBoxData = null;
        BuyerDBHandler buyerDBHandler = new BuyerDBHandler();
        TeaProduct teaProduct = null;
        TeabagMaterial teabagMaterial = null;
        ChildFormType childType;
        bool isValidBrandName = false;

        public AddOrderItemContents()
        {
            InitializeComponent();
            this.childType = FormHandler.childFormType;

            if (this.childType == ChildFormType.UPDATE)
            {
                orderItemContentToUpdate = (OrderItemContent)FormHandler.newObject;
                this.Text = "Update Order Content";
                this.btnSave.Text = "Update Content";
                this.lblTitle.Text = "UPDATE ORDER CONTENT";
                this.lblDescription.Text = "Please Fill the required fields in order to update the selected order content.";
            }

            resetForm();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void AddNewBuyer_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void resetForm()
        {
            comboBoxBuyer.Items.Clear();
            comboBoxBrand.Items.Clear();
            comboBoxTeabagType.Items.Clear();
            comboBoxTeaType.Items.Clear();

            comboBoxBuyer.Text = "";
            comboBoxBrand.Text = "";

            pictureBoxBrandStatus.BackgroundImage = null;

            comboBoxBuyer.SelectedItem = "\0";
            comboBoxBrand.SelectedItem = "\0";
            comboBoxTeabagType.SelectedItem = "\0";
            comboBoxTeaType.SelectedItem = "\0";

            textBoxBarcode.Clear();
            textBoxIC.Clear();
            textBoxTB.Clear();
            textBoxTBWeight.Clear();
            textBoxMCMin.Clear();
            textBoxMCMax.Clear();
            textBoxRemarks.Clear();

            getComboBoxData();

            if (this.childType == ChildFormType.UPDATE)
            {
                textBoxBarcode.Text = orderItemContentToUpdate.barcode;
                textBoxIC.Text = orderItemContentToUpdate.icQuantity.ToString();
                textBoxTB.Text = orderItemContentToUpdate.teabagQuantity.ToString();
                textBoxTBWeight.Text = orderItemContentToUpdate.teabagWeight.ToString();
                textBoxMCMin.Text = orderItemContentToUpdate.MCMinWeight.ToString();
                textBoxMCMax.Text = orderItemContentToUpdate.MCMaxWeight.ToString();
                textBoxRemarks.Text = orderItemContentToUpdate.remark;
                textBoxBarcode.ReadOnly = true;
            }
        }

        private void getComboBoxData()
        {
            try
            {
                comboBoxData = buyerDBHandler.getComboBoxData();

                if (comboBoxData.brands != null)
                {
                    foreach (Brand brand in comboBoxData.brands)
                    {
                        comboBoxBrand.Items.Add(brand.brandName);
                        if (orderItemContentToUpdate != null)
                        {
                            if (string.Equals(brand.brandId, orderItemContentToUpdate.brandId, StringComparison.InvariantCultureIgnoreCase))
                            {
                                comboBoxBrand.SelectedItem = brand.brandName;
                            }
                        }
                    }
                }

                if (comboBoxData.buyers != null)
                {
                    foreach (Buyer buyer in comboBoxData.buyers)
                    {
                        comboBoxBuyer.Items.Add(buyer.buyerName);
                        if (orderItemContentToUpdate != null)
                        {
                            if (string.Equals(buyer.buyerId, orderItemContentToUpdate.buyerId, StringComparison.InvariantCultureIgnoreCase))
                            {
                                comboBoxBuyer.SelectedItem = buyer.buyerName;
                            }
                        }
                    }
                }

                if (comboBoxData.teaProducts != null)
                {
                    foreach (TeaProduct teaProduct in comboBoxData.teaProducts)
                    {
                        comboBoxTeaType.Items.Add(teaProduct.teaProductserialNo);
                        if (orderItemContentToUpdate != null)
                        {
                            if (string.Equals(teaProduct.teaProductId, orderItemContentToUpdate.teaproduct.teaProductId, StringComparison.InvariantCultureIgnoreCase))
                            {
                                comboBoxTeaType.SelectedItem = teaProduct.teaProductserialNo;
                            }
                        }
                    }
                }

                if (comboBoxData.teabagMaterials != null)
                {
                    foreach (TeabagMaterial teabagMaterial in comboBoxData.teabagMaterials)
                    {
                        comboBoxTeabagType.Items.Add(teabagMaterial.materialSerialNo);
                        if (orderItemContentToUpdate != null)
                        {
                            if (string.Equals(teabagMaterial.materialId, orderItemContentToUpdate.teabag.materialId, StringComparison.InvariantCultureIgnoreCase))
                            {
                                comboBoxTeabagType.SelectedItem = teabagMaterial.materialSerialNo;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Form Resetted.", NotificationStates.SUCCESS);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);

            //front-end validation
            if (string.IsNullOrWhiteSpace(comboBoxBuyer.Text) || string.IsNullOrEmpty(comboBoxBuyer.Text) )
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Buyer name cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxBrand.Text) || string.IsNullOrEmpty(comboBoxBrand.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Brand name cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (isValidBrandName == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid Brand Name.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxTeaType.Text) || string.IsNullOrEmpty(comboBoxTeaType.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Tea type cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxTeabagType.Text) || string.IsNullOrEmpty(comboBoxTeabagType.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Teabag Type cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxIC.Text) || string.IsNullOrEmpty(textBoxIC.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Inner carton quantity cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsValidNumber(textBoxIC.Text) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid IC Quantity.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxTB.Text) || string.IsNullOrEmpty(textBoxTB.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Teabag quantity cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsValidNumber(textBoxTB.Text) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid Teabag Quantity.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxTBWeight.Text) || string.IsNullOrEmpty(textBoxTBWeight.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Teabag Weight cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsValidDecimal(textBoxTBWeight.Text) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid Teabag Weight.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxMCMin.Text) || string.IsNullOrEmpty(textBoxMCMin.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Minimum MC Weight cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsValidDecimal(textBoxMCMin.Text) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid MC Minimum Weight.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxMCMax.Text) || string.IsNullOrEmpty(textBoxMCMax.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Maximum MC Weight cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsValidDecimal(textBoxMCMax.Text) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid MC Maximum Weight.", NotificationStates.WARNING);
                return;
            }

            //save
            string selectedBuyerId = null;
            string selectedBrandId = null;
            string selectedTeaProductId = null;
            string selectedTeabagMaterialId = null;

            try
            {
                //get combobox buyer id
                foreach (Buyer buyer in comboBoxData.buyers)
                {
                    if (string.Equals(comboBoxBuyer.Text.ToString(), buyer.buyerName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedBuyerId = buyer.buyerId;
                    }
                }

                //get combobox brand id
                foreach (Brand brand in comboBoxData.brands)
                {
                    if (string.Equals(comboBoxBrand.Text.ToString(), brand.brandName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedBrandId = brand.brandId;
                    }
                }

                //get combobox teaproduct id
                foreach (TeaProduct teaProduct in comboBoxData.teaProducts)
                {
                    if (string.Equals(comboBoxTeaType.Text.ToString(), teaProduct.teaProductserialNo, StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedTeaProductId = teaProduct.teaProductId;
                    }
                }

                //get combobox teabag material id
                foreach (TeabagMaterial teabagMaterial in comboBoxData.teabagMaterials)
                {
                    if (string.Equals(comboBoxTeabagType.Text.ToString(), teabagMaterial.materialSerialNo, StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedTeabagMaterialId = teabagMaterial.materialId;
                    }
                }

                if (this.childType == ChildFormType.ADD)
                {
                    teaProduct = new TeaProduct(selectedTeaProductId, comboBoxTeaType.Text.ToString());
                    teabagMaterial = new TeabagMaterial(selectedTeabagMaterialId, comboBoxTeabagType.Text.ToString());
                    orderItemContentToAdd = new OrderItemContent(selectedBuyerId, comboBoxBuyer.Text.ToString(), selectedBrandId, comboBoxBrand.Text.ToString(), textBoxBarcode.Text, teaProduct, teabagMaterial, int.Parse(textBoxIC.Text), int.Parse(textBoxTB.Text), Decimal.Parse(textBoxTBWeight.Text), Decimal.Parse(textBoxMCMin.Text), Decimal.Parse(textBoxMCMax.Text), textBoxRemarks.Text);

                    if (selectedBuyerId == null)
                    {
                        //insert 3 tables
                        if (buyerDBHandler.addOrderItemContentWithBuyer(orderItemContentToAdd) == true)
                        {
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Order Content Added Successfully.", NotificationStates.SUCCESS);
                            resetForm();
                        }
                    } 
                    else if (selectedBrandId == null)
                    {
                        //insert 2 tables
                        if (buyerDBHandler.addOrderItemContentWithBrand(orderItemContentToAdd) == true)
                        {
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Order Content Added Successfully.", NotificationStates.SUCCESS);
                            resetForm();
                        }
                    }
                    else if (selectedBuyerId != null && selectedBrandId != null)
                    {
                        //insert 1 table
                        if (buyerDBHandler.addOrderItemContent(orderItemContentToAdd) == true)
                        {
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Order Content Added Successfully.", NotificationStates.SUCCESS);
                            resetForm();
                        }
                    }

                }
                else if (this.childType == ChildFormType.UPDATE)
                {
                    teaProduct = new TeaProduct(selectedTeaProductId, comboBoxTeaType.Text);
                    teabagMaterial = new TeabagMaterial(selectedTeabagMaterialId, comboBoxTeabagType.Text);
                    orderItemContentToAdd = new OrderItemContent(selectedBuyerId, comboBoxBuyer.Text.ToString(), selectedBrandId, comboBoxBrand.Text.ToString(), orderItemContentToUpdate.barcode, teaProduct, teabagMaterial, int.Parse(textBoxIC.Text), int.Parse(textBoxTB.Text), Decimal.Parse(textBoxTBWeight.Text), Decimal.Parse(textBoxMCMin.Text), Decimal.Parse(textBoxMCMax.Text), textBoxRemarks.Text);

                    if (selectedBuyerId == null)
                    {
                        //update 1 tables
                        if (buyerDBHandler.updateOrderItemContentWithBuyer(orderItemContentToAdd) == true)
                        {
                            orderItemContentToUpdate = buyerDBHandler.getOrderItemContentByBarcode(orderItemContentToAdd.barcode);
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Order Content Updated Successfully.", NotificationStates.SUCCESS);
                            resetForm();
                        }
                    }
                    else if (selectedBrandId == null)
                    {
                        //update 2 tables
                        if (buyerDBHandler.updateOrderItemContentWithBrand(orderItemContentToAdd) == true)
                        {
                            orderItemContentToUpdate = buyerDBHandler.getOrderItemContentByBarcode(orderItemContentToAdd.barcode);
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Order Content Updated Successfully.", NotificationStates.SUCCESS);
                            resetForm();
                        }
                    }
                    else if (selectedBuyerId != null && selectedBrandId != null)
                    {
                        //update 3 table
                        if (buyerDBHandler.updateOrderItemContent(orderItemContentToAdd) == true)
                        {
                            orderItemContentToUpdate = buyerDBHandler.getOrderItemContentByBarcode(orderItemContentToAdd.barcode);
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Order Content Updated Successfully.", NotificationStates.SUCCESS);
                            resetForm();
                        }
                    }
                }

                if (FormHandler.parentFormName.Trim() == "ManageOrderItemContents")
                {
                    ManageOrderItemContents parentForm = (ManageOrderItemContents)FormHandler.parentForm;
                    parentForm.panelInAppNotifications.Visible = false;
                    parentForm.loadOrderItemContents();
                }

                if (FormHandler.parentFormName.Trim() == "AddNewOrder")
                {
                    AddNewOrder parentForm = (AddNewOrder)FormHandler.parentForm;
                    parentForm.resetForm();
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

        private void comboBoxBuyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string buyer_id = null;
            string buyer_name = comboBoxBuyer.Text.ToString();
            string brand_name_text = comboBoxBrand.Text.ToString();

            comboBoxBrand.Items.Clear();

            foreach (Buyer buyer in comboBoxData.buyers)
            {
                if (string.Equals(buyer_name, buyer.buyerName, StringComparison.InvariantCultureIgnoreCase))
                {
                    buyer_id = buyer.buyerId;
                    break;
                }
            }

            if (buyer_id != null)
            {
                //adding new brand values to the combo box
                foreach (Brand brand in comboBoxData.brands)
                {
                    if (string.Equals(brand.buyerId , buyer_id, StringComparison.InvariantCultureIgnoreCase))
                    {
                        comboBoxBrand.Items.Add(brand.brandName);
                    }
                    if (orderItemContentToUpdate != null)
                    {
                        if (string.Equals(brand.brandId, orderItemContentToUpdate.brandId, StringComparison.InvariantCultureIgnoreCase))
                        {
                            comboBoxBrand.SelectedItem = brand.brandName;
                        }
                    }
                }
            }
        }

        private void comboBoxBuyer_TextChanged(object sender, EventArgs e)
        {
            string buyer_id = null;
            string buyer_name = comboBoxBuyer.Text.ToString();
            string brand_name = comboBoxBrand.Text.ToString();

            comboBoxBrand.Items.Clear();

            foreach (Buyer buyer in comboBoxData.buyers)
            {
                if (string.Equals(buyer_name, buyer.buyerName, StringComparison.InvariantCultureIgnoreCase))
                {
                    buyer_id = buyer.buyerId;
                    break;
                }
            }

            if (buyer_id != null)
            {
                //adding new brand values to the combo box
                foreach (Brand brand in comboBoxData.brands)
                {
                    if (string.Equals(brand.buyerId, buyer_id, StringComparison.InvariantCultureIgnoreCase))
                    {
                        comboBoxBrand.Items.Add(brand.brandName);
                    }
                    if (orderItemContentToUpdate != null)
                    {
                        if (string.Equals(brand.brandId, orderItemContentToUpdate.brandId, StringComparison.InvariantCultureIgnoreCase))
                        {
                            comboBoxBrand.SelectedItem = brand.brandName;
                        }
                    }
                }
            }

            if (!(string.IsNullOrEmpty(brand_name) || string.IsNullOrWhiteSpace(brand_name)))
            {
                foreach (Brand brand in comboBoxData.brands)
                {
                    if (string.Equals(brand.brandName, brand_name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (brand.buyerName != buyer_name)
                        {
                            pictureBoxBrandStatus.BackgroundImage = Resources.closeC;
                            isValidBrandName = false;
                            break;
                        }
                        else
                        {
                            pictureBoxBrandStatus.BackgroundImage = Resources.tickC;
                            isValidBrandName = true;
                            break;
                        }
                    }
                    else
                    {
                        pictureBoxBrandStatus.BackgroundImage = Resources.tickC;
                        isValidBrandName = true;
                    }
                }
            }
            else
            {
                pictureBoxBrandStatus.BackgroundImage = null;
                isValidBrandName = false;
            }
        }


        private void comboBoxBrand_SelectedValueChanged(object sender, EventArgs e)
        {
            string brand_name = comboBoxBrand.Text.ToString();

            foreach (Brand brand in comboBoxData.brands)
            {
                if (string.Equals(brand.brandName, brand_name, StringComparison.InvariantCultureIgnoreCase))
                {
                    comboBoxBuyer.SelectedItem = brand.buyerName;
                    comboBoxBrand.SelectedItem = brand_name;
                    break;
                }
            }
        }

        private void comboBoxBrand_TextChanged(object sender, EventArgs e)
        {
            string buyer_name = comboBoxBuyer.Text.ToString();
            string brand_name = comboBoxBrand.Text.ToString();

            if (!(string.IsNullOrEmpty(brand_name) || string.IsNullOrWhiteSpace(brand_name)))
            {
                foreach (Brand brand in comboBoxData.brands)
                {
                    if (string.Equals(brand.brandName, brand_name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (brand.buyerName != buyer_name)
                        {
                            pictureBoxBrandStatus.BackgroundImage = Resources.closeC;
                            isValidBrandName = false;
                            break;
                        }
                        else
                        {
                            pictureBoxBrandStatus.BackgroundImage = Resources.tickC;
                            isValidBrandName = true;
                            break;
                        }
                    }
                    else
                    {
                        pictureBoxBrandStatus.BackgroundImage = Resources.tickC;
                        isValidBrandName = true;
                    }
                }
            }
            else
            {
                pictureBoxBrandStatus.BackgroundImage = null;
                isValidBrandName = false;
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            comboBoxBuyer.SelectedIndex = 0;
            comboBoxBrand.SelectedIndex = 0;
            comboBoxTeabagType.SelectedIndex = 0;
            comboBoxTeaType.SelectedIndex = 0;
            textBoxBarcode.Text = "655822351224";
            textBoxIC.Text = "40";
            textBoxTB.Text = "24";
            textBoxTBWeight.Text = "4";
            textBoxMCMin.Text = "3";
            textBoxMCMax.Text = "5.50";
            textBoxRemarks.Text = "This order items use the old packaging of this product. please do not use the new designs if not advised otherwise.";
        }
    }
}
