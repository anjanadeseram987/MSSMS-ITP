using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class AddDesignations : Form
    {
        Designation desigToAdd = null;
        Designation desigToUpdate = null;
        List<Department> availableDepartments = new List<Department>();
        DesigDBHandler desigDBHandler = new DesigDBHandler();
        ChildFormType childType;

        public AddDesignations()
        {
            InitializeComponent();
            this.childType = FormHandler.childFormType;

            if (this.childType == ChildFormType.UPDATE)
            {
                desigToUpdate = (Designation)FormHandler.newObject;
                this.Text = "Update Designation";
                this.btnSave.Text = "Update Designation";
                this.lblTitle.Text = "Update " + desigToUpdate.desig_id;
                this.lblDescription.Text = "Please Fill the required fields in order to update the selected designation.";
                this.textBoxDesig.Text = desigToUpdate.desig_name;
                this.textBoxDescription.Text = desigToUpdate.description;
            }

            getAllDepartments();
        }

        private void AddDesignations_Load(object sender, EventArgs e)
        {
            panelInAppNotifications.Visible = false;
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            panelInAppNotifications.Hide();
        }

        //get available departments
        private void getAllDepartments()
        {
            try
            {
                availableDepartments = desigDBHandler.getAvailableDepartments();
                //select the correct dept details
                selectAssignedDepartmentName();
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);

            //front-end validation
            if (string.IsNullOrEmpty(textBoxDesig.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please fill all required fields.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxDesig.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Designation cannot contain only spaces.", NotificationStates.WARNING);
                return;
            }

            if(comboBoxDept.SelectedIndex < 0)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Designation cannot be empty.", NotificationStates.WARNING);
                return;
            }

            try
            {
                //get combobox dept id
                string selectedDeptId = null;
                foreach(Department dept in availableDepartments)
                {
                    if (comboBoxDept.SelectedItem.ToString() == dept.dept_name)
                    {
                        selectedDeptId = dept.dept_id;
                    }
                }

                if (this.childType == ChildFormType.ADD)
                {
                    desigToAdd = new Designation(textBoxDesig.Text, textBoxDescription.Text, selectedDeptId);
                    
                    //add new designation
                    if (desigDBHandler.addDesignation(desigToAdd) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Designation Added Successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }
                else if (this.childType == ChildFormType.UPDATE)
                {
                    desigToAdd = new Designation(desigToUpdate.desig_id, textBoxDesig.Text, textBoxDescription.Text, selectedDeptId.ToString(),1);
                    //update department
                    if (desigDBHandler.updateDesignation(desigToAdd) == true)
                    {
                        desigToUpdate = desigToAdd;
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Designation Details Updated Successfully.", NotificationStates.SUCCESS);
                        resetForm();

                        //update profile if updated user is the currently logged in user
                        if (SessionManager.user.designationId == desigToUpdate.desig_id)
                        {
                            UserAccountDBHandler userAccountDBHandler = new UserAccountDBHandler();
                            SessionManager.user = userAccountDBHandler.getUserAccountDetailsById(SessionManager.user.employeeId);

                            //refresh main interface
                            switch (SessionManager.userInterface)
                            {
                                case UserInterface.ADMIN:
                                    AdminLobby adminLobby = (AdminLobby)SessionManager.currentLobby;
                                    adminLobby.refreshSessionInfo();
                                    break;
                                case UserInterface.HRMANAGER:
                                    HRLobby hRLobby = (HRLobby)SessionManager.currentLobby;
                                    hRLobby.refreshSessionInfo();
                                    break;
                                case UserInterface.ENGINEER:
                                    MaintenanceLobby maintenanceLobby = (MaintenanceLobby)SessionManager.currentLobby;
                                    maintenanceLobby.refreshSessionInfo();
                                    break;
                                case UserInterface.FGOPERATOR:
                                    ManufactLobby manufactLobby = (ManufactLobby)SessionManager.currentLobby;
                                    manufactLobby.refreshSessionInfo();
                                    break;
                                case UserInterface.GENERALMANAGER:
                                    MgmtLobby mgmtLobby = (MgmtLobby)SessionManager.currentLobby;
                                    mgmtLobby.refreshSessionInfo();
                                    break;
                                case UserInterface.PRODUCTIONMANAGER:
                                    ProductionLobby productionLobby = (ProductionLobby)SessionManager.currentLobby;
                                    productionLobby.refreshSessionInfo();
                                    break;
                                case UserInterface.SHIPPINGMANAGER:
                                    ShipLobby shipLobby = (ShipLobby)SessionManager.currentLobby;
                                    shipLobby.refreshSessionInfo();
                                    break;
                                case UserInterface.STOREKEEPER:
                                    StoreLobby storeLobby = (StoreLobby)SessionManager.currentLobby;
                                    storeLobby.refreshSessionInfo();
                                    break;
                                default:
                                    //do nothing, this case does not exist
                                    break;
                            }
                        }
                    }
                }

                if (FormHandler.parentFormName.Trim() == "ManageDesigs")
                {
                    ManageDesigs parentForm = (ManageDesigs)FormHandler.parentForm;
                    parentForm.panelInAppNotifications.Visible = false;
                    parentForm.loadDesignations();
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
            comboBoxDept.Items.Clear();

            if (this.childType == ChildFormType.ADD)
            {
                textBoxDesig.Text = "";
                textBoxDescription.Text = "";
                selectAssignedDepartmentName();
            }
            else
            {
                textBoxDesig.Text = desigToUpdate.desig_name;
                textBoxDescription.Text = desigToUpdate.description;
                selectAssignedDepartmentName();
            }
        }

        private void selectAssignedDepartmentName()
        {
            comboBoxDept.Items.Clear();

            foreach (Department dept in availableDepartments)
            {
                comboBoxDept.Items.Add(dept.dept_name);

                if (this.desigToUpdate != null && desigToUpdate.dept_id == dept.dept_id)
                {
                    comboBoxDept.SelectedItem = dept.dept_name;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Form Resetted.", NotificationStates.SUCCESS);
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            textBoxDesig.Text = "Senior Production Manager";
            textBoxDescription.Text = "Senior Production Manager oversees the entire production process at JB.";
            comboBoxDept.SelectedItem = "Production Department";
        }
    }
}
