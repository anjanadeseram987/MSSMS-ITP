using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Properties;
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
    public partial class AddFinishedGoods : Form
    {
        private List<OrderItem> allOnGoingOrderItems = new List<OrderItem>();
        private List<Location> locations = new List<Location>();
        private OrderItem selectedOrderItem = null;
        private Boolean isValidBarcode = false;
        private Boolean isAuthorized = false;
        private Boolean isNormalWeight = false;
        private FinishedGood finishedGoodToAdd = null;
        private FinishedGood finishedGoodToUpdate = null;
        private FinishedGoodsDBHandler finishedGoodsDBHandler = new FinishedGoodsDBHandler();
        private ChildFormType childType;

        public AddFinishedGoods()
        {
            InitializeComponent();
            this.childType = FormHandler.childFormType;
        }

        private void AddFinishedGoods_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (this.childType == ChildFormType.UPDATE)
            {
                finishedGoodToUpdate = (FinishedGood)FormHandler.newObject;
            }
            resetForm();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
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
            if (string.IsNullOrEmpty(textBoxBarcode.Text) || string.IsNullOrWhiteSpace(textBoxBarcode.Text) || isValidBarcode == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please enter a valid Barcode", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrEmpty(comboBoxOrderItemNo.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please select a valid Order Item Number.", NotificationStates.WARNING);
                return;
            }

            if (!ValidationHandler.IsValidDecimal(textBoxMCWeight.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please enter a valid M/C Weight.", NotificationStates.WARNING);
                return;
            }

            if (isNormalWeight == false)
            {
                if(isAuthorized == false)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please check \"Authorize\" before adding underweight or overweight M/Cs.", NotificationStates.WARNING);
                    return;
                }
            }

            if (!ValidationHandler.IsAftereDate(dateTimePickerExpiryDate.Value))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please select a valid Expiry Date.", NotificationStates.WARNING);
                return;
            }

            String selectedLocationId = null;

            if (string.IsNullOrEmpty(comboBoxLocation.Text) || string.IsNullOrWhiteSpace(comboBoxLocation.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please select a valid Location", NotificationStates.WARNING);
                return;
            }
            else
            {
                foreach(Location location in locations)
                {
                    if (string.Equals(comboBoxLocation.Text, location.location_id + " " + location.location_name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedLocationId =location.location_id;
                    }
                }
            }

            try
            {
                if (this.childType == ChildFormType.ADD)
                {
                    finishedGoodToAdd = new FinishedGood(comboBoxOrderItemNo.Text, textBoxOngoingMCNumber.Text, selectedLocationId, SessionManager.user.employeeId, DateTime.Now, Decimal.Parse(textBoxMCWeight.Text), dateTimePickerExpiryDate.Value, "Completed", (string.IsNullOrEmpty(textBoxRemarks.Text) || string.IsNullOrWhiteSpace(textBoxRemarks.Text)) ? "N/A" : textBoxRemarks.Text);
                    finishedGoodToAdd.orderNo = selectedOrderItem.order.order_no;
                    finishedGoodToAdd.totalMCQuantity = selectedOrderItem.mcQuantity;
                    finishedGoodToAdd.productionPlanId = selectedOrderItem.productionPlanId;

                    if (finishedGoodsDBHandler.addMasterCarton(finishedGoodToAdd) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Master Carton was Added Successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }
                else if (this.childType == ChildFormType.UPDATE)
                {
                    finishedGoodToAdd = new FinishedGood(comboBoxOrderItemNo.Text, textBoxOngoingMCNumber.Text, selectedLocationId, SessionManager.user.employeeId, DateTime.Now, Decimal.Parse(textBoxMCWeight.Text), dateTimePickerExpiryDate.Value, "Completed", (string.IsNullOrEmpty(textBoxRemarks.Text) || string.IsNullOrWhiteSpace(textBoxRemarks.Text)) ? "N/A" : textBoxRemarks.Text);
                    finishedGoodToAdd.orderItem = finishedGoodToUpdate.orderItem;

                    if (finishedGoodsDBHandler.updateMasterCarton(finishedGoodToAdd) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Master Carton was Updated Successfully.", NotificationStates.SUCCESS);
                        finishedGoodToUpdate = finishedGoodToAdd;
                        resetForm();
                    }
                }


                if (FormHandler.parentFormName.Trim() == "ManageManufacturing")
                {
                    ManageManufacturing parentForm = (ManageManufacturing)FormHandler.parentForm;
                    parentForm.loadFinishedGoods();
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

        private void textBoxBarcode_TextChanged(object sender, EventArgs e)
        {
            if (this.childType == ChildFormType.ADD) 
            {
                comboBoxOrderItemNo.Items.Clear();
                comboBoxOrderItemNo.Text = "";
                textBoxBuyer.Clear();
                textBoxLoadingDate.Clear();
                labelProductDetails.Text = "";
                labelTotalMCQuantity.Text = "";
                labelMCMinMax.Text = "";
                labelMCWeightIndicator.Text = "";
                pictureBoxMCWeightIndicator.BackgroundImage = null;
                panelWeightAuth.Visible = false;
                textBoxOngoingMCNumber.Clear();
                labelOrderItemNumber.Text = "";
                labelOngoingMCWeight.Text = "";
                labelMCNumber.Text = "";
                checkBoxAuthorizeMC.Checked = false;
                isValidBarcode = false;
                isNormalWeight = false;
                selectedOrderItem = null;
                panelQRCode.BackgroundImage = null;

                if (string.IsNullOrEmpty(textBoxBarcode.Text.Trim()) || string.IsNullOrWhiteSpace(textBoxBarcode.Text.Trim())) {
                    pictureBoxBarcodeStatus.BackgroundImage = null;
                } 
                else
                {
                    Boolean isFound = false;

                    foreach (OrderItem orderItem in allOnGoingOrderItems) {
                        if (string.Equals(textBoxBarcode.Text.Trim(), orderItem.orderItemContent.barcode, StringComparison.InvariantCultureIgnoreCase))
                        {
                            pictureBoxBarcodeStatus.BackgroundImage = Resources.tickC ;
                            selectedOrderItem = orderItem;
                            isValidBarcode = true;
                            isFound = true;
                            break;
                        }
                        else
                        {
                            isFound = false;
                        }
                    }

                    if(isFound == false)
                    {
                        pictureBoxBarcodeStatus.BackgroundImage = Resources.closeC;
                        isValidBarcode = false;
                    }
                }

                if(selectedOrderItem != null)
                {
                    foreach(OrderItem orderItem in allOnGoingOrderItems)
                    {
                        if(string.Equals(selectedOrderItem.orderItemContent.barcode, orderItem.orderItemContent.barcode, StringComparison.InvariantCultureIgnoreCase))
                        {
                            comboBoxOrderItemNo.Items.Add(orderItem.orderItemNo);

                            if (string.IsNullOrEmpty(textBoxMCWeight.Text) || string.IsNullOrWhiteSpace(textBoxMCWeight.Text))
                            {
                                labelMCWeightIndicator.Text = "";
                                pictureBoxMCWeightIndicator.BackgroundImage = null;
                                panelWeightAuth.Visible = false;
                            }
                            else
                            {
                                if (ValidationHandler.IsValidDecimal(textBoxMCWeight.Text.Trim()))
                                {
                                    if (Decimal.Parse(textBoxMCWeight.Text) < orderItem.orderItemContent.MCMinWeight)
                                    {
                                        labelMCWeightIndicator.Text = "Underweight";
                                        labelMCWeightIndicator.ForeColor = Color.FromArgb(229, 57, 53);
                                        pictureBoxMCWeightIndicator.BackgroundImage = Resources.closeC;
                                        panelWeightAuth.Visible = true;
                                        isNormalWeight = false;
                                    }
                                    else if (Decimal.Parse(textBoxMCWeight.Text) > orderItem.orderItemContent.MCMaxWeight)
                                    {
                                        labelMCWeightIndicator.Text = "Overweight";
                                        labelMCWeightIndicator.ForeColor = Color.FromArgb(229, 57, 53);
                                        pictureBoxMCWeightIndicator.BackgroundImage = Resources.closeC;
                                        panelWeightAuth.Visible = true;
                                        isNormalWeight = false;
                                    }
                                    else if (Decimal.Parse(textBoxMCWeight.Text) >= orderItem.orderItemContent.MCMinWeight && Decimal.Parse(textBoxMCWeight.Text) <= orderItem.orderItemContent.MCMaxWeight)
                                    {
                                        labelMCWeightIndicator.Text = "Normal";
                                        labelMCWeightIndicator.ForeColor = Color.FromArgb(67, 160, 71);
                                        pictureBoxMCWeightIndicator.BackgroundImage = Resources.tickC;
                                        panelWeightAuth.Visible = false;
                                        isNormalWeight = true;
                                    }
                                }
                                else
                                {
                                    labelMCWeightIndicator.Text = "";
                                    pictureBoxMCWeightIndicator.BackgroundImage = null;
                                    panelWeightAuth.Visible = false;
                                    isNormalWeight = false;
                                }
                            }

                            textBoxBuyer.Text = orderItem.buyer.buyerName;
                            labelProductDetails.Text = "Brand: " + orderItem.brand.brandName + " [" + orderItem.brand.brandId + "]\nBarcode: " + orderItem.orderItemContent.barcode + "\nTea Product Info: " + orderItem.teaProduct.teaProductName + " " + orderItem.teaProduct.teaProductflavor + " [" + orderItem.teaProduct.teaProductserialNo + "]\nTea Bag Info: " + orderItem.teabagMaterial.materialName + " - " + orderItem.teabagMaterial.teabagType + "[" + orderItem.teabagMaterial.materialSerialNo + "]\nPackaging Details: [" + orderItem.orderItemContent.teabagWeight + "g] X [" + orderItem.orderItemContent.teabagQuantity + "] X [" + orderItem.orderItemContent.icQuantity + "]";
                            labelMCMinMax.Text = labelMCMinMax.Text = "Min M/C Weight: " + orderItem.orderItemContent.MCMinWeight + " KG\nMax M/ C Weight: " + orderItem.orderItemContent.MCMaxWeight + " KG";
                        }
                    }
                    panelQRCode.BackgroundImage = generateQRCode();
                }
            }
        }

        private void comboBoxOrderItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.childType == ChildFormType.ADD)
            {
                textBoxLoadingDate.Clear();
                labelProductDetails.Text = "";
                textBoxOngoingMCNumber.Clear();
                labelOrderItemNumber.Text = "";
                labelTotalMCQuantity.Text = "";
                labelMCNumber.Text = "";

                String selectedOrderItemNo = comboBoxOrderItemNo.Text.ToString();
                OrderItem selectedOrderItem = null;

                if(!string.IsNullOrEmpty(selectedOrderItemNo) && !string.IsNullOrWhiteSpace(selectedOrderItemNo))
                {
                    foreach(OrderItem orderItem in allOnGoingOrderItems)
                    {
                        if(string.Equals(selectedOrderItemNo, orderItem.orderItemNo, StringComparison.InvariantCultureIgnoreCase))
                        {
                            selectedOrderItem = orderItem;
                            break;
                        }
                    }

                    if(selectedOrderItem != null)
                    {
                        textBoxOngoingMCNumber.Text = (selectedOrderItem.mc_count + 1).ToString();
                        labelMCNumber.Text = (selectedOrderItem.mc_count + 1).ToString();
                        labelOrderItemNumber.Text = selectedOrderItem.orderItemNo;

                        if (selectedOrderItem.shippingSchedule.loading_date == DateTime.MinValue)
                        {
                            textBoxLoadingDate.Text = "N/A";
                        }
                        else
                        {
                            textBoxLoadingDate.Text = selectedOrderItem.shippingSchedule.loading_date.ToString();
                        }

                        labelProductDetails.Text = "Brand: "+ selectedOrderItem.brand.brandName + " [" + selectedOrderItem.brand.brandId + "]\nBarcode: " + selectedOrderItem.orderItemContent.barcode + "\nTea Product Info: "+ selectedOrderItem.teaProduct.teaProductName +" "+ selectedOrderItem.teaProduct.teaProductflavor+" ["+ selectedOrderItem.teaProduct.teaProductserialNo + "]\nTea Bag Info: " + selectedOrderItem.teabagMaterial.materialName+ " - " + selectedOrderItem.teabagMaterial.teabagType + "[" + selectedOrderItem.teabagMaterial.materialSerialNo + "]\nPackaging Details: ["+ selectedOrderItem.orderItemContent.teabagWeight + "g] X [" + selectedOrderItem.orderItemContent.teabagQuantity +"] X ["+ selectedOrderItem.orderItemContent.icQuantity + "]\nM/C Amount: "+ selectedOrderItem.mcQuantity +"MCs";
                        labelTotalMCQuantity.Text = " out of " + selectedOrderItem.mcQuantity + " M/Cs.";
                        panelQRCode.BackgroundImage = generateQRCode();
                    }

                }
            }
        }

        private void textBoxMCWeight_TextChanged(object sender, EventArgs e)
        {
            if (ValidationHandler.IsValidDecimal(textBoxMCWeight.Text) && isValidBarcode == true)
            {
                if (Decimal.Parse(textBoxMCWeight.Text) < selectedOrderItem.orderItemContent.MCMinWeight)
                {
                    labelMCWeightIndicator.Text = "Underweight";
                    labelMCWeightIndicator.ForeColor = Color.FromArgb(229, 57, 53);
                    pictureBoxMCWeightIndicator.BackgroundImage = Resources.closeC;
                    panelWeightAuth.Visible = true;
                    isNormalWeight = false;
                }
                else if (Decimal.Parse(textBoxMCWeight.Text) > selectedOrderItem.orderItemContent.MCMaxWeight)
                {
                    labelMCWeightIndicator.Text = "Overweight";
                    labelMCWeightIndicator.ForeColor = Color.FromArgb(229, 57, 53);
                    pictureBoxMCWeightIndicator.BackgroundImage = Resources.closeC;
                    panelWeightAuth.Visible = true;
                    isNormalWeight = false;
                }
                else if (Decimal.Parse(textBoxMCWeight.Text) >= selectedOrderItem.orderItemContent.MCMinWeight && Decimal.Parse(textBoxMCWeight.Text) <= selectedOrderItem.orderItemContent.MCMaxWeight)
                {
                    labelMCWeightIndicator.Text = "Normal";
                    labelMCWeightIndicator.ForeColor = Color.FromArgb(67, 160, 71);
                    pictureBoxMCWeightIndicator.BackgroundImage = Resources.tickC;
                    panelWeightAuth.Visible = false;
                    isNormalWeight = true;
                }

                labelOngoingMCWeight.Text = textBoxMCWeight.Text;
                panelQRCode.BackgroundImage = generateQRCode();
            }
            else
            {
                labelMCWeightIndicator.Text = "";
                labelOngoingMCWeight.Text = "";
                pictureBoxMCWeightIndicator.BackgroundImage = null;
                panelWeightAuth.Visible = false;
                isNormalWeight = false;
            }
        }

        private void checkBoxAuthorizeMC_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxAuthorizeMC.Checked == true)
            {
                isAuthorized = true;
            } else
            {
                isAuthorized = false;
            }
        }

        private void dateTimePickerExpiryDate_ValueChanged(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(dateTimePickerExpiryDate.Value.ToString()) || String.IsNullOrWhiteSpace(dateTimePickerExpiryDate.Value.ToString()))
            {
                labelExpDate.Text = "N/A";
            }
            else
            {
                labelExpDate.Text = dateTimePickerExpiryDate.Value.ToString();
                panelQRCode.BackgroundImage = generateQRCode();
            }
        }

        private void resetForm()
        {
            textBoxBarcode.Text = "";
            labelTotalMCQuantity.Text = "";
            comboBoxOrderItemNo.Items.Clear();
            comboBoxOrderItemNo.SelectedItem = "\0";
            textBoxBuyer.Text = "";
            labelProductDetails.Text = "";
            textBoxLoadingDate.Text = "";
            textBoxMCWeight.Text = "";
            checkBoxAuthorizeMC.Checked = false;
            textBoxAuthorizationCode.Text = "";
            textBoxOngoingMCNumber.Text = "";
            dateTimePickerExpiryDate.Value = DateTime.Now;
            textBoxRemarks.Text = "";
            checkBoxPrintMCQR.Checked = false;
            checkBoxPrintMCLabel.Checked = false;
            labelEmployeeId.Text = SessionManager.user.employeeId;
            labelExpDate.Text = "";
            labelManufDate.Text = DateTime.Now.ToString();
            labelMCNumber.Text = "";
            labelOngoingMCWeight.Text = "";
            labelOrderItemNumber.Text = "";
            labelMCWeightIndicator.Text = "";
            pictureBoxMCWeightIndicator.BackgroundImage = null;
            panelWeightAuth.Visible = false;
            panelQRCode.BackgroundImage = null;
            pictureBoxBarcodeStatus.BackgroundImage = null;
            labelMCMinMax.Text = "";
            loadLocations();

            if (this.childType == ChildFormType.UPDATE)
            {
                selectedOrderItem = finishedGoodToUpdate.orderItem;
                this.Text = "Update Finished Good Details";
                this.btnSave.Text = "Update Details";
                this.lblTitle.Text = "UPDATE " + finishedGoodToUpdate.fg_orderitem_no + " [MC: " + finishedGoodToUpdate.fg_mc_no + " ]";
                this.lblDescription.Text = "Please Fill the required fields in order to update the selected Finished Good Details.";
                textBoxBarcode.ReadOnly = true;
                textBoxBarcode.Text = finishedGoodToUpdate.orderItem.orderItemContent.barcode;
                comboBoxOrderItemNo.Items.Add(finishedGoodToUpdate.orderItem.orderItemNo);
                comboBoxOrderItemNo.SelectedItem = finishedGoodToUpdate.orderItem.orderItemNo;
                textBoxBuyer.Text = finishedGoodToUpdate.orderItem.buyer.buyerName;
                labelProductDetails.Text = "Brand: " + finishedGoodToUpdate.orderItem.brand.brandName+" ["+ finishedGoodToUpdate.orderItem.brand.brandId+"]\nBarcode: " + finishedGoodToUpdate.orderItem.orderItemContent.barcode+"\nTea Product Details: "+ finishedGoodToUpdate.orderItem.teaProduct.teaProductName+" "+finishedGoodToUpdate.orderItem.teaProduct.teaProductflavor+" (" +finishedGoodToUpdate.orderItem.teaProduct.teaProductserialNo + ")\nTeabag Material Details: "+finishedGoodToUpdate.orderItem.teabagMaterial.materialDescription+" "+finishedGoodToUpdate.orderItem.teabagMaterial.teabagType+" ("+finishedGoodToUpdate.orderItem.teabagMaterial.materialSerialNo + ")\nPackaging Details: [" + finishedGoodToUpdate.orderItem.orderItemContent.teabagWeight.ToString() + "+g] X [" + finishedGoodToUpdate.orderItem.orderItemContent.teabagQuantity.ToString() + "] X [" + finishedGoodToUpdate.orderItem.orderItemContent.icQuantity.ToString()+"]\nTotal M/C Quantity: " + finishedGoodToUpdate.orderItem.mcQuantity;
                labelTotalMCQuantity.Text = " out of " + finishedGoodToUpdate.orderItem.mcQuantity + " M/Cs.";
                textBoxLoadingDate.Text = (finishedGoodToUpdate.orderItem.shippingSchedule.loading_date == DateTime.MinValue) ? "N/A" : finishedGoodToUpdate.orderItem.shippingSchedule.loading_date.ToString();
                textBoxMCWeight.Text = finishedGoodToUpdate.fg_mc_weight.ToString();
                labelOngoingMCWeight.Text = finishedGoodToUpdate.fg_mc_weight.ToString();
                labelMCMinMax.Text = "Min M/C Weight: " + finishedGoodToUpdate.orderItem.orderItemContent.MCMinWeight + " KG\nMax M/ C Weight: " + finishedGoodToUpdate.orderItem.orderItemContent.MCMaxWeight + " KG";
                if (finishedGoodToUpdate.fg_mc_weight < finishedGoodToUpdate.orderItem.orderItemContent.MCMinWeight)
                {
                    labelMCWeightIndicator.Text = "Underweight";
                    labelMCWeightIndicator.ForeColor = Color.FromArgb(229, 57, 53);
                    pictureBoxMCWeightIndicator.BackgroundImage = Resources.cross;
                    panelWeightAuth.Visible = true;
                    isNormalWeight = false;
                    checkBoxAuthorizeMC.Checked = true;
                } 
                else if (finishedGoodToUpdate.fg_mc_weight > finishedGoodToUpdate.orderItem.orderItemContent.MCMaxWeight)
                {
                    labelMCWeightIndicator.Text = "Overweight";
                    labelMCWeightIndicator.ForeColor = Color.FromArgb(229, 57, 53);
                    pictureBoxMCWeightIndicator.BackgroundImage = Resources.cross;
                    panelWeightAuth.Visible = true;
                    checkBoxAuthorizeMC.Checked = true;
                    isNormalWeight = false;
                }
                else
                {
                    labelMCWeightIndicator.Text = "Normal";
                    labelMCWeightIndicator.ForeColor = Color.FromArgb(139, 195, 74);
                    pictureBoxMCWeightIndicator.BackgroundImage = Resources.tick;
                    panelWeightAuth.Visible = false;
                    checkBoxAuthorizeMC.Checked = false;
                    isNormalWeight = true;
                }
                textBoxOngoingMCNumber.Text = finishedGoodToUpdate.fg_mc_no;
                dateTimePickerExpiryDate.Value = finishedGoodToUpdate.fg_exp_date;
                textBoxRemarks.Text = finishedGoodToUpdate.fg_remarks;
                labelEmployeeId.Text = finishedGoodToUpdate.fg_added_by;
                labelExpDate.Text = finishedGoodToUpdate.fg_exp_date.ToString();
                labelManufDate.Text = finishedGoodToUpdate.fg_added_date.ToString();
                labelMCNumber.Text = finishedGoodToUpdate.fg_mc_no;
                labelOrderItemNumber.Text = finishedGoodToUpdate.fg_orderitem_no;
                isValidBarcode = true;

                foreach(Location location in locations)
                {
                    if(string.Equals(finishedGoodToUpdate.fg_location_id, location.location_id, StringComparison.InvariantCultureIgnoreCase))
                    {
                        comboBoxLocation.SelectedItem = location.location_id + " " + location.location_name;
                    }
                }

                //generating the QR Code
                panelQRCode.BackgroundImage = generateQRCode();

            } else
            {
                loadOngoingOrderItems();
            }
        }

        public void loadOngoingOrderItems()
        {
            try
            {
                allOnGoingOrderItems = finishedGoodsDBHandler.getAllOnGoingOrderItems();
            }
            catch (MSSMUIException ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
        }

        public void loadLocations()
        {
            comboBoxLocation.Items.Clear();
            comboBoxLocation.Text = "";
            try
            {
                locations = finishedGoodsDBHandler.getAllLocations();

                foreach(Location location in locations)
                {
                    comboBoxLocation.Items.Add(location.location_id + " " + location.location_name);
                }

            }
            catch (MSSMUIException ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
        }

        private Bitmap generateQRCode()
        {
            if(!string.IsNullOrEmpty(labelOrderItemNumber.Text) && !string.IsNullOrEmpty(labelMCNumber.Text) && !string.IsNullOrEmpty(labelEmployeeId.Text) && !string.IsNullOrEmpty(labelManufDate.Text) && !string.IsNullOrEmpty(labelOngoingMCWeight.Text) && !string.IsNullOrEmpty(labelOngoingMCWeight.Text) && !string.IsNullOrEmpty(labelExpDate.Text) && !string.IsNullOrWhiteSpace(labelOrderItemNumber.Text) && !string.IsNullOrWhiteSpace(labelMCNumber.Text) && !string.IsNullOrWhiteSpace(labelEmployeeId.Text) && !string.IsNullOrWhiteSpace(labelManufDate.Text) && !string.IsNullOrWhiteSpace(labelExpDate.Text))
            {
                String qrData = "Order Item No: " + labelOrderItemNumber.Text + "\nM/C No: " + labelMCNumber.Text + "\nM/C Weight (KG): " + labelOngoingMCWeight.Text + "\nEmployee ID: " + labelEmployeeId.Text + "\nManufactured Date: " + labelManufDate.Text + "\nExpiry Date: " + labelExpDate.Text;

                QRCoder.QRCodeGenerator qrCodeGenerator = new QRCoder.QRCodeGenerator();
                QRCoder.QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(qrData, QRCoder.QRCodeGenerator.ECCLevel.H);
                QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);
                return qrCode.GetGraphic(50);
            }
            else
            {
                return null;
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            textBoxBarcode.Text = "test2"; //TODO: add a valid barcode
            comboBoxOrderItemNo.SelectedIndex = 0;
            textBoxMCWeight.Text = "24";
            checkBoxAuthorizeMC.Checked = true;
            dateTimePickerExpiryDate.Value = DateTime.Parse("2021-05-05");
            textBoxRemarks.Text = "Please use black color tape when sticking labels.";
            checkBoxPrintMCQR.Checked = false;
            checkBoxPrintMCLabel.Checked = false;
            labelEmployeeId.Text = SessionManager.user.employeeId;
            labelManufDate.Text = DateTime.Now.ToString();
        }
    }
}
