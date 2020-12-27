using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Utilities;
using System;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class AddDepartments : Form
    {
        Department deptToAdd = null;
        Department deptToUpdate = null;
        DeptDBHandler deptDBHandler = new DeptDBHandler();
        ChildFormType childType;

        public AddDepartments()
        {
            InitializeComponent();
            this.childType = FormHandler.childFormType;

            if (this.childType == ChildFormType.UPDATE)
            {
                deptToUpdate = (Department)FormHandler.newObject;
                this.Text = "Update Department";
                this.btnSave.Text = "Update Department";
                this.lblTitle.Text = "Update " + deptToUpdate.dept_id;
                this.lblDescription.Text = "Please Fill the required fields in order to update the selected department.";
                this.deptName.Text = deptToUpdate.dept_name;
                this.deptContact.Text = deptToUpdate.contact_no;
                this.deptMail.Text = deptToUpdate.email;
                this.deptDesc.Text = deptToUpdate.description;
            }
        }

        private void AddDepartments_Load(object sender, EventArgs e)
        {
            panelInAppNotifications.Visible = false;
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            panelInAppNotifications.Hide();
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
            if (string.IsNullOrEmpty(deptName.Text) || string.IsNullOrEmpty(deptContact.Text) || string.IsNullOrEmpty(deptMail.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications,lableInAppNotification,pbInAppNotification, btnCloseInAppNotification, "Please fill all required fields.", NotificationStates.WARNING);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(deptName.Text) || string.IsNullOrWhiteSpace(deptContact.Text) || string.IsNullOrWhiteSpace(deptMail.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Input fields cannot contain only spaces.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsValidInternationalContactNumber(deptContact.Text) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please enter a valid contact number.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsValidEmail(deptMail.Text) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please enter a valid email address.", NotificationStates.WARNING);
                return;
            }

            try
            {
                if(this.childType == ChildFormType.ADD)
                {
                    deptToAdd = new Department(deptName.Text, deptDesc.Text, deptContact.Text, deptMail.Text);
                    //add department
                    if (deptDBHandler.addDepartment(deptToAdd) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Department Added Successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }
                else if (this.childType == ChildFormType.UPDATE)
                {
                    deptToAdd = new Department(deptToUpdate.dept_id, deptName.Text, deptDesc.Text, deptContact.Text, deptMail.Text);
                    //update department
                    if (deptDBHandler.updateDepartment(deptToAdd) == true)
                    {
                        deptToUpdate = deptToAdd;
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Department Details Updated Successfully.", NotificationStates.SUCCESS);
                        resetForm();

                        //update profile if updated user is the currently logged in user
                        if (SessionManager.user.departmentId == deptToUpdate.dept_id)
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


                if (FormHandler.parentFormName.Trim() == "ManageDepts")
                {
                    ManageDepts parentForm = (ManageDepts)FormHandler.parentForm;
                    parentForm.loadDepartments();
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
            if(this.childType == ChildFormType.ADD)
            {
                deptName.Text = "";
                deptContact.Text = "";
                deptMail.Text = "";
                deptDesc.Text = "";
                deptToAdd = null;
            } 
            else
            {
                deptName.Text = deptToUpdate.dept_name;
                deptContact.Text = deptToUpdate.contact_no;
                deptMail.Text = deptToUpdate.email;
                deptDesc.Text = deptToUpdate.description;
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            deptName.Text = "Marketing Department";
            deptContact.Text = "+94110110113";
            deptMail.Text = "marketing@jb.lk";
            deptDesc.Text = "This is the Marketing Department og Jafferjee Brothers Tea Division.";
        }
    }
}
