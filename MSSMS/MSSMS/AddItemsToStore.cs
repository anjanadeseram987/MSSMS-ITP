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
    public partial class AddItemsToStore : Form
    {
        private List<FinishedGood> finishedGoods = new List<FinishedGood>();
        private List<Location> locations = new List<Location>();
        private FinishedGood selectedMC = null;
        private OrderItem selectedOrderItem = null;
        private Boolean isValidMC = false;
        private StoredGood storedGoodToAdd = null;
        private StoredGood storedGoodToUpdate = null;
        private StoreDBHandler storeDBHandler = new StoreDBHandler();
        private ChildFormType childType;

        public AddItemsToStore()
        {
            InitializeComponent();
            this.childType = FormHandler.childFormType;
            if (this.childType == ChildFormType.UPDATE)
            {
                storedGoodToUpdate = (StoredGood)FormHandler.newObject;
            }
            this.textBoxMOrderItemNo.Focus();
        }

        private void AddItemsToStore_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            resetForm();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void tabControlAddToStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetForm();
            if(tabControlAddToStore.SelectedTab.Name == "QRTab")
            {
                MessageBox.Show("Sorry! QR-Code features are not available yet.");
            }
        }

        private void btnMReset_Click(object sender, EventArgs e)
        {
            resetForm();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Form Resetted.", NotificationStates.SUCCESS);
        }

        private void textBoxMOrderItemNo_TextChanged(object sender, EventArgs e)
        {
            if (this.childType == ChildFormType.ADD)
            {
                checkIfMCExists();
            }
        }

        private void textBoxMMCNo_TextChanged(object sender, EventArgs e)
        {
            if (this.childType == ChildFormType.ADD)
            {
                checkIfMCExists();
            }
        }

        private void checkIfMCExists()
        {
            labelMMCTotal.Text = "";
            labelMMCInfo.Text = "[N/A]";
            selectedMC = null;

            if (!string.IsNullOrEmpty(textBoxMMCNo.Text) && !string.IsNullOrEmpty(textBoxMOrderItemNo.Text) && !string.IsNullOrWhiteSpace(textBoxMMCNo.Text) && !string.IsNullOrWhiteSpace(textBoxMOrderItemNo.Text))
            {
                foreach (FinishedGood finishedGood in finishedGoods)
                {
                    if (string.Equals(finishedGood.fg_orderitem_no, textBoxMOrderItemNo.Text.Trim(), StringComparison.InvariantCultureIgnoreCase) == true && string.Equals(finishedGood.fg_mc_no, textBoxMMCNo.Text.Trim(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        isValidMC = true;
                        pictureBoxMMCStatus.BackgroundImage = Resources.tickC;
                        pictureBoxMOrderItemStatus.BackgroundImage = Resources.tickC;
                        selectedMC = finishedGood;

                        //Displaying MC details
                        labelMMCTotal.Text = "out of " + finishedGood.orderItem.mcQuantity;
                        labelMMCInfo.Text = "BARCODE:    " + finishedGood.orderItem.orderItemContent.barcode + "\nBRAND:    " + finishedGood.orderItem.brand.brandName + " [" + finishedGood.orderItem.brand.brandId + "]\n\nTEA PRODUCT and FLAVOR:   " + finishedGood.orderItem.teaProduct.teaProductName + " (" + finishedGood.orderItem.teaProduct.teaProductflavor + ") [" + finishedGood.orderItem.teaProduct.teaProductserialNo + "]\nTEABAG TYPE and MATERIAL:    " + finishedGood.orderItem.teabagMaterial.materialName + " (" + finishedGood.orderItem.teabagMaterial.teabagType + ") [" + finishedGood.orderItem.teabagMaterial.materialSerialNo + "]\n\nCONTENTS and PACKAGING:    " + "[" + finishedGood.orderItem.orderItemContent.teabagWeight + "g] x [" + finishedGood.orderItem.orderItemContent.teabagQuantity + "] x [" + finishedGood.orderItem.orderItemContent.icQuantity + "]\nMASTER CARTON WEIGHT:    " + finishedGood.fg_mc_weight + " KG\n\nSHIPPING LOCATION:    " + finishedGood.orderItem.shippingDetails.location + "\nLOADING DATE:    " + (finishedGood.orderItem.shippingSchedule.loading_date == DateTime.MinValue ? "N/A" : finishedGood.orderItem.shippingSchedule.loading_date.ToString()) + "\nMANUFACTURED DATE:    " + finishedGood.fg_added_date.ToString() + "\nEXPIRY DATE:    " + finishedGood.fg_exp_date.ToString();
                        break;
                    }
                    else
                    {
                        isValidMC = false;
                        selectedMC = null;
                        pictureBoxMMCStatus.BackgroundImage = Resources.closeC;
                        pictureBoxMOrderItemStatus.BackgroundImage = Resources.closeC;
                    }
                }
            }
            else
            {
                isValidMC = false;
                selectedMC = null;
                pictureBoxMMCStatus.BackgroundImage = null;
                pictureBoxMOrderItemStatus.BackgroundImage = null;
            }

            if (!string.IsNullOrEmpty(textBoxMOrderItemNo.Text) && !string.IsNullOrWhiteSpace(textBoxMOrderItemNo.Text))
            {
                foreach (FinishedGood finishedGood in finishedGoods)
                {
                    if (string.Equals(textBoxMOrderItemNo.Text, finishedGood.fg_orderitem_no, StringComparison.InvariantCultureIgnoreCase))
                    {
                        pictureBoxMOrderItemStatus.BackgroundImage = Resources.tickC;
                        break;
                    }
                    else
                    {
                        pictureBoxMOrderItemStatus.BackgroundImage = Resources.closeC;
                    }
                }
            }
            else
            {
                pictureBoxMOrderItemStatus.BackgroundImage = null;
                textBoxMMCNo.Text = "";
            }
        }

        private void resetForm()
        {
            if (this.childType == ChildFormType.ADD)
            {
                loadFinishedGoods();
            }
            else
            {
                textBoxMMCNo.ReadOnly = true;
                textBoxMOrderItemNo.ReadOnly = true;
            }
            ((Control)this.QRTab).Enabled = false;

            //MANUAL TAB
            textBoxMMCNo.Text = "";
            textBoxMOrderItemNo.Text = "";
            pictureBoxMMCStatus.BackgroundImage = null;
            pictureBoxMOrderItemStatus.BackgroundImage = null;
            labelMMCTotal.Text = "";
            comboBoxMLocation.Items.Clear();
            comboBoxMLocation.SelectedItem = "\0";
            comboBoxMLocation.Text = "";
            labelMMCInfo.Text = "[N/A]";
            isValidMC = false;
            loadLocations();

            //QR-TAB
            textBoxQRMCNo.Text = "";
            textBoxQROrderItemNo.Text = "";
            pictureBoxQRMCStatus.BackgroundImage = null;
            pictureBoxQROrderItemStatus.BackgroundImage = null;
            labelQRMCTotal.Text = "";
            comboBoxQRLocation.Text = "";
            comboBoxQRLocation.Items.Clear();
            labelQRMCInfo.Text = "[N/A]";

            if (this.childType == ChildFormType.UPDATE)
            {
                isValidMC = true;
                selectedMC = storedGoodToUpdate.finishedGood;
                this.Text = "Update Stored MC Details";
                this.btnMAdd.Text = "Update MC";
                this.lblTitle.Text = "UPDATE " + storedGoodToUpdate.sg_orderitem_no + " [MC: " + storedGoodToUpdate.sg_mc_no.ToUpper() + "]";
                this.lblDescription.Text = "Make necessary changes and update the Master Carton Details.";
                textBoxMMCNo.Text = storedGoodToUpdate.sg_mc_no;
                textBoxMOrderItemNo.Text = storedGoodToUpdate.sg_orderitem_no; 
                labelMMCTotal.Text = "out of " + storedGoodToUpdate.finishedGood.orderItem.mcQuantity;
                labelMMCInfo.Text = "BARCODE:    " + storedGoodToUpdate.finishedGood.orderItem.orderItemContent.barcode + "\nBRAND:    " + storedGoodToUpdate.finishedGood.orderItem.brand.brandName + " [" + storedGoodToUpdate.finishedGood.orderItem.brand.brandId + "]\n\nTEA PRODUCT and FLAVOR:   " + storedGoodToUpdate.finishedGood.orderItem.teaProduct.teaProductName + " (" + storedGoodToUpdate.finishedGood.orderItem.teaProduct.teaProductflavor + ") [" + storedGoodToUpdate.finishedGood.orderItem.teaProduct.teaProductserialNo + "]\nTEABAG TYPE and MATERIAL:    " + storedGoodToUpdate.finishedGood.orderItem.teabagMaterial.materialName + " (" + storedGoodToUpdate.finishedGood.orderItem.teabagMaterial.teabagType + ") [" + storedGoodToUpdate.finishedGood.orderItem.teabagMaterial.materialSerialNo + "]\n\nCONTENTS and PACKAGING:    " + "[" + storedGoodToUpdate.finishedGood.orderItem.orderItemContent.teabagWeight + "g] x [" + storedGoodToUpdate.finishedGood.orderItem.orderItemContent.teabagQuantity + "] x [" + storedGoodToUpdate.finishedGood.orderItem.orderItemContent.icQuantity + "]\nMASTER CARTON WEIGHT:    " + storedGoodToUpdate.finishedGood.fg_mc_weight + " KG\n\nSHIPPING LOCATION:    " + storedGoodToUpdate.finishedGood.orderItem.shippingDetails.location + "\nLOADING DATE:    " + (storedGoodToUpdate.finishedGood.orderItem.shippingSchedule.loading_date == DateTime.MinValue ? "N/A" : storedGoodToUpdate.finishedGood.orderItem.shippingSchedule.loading_date.ToString()) + "\nMANUFACTURED DATE:    " + storedGoodToUpdate.finishedGood.fg_added_date.ToString() + "\nEXPIRY DATE:    " + storedGoodToUpdate.finishedGood.fg_exp_date.ToString() + "\nLOADING DATE:    " + (storedGoodToUpdate.finishedGood.orderItem.shippingSchedule.loading_date == DateTime.MinValue ? "N/A" : storedGoodToUpdate.finishedGood.orderItem.shippingSchedule.loading_date.ToString());
                
                //selecting location
                foreach(Location location in locations)
                {
                    if(string.Equals(storedGoodToUpdate.sg_location_id, location.location_id, StringComparison.InvariantCultureIgnoreCase))
                    {
                        comboBoxMLocation.SelectedItem = (location.location_id + " " + location.location_name);
                    }
                }
            }
        }

        public void loadFinishedGoods()
        {
            try
            {
                finishedGoods = storeDBHandler.getAllCompletedMasterCartons();
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
            comboBoxMLocation.Items.Clear();
            comboBoxMLocation.Text = "";
            try
            {
                locations = storeDBHandler.getAllLocations();

                foreach (Location location in locations)
                {
                    comboBoxMLocation.Items.Add(location.location_id + " " + location.location_name);
                    comboBoxQRLocation.Items.Add(location.location_id + " " + location.location_name);
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

        private void btnMAdd_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);

            //front-end validation
            if (string.IsNullOrEmpty(textBoxMOrderItemNo.Text) || string.IsNullOrEmpty(textBoxMMCNo.Text) || isValidMC == false || selectedMC == null)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please make sure the entered Order Item Number and MC Number are valid.", NotificationStates.WARNING);
                return;
            }

            String selectedLocationId = null;

            if (string.IsNullOrEmpty(comboBoxMLocation.Text) || string.IsNullOrWhiteSpace(comboBoxMLocation.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please select a valid Location", NotificationStates.WARNING);
                return;
            }
            else
            {
                foreach (Location location in locations)
                {
                    if (string.Equals(comboBoxMLocation.Text, location.location_id + " " + location.location_name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedLocationId = location.location_id;
                    }
                }
            }

            try
            {
                if (this.childType == ChildFormType.ADD)
                {
                    storedGoodToAdd = new StoredGood(textBoxMOrderItemNo.Text, textBoxMMCNo.Text, selectedLocationId, SessionManager.user.employeeId, DateTime.Now, null, DateTime.MinValue, "In Storage", "N/A");

                    if (storeDBHandler.addMCToStorage(storedGoodToAdd) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Master Carton was Added to the Storage Successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }
                else if (this.childType == ChildFormType.UPDATE)
                {
                    storedGoodToAdd = new StoredGood(storedGoodToUpdate.sg_orderitem_no, storedGoodToUpdate.sg_mc_no, selectedLocationId, storedGoodToUpdate.sg_stored_by, storedGoodToUpdate.sg_stored_date, storedGoodToUpdate.sg_issued_by, storedGoodToUpdate.sg_issued_date, storedGoodToUpdate.sg_status, storedGoodToUpdate.sg_remarks);
                    storedGoodToAdd.finishedGood = storedGoodToUpdate.finishedGood;

                    if (storeDBHandler.updateStoredMasterCarton(storedGoodToAdd) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Master Carton was Updated Successfully.", NotificationStates.SUCCESS);
                        storedGoodToUpdate = storedGoodToAdd;
                        resetForm();
                    }
                }


                if (FormHandler.parentFormName.Trim() == "ManageStorage")
                {
                    ManageStorage parentForm = (ManageStorage)FormHandler.parentForm;
                    parentForm.loadStoredGoods();
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
            textBoxMOrderItemNo.Text = "10-20-0009/006";
            textBoxMMCNo.Text = "8";
            comboBoxMLocation.SelectedIndex = 0;
        }
    }
}
