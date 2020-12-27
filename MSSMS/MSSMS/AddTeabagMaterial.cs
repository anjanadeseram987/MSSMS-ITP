using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Utilities;
using System;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class AddTeabagMaterial : Form
    {
        TeabagMaterial teabagMaterialToAdd = null;
        TeabagMaterial teabagMaterialToUpdate = null;
        TeaProductDBHandler teaProductDBHandler = new TeaProductDBHandler();
        ChildFormType childType;

        public AddTeabagMaterial()
        {
            InitializeComponent();
            this.childType = FormHandler.childFormType;
            if (this.childType == ChildFormType.UPDATE)
            {
                teabagMaterialToUpdate = (TeabagMaterial)FormHandler.newObject;
            }
            resetForm();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void AddTeabagMaterial_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);

            //validate
            if (string.IsNullOrWhiteSpace(textBoxSerial.Text) || string.IsNullOrWhiteSpace(textBoxSerial.Text) || string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Required fields cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (comboBoxAvailability.SelectedItem == null)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "The Availability status of the teabag material must be assigned.", NotificationStates.WARNING);
                return;
            }

            //save
            try
            {
                if (this.childType == ChildFormType.ADD)
                {
                    teabagMaterialToAdd = new TeabagMaterial(textBoxName.Text, textBoxType.Text, textBoxSerial.Text, textBoxDescription.Text, comboBoxAvailability.SelectedItem.ToString());

                    //add new teabag material
                    if (teaProductDBHandler.addTeabagMaterial(teabagMaterialToAdd) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Teabag Material Added Successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }
                else if (this.childType == ChildFormType.UPDATE)
                {
                    teabagMaterialToAdd = new TeabagMaterial(teabagMaterialToUpdate.materialId, textBoxName.Text, textBoxType.Text, textBoxSerial.Text, textBoxDescription.Text, comboBoxAvailability.SelectedItem.ToString());
                    //update teabag material
                    if (teaProductDBHandler.updateTeabagMaterial(teabagMaterialToAdd) == true)
                    {
                        teabagMaterialToUpdate = teabagMaterialToAdd;
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Teabag Material Details Updated Successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }

                if (FormHandler.parentFormName.Trim() == "ManageTeabags")
                {
                    ManageTeabags parentForm = (ManageTeabags)FormHandler.parentForm;
                    parentForm.panelInAppNotifications.Visible = false;
                    parentForm.loadTeabagMaterials();
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Form Resetted.", NotificationStates.SUCCESS);
        }

        private void resetForm()
        {
            if (this.childType == ChildFormType.UPDATE)
            {
                this.Text = "Update Teabag Material";
                this.btnSave.Text = "Update &Material";
                this.lblTitle.Text = "UPDATE " + teabagMaterialToUpdate.materialId.ToUpper();
                this.lblDescription.Text = "Please Fill the required fields in order to update the selected Teabag Material.";
                this.textBoxSerial.Text = teabagMaterialToUpdate.materialSerialNo;
                this.textBoxType.Text = teabagMaterialToUpdate.teabagType;
                this.textBoxName.Text = teabagMaterialToUpdate.materialName;
                this.textBoxDescription.Text = teabagMaterialToUpdate.materialDescription;
                this.comboBoxAvailability.SelectedItem = teabagMaterialToUpdate.materialAvailability;
            }
            else
            {
                this.textBoxSerial.Clear();
                this.textBoxType.Clear();
                this.textBoxName.Clear();
                this.textBoxDescription.Clear();
                comboBoxAvailability.SelectedItem = null;
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            this.textBoxSerial.Text = "PB600";
            this.textBoxType.Text = "Square Shaped High Quality";
            this.textBoxName.Text = "Paper Envilops 80% Thick";
            this.textBoxDescription.Text = "80% Thick Black Paper Envilop Material for Teabags. 95% in Quality Scale with 5 ratings. only for JafTea related Tea Products.";
            comboBoxAvailability.SelectedIndex = 0;
        }
    }
}
