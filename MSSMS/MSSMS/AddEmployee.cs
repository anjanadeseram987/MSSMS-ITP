using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Utilities;
using System;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class AddEmployee : Form
    {
        Employee employeeToAdd = null;
        Employee employeeToUpdate = null;
        DeptDesig availableDeptDesignations = null;
        String selectedDeptId = null;
        String selectedDesigId = null;
        EmployeeDBHandler employeeDBHandler = new EmployeeDBHandler();
        UserAccountDBHandler userAccountDBHandler = null;
        ChildFormType childType;

        public AddEmployee()
        {
            InitializeComponent();
            this.childType = FormHandler.childFormType;

            if (this.childType == ChildFormType.UPDATE)
            {
                employeeToUpdate = (Employee)FormHandler.newObject;
            }

            getAllDeptDesigs();
            resetForm();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            panelInAppNotifications.Visible = false;
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            panelInAppNotifications.Hide();
        }

        //get available designations and depts
        private void getAllDeptDesigs()
        {
            try
            {
                availableDeptDesignations = employeeDBHandler.getAvailableDesignations();
                //select the correct dept details
                selectAssignedDeptDesignation();
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
        }

        private void selectAssignedDeptDesignation()
        {
            comboBoxDepartment.Items.Clear();
            comboBoxDesignation.Items.Clear();

            foreach(Designation desig in availableDeptDesignations.designations)
            {
                comboBoxDesignation.Items.Add(desig.desig_name);

                if (this.employeeToUpdate != null && employeeToUpdate.designationId == desig.desig_id)
                {
                    comboBoxDesignation.SelectedItem = desig.desig_name;
                    this.selectedDeptId = desig.dept_id;
                }

            }

            foreach (Department dept in availableDeptDesignations.departments)
            {
                comboBoxDepartment.Items.Add(dept.dept_name);

                if (this.employeeToUpdate != null && selectedDeptId == dept.dept_id)
                {
                    comboBoxDepartment.SelectedItem = dept.dept_name;
                }
            }
        }

        private void comboBoxDepartment_SelectedValueChanged(object sender, EventArgs e)
        {
            string dept_id = null;

            comboBoxDesignation.Items.Clear();
            foreach (Department dept in availableDeptDesignations.departments)
            {
                if (comboBoxDepartment.SelectedItem.ToString() == dept.dept_name)
                {
                    dept_id = dept.dept_id;
                    break;
                }
            }

            foreach (Designation desig in availableDeptDesignations.designations)
            {
                if(desig.dept_id == dept_id)
                {
                    comboBoxDesignation.Items.Add(desig.desig_name);
                }
                if (employeeToUpdate != null)
                {
                    if (desig.desig_id == employeeToUpdate.designationId)
                    {
                        comboBoxDesignation.SelectedItem = desig.desig_name;
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Form Resetted.", NotificationStates.SUCCESS);
        }

        private void resetForm()
        {
            comboBoxDepartment.Items.Clear();
            comboBoxDesignation.Items.Clear();
            comboBoxGender.Items.Clear();
            selectAssignedDeptDesignation();

            if (this.childType == ChildFormType.ADD)
            {
                this.Text = "Add Employee";
                this.btnSave.Text = "Add Employee";
                this.lblTitle.Text = "ADD NEW EMPLOYEE";
                this.lblDescription.Text = "Please Fill the required fields in order to add a new Employee to the System.";
                this.textBoxFirstName.Clear();
                this.textBoxLastName.Clear();
                this.textBoxFullName.Clear();
                this.textBoxPhone.Clear();
                this.textBoxEmail.Clear();
                this.textBoxEID.Clear();
                this.dateTimePickerBirthday.Value = DateTime.Now.Date;
                this.dateTimePickerDateRecruited.Value = DateTime.Now.Date;
                comboBoxGender.Items.Add("Male");
                comboBoxGender.Items.Add("Female");
                comboBoxGender.Items.Add("Other");
                comboBoxGender.SelectedItem = "\0";
                textBoxEID.Visible = false;
                labelEID.Visible = false;
            }
            else
            {
                this.Text = "Update Employee Details";
                this.btnSave.Text = "Update Employee";
                this.lblTitle.Text = "UPDATE " + employeeToUpdate.employeeId.ToUpper();
                this.lblDescription.Text = "Please Fill the required fields in order to update the selected Employee.";
                this.textBoxFirstName.Text = employeeToUpdate.firstName;
                this.textBoxLastName.Text = employeeToUpdate.lastName;
                this.textBoxFullName.Text = employeeToUpdate.fullName;
                this.dateTimePickerBirthday.Value = employeeToUpdate.birthday;
                this.dateTimePickerDateRecruited.Value = employeeToUpdate.dateRecruited;

                comboBoxGender.Items.Add("Male");
                comboBoxGender.Items.Add("Female");
                comboBoxGender.Items.Add("Other");

                switch (employeeToUpdate.gender)
                {
                    case "M":
                    case "Male":
                        comboBoxGender.SelectedItem = "Male";
                        break;
                    case "F":
                    case "Female":
                        comboBoxGender.SelectedItem = "Female";
                        break;
                    case "N/A":
                    case "O":
                    case "Other":
                        comboBoxGender.SelectedItem = "Other";
                        break;
                    default:
                        break;
                }

                this.textBoxPhone.Text = employeeToUpdate.primaryPhone;
                this.textBoxEmail.Text = employeeToUpdate.primaryEmail;
                this.textBoxEID.Text = employeeToUpdate.employeeId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);

            //front-end validation
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text) || string.IsNullOrWhiteSpace(textBoxFirstName.Text) || string.IsNullOrWhiteSpace(textBoxLastName.Text) || string.IsNullOrWhiteSpace(textBoxLastName.Text) || string.IsNullOrWhiteSpace(textBoxFullName.Text) || string.IsNullOrWhiteSpace(textBoxFullName.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Name Fields cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsValidBirthday(dateTimePickerBirthday.Value) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid Birthday. An Employee should be at least " + Properties.Settings.Default.EmpMINAge.ToString() + " years old.", NotificationStates.WARNING);
                return;
            }

            if (comboBoxGender.SelectedItem == null)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Gender cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPhone.Text) || string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Contact Number cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.isValidLocalContactNumber(textBoxPhone.Text) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid phone number.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) || string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Email Address cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsValidEmail(textBoxEmail.Text) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid Email Address.", NotificationStates.WARNING);
                return;
            }

            if (comboBoxDepartment.SelectedItem == null)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Department cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (comboBoxDesignation.SelectedItem == null)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Designation cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (DateTime.Compare(dateTimePickerDateRecruited.Value, DateTime.Now) > 0)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid Date of Recruitment.", NotificationStates.WARNING);
                return;
            }

            if (this.childType == ChildFormType.UPDATE)
            {
                if (string.IsNullOrEmpty(textBoxEID.Text) || string.IsNullOrEmpty(textBoxEID.Text))
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Employee ID cannot be empty.", NotificationStates.WARNING);
                    return;
                }
            }

            try
            {
                //get combobox desig id
                selectedDesigId = null;
                foreach (Designation desig in availableDeptDesignations.designations)
                {
                    if (comboBoxDesignation.SelectedItem.ToString() == desig.desig_name)
                    {
                        selectedDesigId = desig.desig_id;
                    }
                }

                if (this.childType == ChildFormType.ADD)
                {
                    employeeToAdd = new Employee(textBoxFullName.Text, textBoxFirstName.Text,textBoxLastName.Text, dateTimePickerBirthday.Value, comboBoxGender.SelectedItem.ToString(), selectedDesigId, dateTimePickerDateRecruited.Value, textBoxEmail.Text, textBoxPhone.Text);

                    //add new employee
                    if (employeeDBHandler.addEmployee(employeeToAdd) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Employee Added Successfully.", NotificationStates.SUCCESS);
                        resetForm();
                    }
                }
                else if (this.childType == ChildFormType.UPDATE)
                {
                    employeeToAdd = new Employee(textBoxEID.Text, textBoxFullName.Text, textBoxFirstName.Text, textBoxLastName.Text, dateTimePickerBirthday.Value, comboBoxGender.SelectedItem.ToString(), selectedDesigId, dateTimePickerDateRecruited.Value, textBoxEmail.Text, textBoxPhone.Text);
                    //update employee
                    if (employeeDBHandler.updateEmployee(employeeToAdd) == true)
                    {
                        employeeToUpdate = employeeToAdd;
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Employee Details Updated Successfully.", NotificationStates.SUCCESS);
                        resetForm();

                        //update profile if updated user is the currently logged in user
                        if (SessionManager.user.employeeId == employeeToAdd.employeeId)
                        {
                            userAccountDBHandler = new UserAccountDBHandler();
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

                if (FormHandler.parentFormName.Trim() == "ManageEmployees")
                {
                    ManageEmployees parentForm = (ManageEmployees)FormHandler.parentForm;
                    parentForm.panelInAppNotifications.Visible = false;
                    parentForm.loadEmployees();
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

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Contact Number cannot contain spaces.", NotificationStates.WARNING);
            }
        }

        private void textBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Email Address cannot contain spaces.", NotificationStates.WARNING);
            }
        }

        private void comboBoxDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            string desig_name = comboBoxDesignation.SelectedItem.ToString();

            foreach (Designation desig in availableDeptDesignations.designations)
            {
                if (desig.desig_name == desig_name)
                {
                    comboBoxDepartment.SelectedItem = desig.dept_name;
                    comboBoxDesignation.SelectedItem = desig_name;
                }
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            this.textBoxFirstName.Text = "Achini";
            this.textBoxLastName.Text = "Rupasinghe";
            this.textBoxFullName.Text = "A. Rupasinghe";
            this.textBoxPhone.Text = "+94710710710";
            this.textBoxEmail.Text = "achinirupasinghe@gmail.com";
            this.dateTimePickerBirthday.Value = DateTime.Parse("1995-05-05");
            this.dateTimePickerDateRecruited.Value = DateTime.Parse("2020-05-05");
            comboBoxGender.SelectedItem = "Female";
            comboBoxDepartment.SelectedIndex = 0;
            comboBoxDesignation.SelectedIndex = 0;
        }
    }
}
