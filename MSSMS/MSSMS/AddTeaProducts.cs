using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Utilities;
using System;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class AddTeaProducts : Form
    {
        TeaProduct teaProductToAdd = null;
        TeaProduct teaProductToUpdate = null;
        TeaProductDBHandler teaProductDBHandler = new TeaProductDBHandler();
        ChildFormType childType;

        public AddTeaProducts()
        {
            InitializeComponent();
            this.childType = FormHandler.childFormType;
            if (this.childType == ChildFormType.UPDATE)
            {
                teaProductToUpdate = (TeaProduct)FormHandler.newObject;
            }
            resetForm();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void AddTeaProducts_Load(object sender, EventArgs e)
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
            
            //validate
            if (string.IsNullOrWhiteSpace(textBoxSerial.Text) || string.IsNullOrWhiteSpace(textBoxSerial.Text) || string.IsNullOrWhiteSpace(textBoxFlavor.Text) || string.IsNullOrWhiteSpace(textBoxFlavor.Text) || string.IsNullOrWhiteSpace(textBoxType.Text) || string.IsNullOrWhiteSpace(textBoxType.Text) || comboBoxAvailability.SelectedItem == null)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Required fields cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (comboBoxAvailability.SelectedItem == null)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "The Availability status of the tea product must be assigned.", NotificationStates.WARNING);
                return;
            }

            //save
            try
            {
                if (this.childType == ChildFormType.ADD)
                {
                    teaProductToAdd = new TeaProduct(textBoxType.Text, textBoxFlavor.Text, textBoxSerial.Text, textBoxDescription.Text, comboBoxAvailability.SelectedItem.ToString());

                    //add new tea product
                    if (teaProductDBHandler.addTeaProduct(teaProductToAdd) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Tea Product Added Successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }
                else if (this.childType == ChildFormType.UPDATE)
                {
                    teaProductToAdd = new TeaProduct(teaProductToUpdate.teaProductId, textBoxType.Text, textBoxFlavor.Text, textBoxSerial.Text, textBoxDescription.Text, comboBoxAvailability.SelectedItem.ToString());
                    //update tea product
                    if (teaProductDBHandler.updateTeaProduct(teaProductToAdd) == true)
                    {
                        teaProductToUpdate = teaProductToAdd;
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Tea Product Details Updated Successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }

                if (FormHandler.parentFormName.Trim() == "ManageTeaProducts")
                {
                    ManageTeaProducts parentForm = (ManageTeaProducts)FormHandler.parentForm;
                    parentForm.panelInAppNotifications.Visible = false;
                    parentForm.loadTeaProducts();
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

        private void resetForm()
        {
            if (this.childType == ChildFormType.UPDATE)
            {
                this.Text = "Update Tea Product Details";
                this.btnSave.Text = "Update &Product";
                this.lblTitle.Text = "UPDATE " + teaProductToUpdate.teaProductId.ToUpper();
                this.lblDescription.Text = "Please Fill the required fields in order to update the selected Tea Product.";
                this.textBoxSerial.Text = teaProductToUpdate.teaProductserialNo;
                this.textBoxFlavor.Text = teaProductToUpdate.teaProductflavor;
                this.textBoxType.Text = teaProductToUpdate.teaProductName;
                this.textBoxDescription.Text = teaProductToUpdate.teaProductdescription;
                this.comboBoxAvailability.SelectedItem = teaProductToUpdate.teaProductavailability;
            }
            else
            {
                this.textBoxSerial.Clear();
                this.textBoxFlavor.Clear();
                this.textBoxType.Clear();
                this.textBoxDescription.Clear();
                comboBoxAvailability.SelectedItem = null;
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            this.textBoxSerial.Text = "BT600";
            this.textBoxFlavor.Text = "Black Tea";
            this.textBoxType.Text = "Pure Ceylon Black Tea";
            this.textBoxDescription.Text = "100% Pure Ceylon Tea, a type of genuine black tea. Locations: Lulkandura, Bandarawela, Belihuloya.";
            comboBoxAvailability.SelectedIndex = 0;
        }
    }
}
