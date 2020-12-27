using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Properties;
using MSSMS.Utilities;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class AddUser : Form
    {

        private UserAccountDBHandler userAccountDBHandler = new UserAccountDBHandler();
        private EmployeeDBHandler employeeDBHandler = new EmployeeDBHandler();
        private UserAccount userAccountToAdd = null;
        private UserAccount userAccountToUpdate = null;
        private Employee currentEmployee = null;
        private ChildFormType childType;
        private bool isValidEmployee = false;
        private bool isValidUsername = false;
        string dpPath = null;
        Image dpImage = null;
        int dpFileSize;
        byte[] dpRawData;
        FileStream fs;

        public AddUser()
        {
            InitializeComponent();
            this.childType = FormHandler.childFormType;
            if (this.childType == ChildFormType.UPDATE)
            {
                userAccountToUpdate = (UserAccount)FormHandler.newObject;
            }
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            panelInAppNotifications.Visible = false;
            resetForm();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            panelInAppNotifications.Hide();
        }

        private void btnUpload_MouseHover(object sender, EventArgs e)
        {
            btnUpload.BackgroundImage = Resources.addGreenSq;
        }

        private void btnUpload_MouseLeave(object sender, EventArgs e)
        {
            btnUpload.BackgroundImage = Resources.addAshSq;
        }

        private void textBoxEID_TextChanged(object sender, EventArgs e)
        {
            string employeeID = textBoxEID.Text;

            if (String.IsNullOrWhiteSpace(employeeID) || String.IsNullOrEmpty(employeeID))
            {
                labelEID.Text = "Enter a valid Employee ID";
                pictureBoxEID.BackgroundImage = Resources.warnC;
            }
            else
            {
                if (this.childType == ChildFormType.ADD)
                {
                    if (userAccountDBHandler.isValidEmployeeID(employeeID) == true)
                    {
                        if (userAccountDBHandler.isUseraccountPresent(employeeID) == true)
                        {
                            labelEID.Text = "Employee already has a user account";
                            pictureBoxEID.BackgroundImage = Resources.closeC;
                            comboBoxUR.SelectedItem = "\0";
                            isValidEmployee = false;
                        }
                        else
                        {
                            currentEmployee = employeeDBHandler.getEmployeeById(employeeID);
                            labelEID.Text = "";
                            pictureBoxEID.BackgroundImage = Resources.tickC;
                            isValidEmployee = true;
                        }
                    }
                    else
                    {
                        labelEID.Text = "Employee is not found";
                        pictureBoxEID.BackgroundImage = Resources.closeC;
                        comboBoxUR.SelectedItem = "\0";
                        isValidEmployee = false;
                    }
                }
            }
        }

        private void textBoxUN_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxUN.Text) || String.IsNullOrEmpty(textBoxUN.Text))
            {
                labelUN.Text = "Enter a new Username.";
                pictureBoxUN.BackgroundImage = Resources.warnC;
            }
            else
            {
                string username = textBoxUN.Text;

                if (this.childType == ChildFormType.ADD)
                {
                    if (userAccountDBHandler.isUsernameTaken(username) == false)
                    {

                        labelUN.Text = "";
                        pictureBoxUN.BackgroundImage = Resources.tickC;
                        isValidUsername = true;
                    }
                    else
                    {
                        labelUN.Text = "Enter a different Username.";
                        pictureBoxUN.BackgroundImage = Resources.closeC;
                        isValidUsername = false;
                    }
                }

                if(this.childType == ChildFormType.UPDATE)
                {
                    if (userAccountDBHandler.isUsernameTakenExceptCurrentUser(username, userAccountToUpdate.employeeId) == false)
                    {
                        labelUN.Text = "";
                        pictureBoxUN.BackgroundImage = Resources.tickC;
                        isValidUsername = true;
                    }
                    else
                    {
                        labelUN.Text = "This username is already taken";
                        pictureBoxUN.BackgroundImage = Resources.closeC;
                        isValidUsername = false;
                    }
                }
            }
        }

        private void resetForm()
        {
            comboBoxUR.Items.Clear();
            comboBoxUR.Items.Add("Administrator");
            comboBoxUR.Items.Add("General Manager");
            comboBoxUR.Items.Add("Production Manager");
            comboBoxUR.Items.Add("Storekeeper");
            comboBoxUR.Items.Add("Shipping Manager");
            comboBoxUR.Items.Add("HR Manager");
            comboBoxUR.Items.Add("Engineer");
            comboBoxUR.Items.Add("Finished Goods Operator");
            comboBoxUR.Items.Add("Stored Goods Operator");
            comboBoxUR.Items.Add("Shipping Goods Operator");
            comboBoxUR.Items.Add("Employee");

            checkBoxChangePW.Checked = false;
            checkBoxPEM.Checked = false;
            labelEID.Text = "";
            pictureBoxEID.BackgroundImage = null;
            pictureBoxPWStatus.BackgroundImage = null;
            labelUN.Text = "";

            if (this.childType == ChildFormType.UPDATE)
            {
                this.Text = "Update User Account Details";
                this.btnSave.Text = "Update User";
                this.lblTitle.Text = "UPDATE " + userAccountToUpdate.employeeId.ToUpper();
                this.lblDescription.Text = "Please Fill the required fields in order to update the selected User Account.";
                this.textBoxEID.Text = userAccountToUpdate.employeeId;
                this.textBoxUN.Text = userAccountToUpdate.username;

                if (userAccountToUpdate.profilePicture != null)
                {
                    this.dp.BackgroundImage = ImageTools.getImageFromByteArray(userAccountToUpdate.profilePicture);
                }
                else
                {
                    this.dp.BackgroundImage = Resources.UserFlat;
                }

                this.textBoxNPW.ReadOnly = true;
                this.textBoxCPW.ReadOnly = true;
                this.textBoxEM.Text = userAccountToUpdate.secondaryEmail;

                labelAddSecInfo.Visible = false;
                checkBoxChangePW.Visible = true;
                this.textBoxEID.ReadOnly = true;
                labelEID.Visible = false;
                pictureBoxEID.Visible = false;
                labelUN.Visible = false;
                pictureBoxUN.Visible = true;

                switch (userAccountToUpdate.role.ToUpper())
                {
                    case "ADMIN":
                        comboBoxUR.SelectedItem = "Administrator";
                        break;
                    case "PRMGR":
                        comboBoxUR.SelectedItem = "Production Manager";
                        break;
                    case "GLMGR":
                        comboBoxUR.SelectedItem = "General Manager";
                        break;
                    case "HRMGR":
                        comboBoxUR.SelectedItem = "HR Manager";
                        break;
                    case "FGOPR":
                        comboBoxUR.SelectedItem = "Finished Goods Operator";
                        break;
                    case "SGOPR":
                        comboBoxUR.SelectedItem = "Stored Goods Operator";
                        break;
                    case "SHGOP":
                        comboBoxUR.SelectedItem = "Shipping Goods Operator";
                        break;
                    case "STKPR":
                        comboBoxUR.SelectedItem = "Storekeeper";
                        break;
                    case "SHMGR":
                        comboBoxUR.SelectedItem = "Shipping Manager";
                        break;
                    case "ENGNR":
                        comboBoxUR.SelectedItem = "Engineer";
                        break;
                    case "EMPLY":
                        comboBoxUR.SelectedItem = "Employee";
                        break;
                    default:
                        comboBoxUR.SelectedItem = "\0";
                        break;
                }

                if (userAccountToUpdate.secondaryEmail.ToLower() == userAccountToUpdate.primaryEmail.ToLower())
                {
                    checkBoxPEM.Checked = true;
                }

            }
            else
            {
                this.Text = "Create User Account";
                this.btnSave.Text = "Create Account";
                this.lblTitle.Text = "CREATE NEW USER ACCOUNT";
                this.lblDescription.Text = "Fill All the required feilds to add a new user to the system. ";
                this.textBoxEID.Text = "";
                this.textBoxUN.Text = "";
                this.textBoxNPW.ReadOnly = false;
                this.textBoxCPW.ReadOnly = false;
                this.textBoxNPW.Text = "";
                this.textBoxCPW.Text = "";
                this.textBoxEM.Text = "";
                this.comboBoxUR.SelectedItem = "\0";

                labelAddSecInfo.Visible = true;
                checkBoxChangePW.Visible = false;
                textBoxEID.ReadOnly = false;
                labelEID.Visible = true;
                labelEID.Text = "";
                pictureBoxEID.Visible = true;
                pictureBoxEID.BackgroundImage = null;
                labelUN.Visible = true;
                labelUN.Text ="";
                pictureBoxUN.Visible = true;
                pictureBoxUN.BackgroundImage = null;
                dp.BackgroundImage = Resources.UserFlat;                
            }
        }

        private void checkBoxPEM_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.childType == ChildFormType.ADD && currentEmployee != null)
            {
                if (checkBoxPEM.Checked == true)
                {
                    textBoxEM.Text = currentEmployee.primaryEmail;
                }
            }
            else if (this.childType==ChildFormType.UPDATE && userAccountToUpdate != null)
            {
                if (checkBoxPEM.Checked == true)
                {
                    textBoxEM.Text = userAccountToUpdate.primaryEmail;
                } 
                else
                {
                    if (string.IsNullOrEmpty(textBoxEM.Text) || string.IsNullOrWhiteSpace(textBoxEM.Text))
                    {
                        textBoxEM.Text = userAccountToUpdate.secondaryEmail;
                    }
                }
            }
            else
            {
                if (checkBoxPEM.Checked == true)
                {
                    checkBoxPEM.Checked = false;
                    textBoxEM.Text = "";
                    if (this.childType == ChildFormType.ADD)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please Enter a valid Employee ID first.", NotificationStates.WARNING);
                    }
                    else
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Could not retrieve the primary email address.", NotificationStates.ERROR);
                    }
                }
            }
        }

        private void checkBoxChangePW_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxChangePW.Checked == true)
            {
                this.textBoxNPW.ReadOnly = false;
                this.textBoxCPW.ReadOnly = false;
            }
            else
            {
                this.textBoxNPW.ReadOnly = true;
                this.textBoxCPW.ReadOnly = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Form resetted.", NotificationStates.SUCCESS);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);

            //validations
            if (string.IsNullOrWhiteSpace(textBoxEID.Text) || string.IsNullOrWhiteSpace(textBoxEID.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Employee ID cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxUN.Text) || string.IsNullOrWhiteSpace(textBoxUN.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Username cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (comboBoxUR.SelectedItem == null)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "A role must be assigned.", NotificationStates.WARNING);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxEM.Text) || string.IsNullOrWhiteSpace(textBoxEM.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Email Address cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsValidEmail(textBoxEM.Text) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid Email Address.", NotificationStates.ERROR);
                return;
            }

            if (this.childType == ChildFormType.ADD)
            {
                if (string.IsNullOrWhiteSpace(textBoxNPW.Text) || string.IsNullOrWhiteSpace(textBoxNPW.Text))
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Password cannot be empty.", NotificationStates.WARNING);
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBoxCPW.Text) || string.IsNullOrWhiteSpace(textBoxCPW.Text))
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Confirmation password cannot be empty.", NotificationStates.WARNING);
                    return;
                }

                if (ValidationHandler.IsValidPassword(textBoxNPW.Text.Trim(), textBoxCPW.Text.Trim()) == false)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Passwords do not match.", NotificationStates.ERROR);
                    return;
                }
            }

            if (this.childType == ChildFormType.UPDATE)
            {
                if (checkBoxChangePW.Checked == true)
                {
                    if (string.IsNullOrWhiteSpace(textBoxNPW.Text) || string.IsNullOrWhiteSpace(textBoxNPW.Text))
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "New Password cannot be empty.", NotificationStates.WARNING);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(textBoxCPW.Text) || string.IsNullOrWhiteSpace(textBoxCPW.Text))
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Confirmation password cannot be empty.", NotificationStates.WARNING);
                        return;
                    }

                    if (ValidationHandler.IsValidPassword(textBoxNPW.Text.Trim(), textBoxCPW.Text.Trim()) == false)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Passwords do not match.", NotificationStates.ERROR);
                        return;
                    }
                }
            }

            //getting combobox value
            string selectedRole = null;

            switch (comboBoxUR.SelectedItem.ToString())
            {
                case "Administrator":
                    selectedRole = "ADMIN";
                    break;
                case "Production Manager":
                    selectedRole = "PRMGR";
                    break;
                case "General Manager":
                    selectedRole = "GLMGR";
                    break;
                case "HR Manager":
                    selectedRole = "HRMGR";
                    break;
                case "Finished Goods Operator":
                    selectedRole = "FGOPR";
                    break;
                case "Stored Goods Operator":
                    selectedRole = "SGOPR";
                    break;
                case "Shipping Goods Operator":
                    selectedRole = "SHGOP";
                    break;
                case "Storekeeper":
                    selectedRole = "STKPR";
                    break;
                case "Shipping Manager":
                    selectedRole = "SHMGR";
                    break;
                case "Engineer":
                    selectedRole = "ENGNR";
                    break;
                case "Employee":
                    selectedRole = "EMPLY";
                    break;
                default:
                    selectedRole = "EMPLY";
                    break;
            }

            //getting the display picture
            //dpRawData = ImageTools.getByteArrayFromImage(dp.BackgroundImage);
            ImageConverter imageConverter = new ImageConverter();
            dpRawData = (byte[]) imageConverter.ConvertTo(this.dp.BackgroundImage, Type.GetType("System.Byte[]"));

            //save
            try
            {
                if (this.childType == ChildFormType.ADD)
                {
                    if (isValidEmployee == true && isValidUsername == true)
                    {
                        userAccountToAdd = new UserAccount(textBoxEID.Text, textBoxUN.Text, textBoxCPW.Text, textBoxEM.Text, dpRawData, "AUTH", SessionManager.user.employeeId, selectedRole);

                        if (userAccountDBHandler.addUserAccount(userAccountToAdd) == true)
                        {
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "User Account created Successfully.", NotificationStates.SUCCESS);
                            resetForm();
                        }
                    }
                    else
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Could not create the User Account", NotificationStates.ERROR);
                        return;
                    }
                }
                else if (this.childType == ChildFormType.UPDATE)
                {
                    if (isValidUsername == true) {
                        if (checkBoxChangePW.Checked == true)
                        {
                            userAccountToAdd = new UserAccount(userAccountToUpdate.employeeId,userAccountToUpdate.firstName,userAccountToUpdate.lastName,userAccountToUpdate.fullName,userAccountToUpdate.gender, userAccountToUpdate.birthday,userAccountToUpdate.primaryEmail, textBoxEM.Text, userAccountToUpdate.primaryPhone, textBoxUN.Text, selectedRole, userAccountToUpdate.authorizationStatus, userAccountToUpdate.authorizedBy, dpRawData, userAccountToUpdate.departmentName, userAccountToUpdate.designationName, userAccountToUpdate.departmentId, userAccountToUpdate.designationId, textBoxCPW.Text);
                            
                            //update useraccount
                            if (userAccountDBHandler.updateUserAccount(userAccountToAdd, userAccountToUpdate.role) == true)
                            {
                                userAccountToUpdate = userAccountToAdd;
                                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "User Account Details Updated Successfully.", NotificationStates.SUCCESS);
                                resetForm();

                                //update profile if updated user is the currently logged in user
                                updateCurrentUserInfo();
                            }
                        } 
                        else if(checkBoxChangePW.Checked == false)
                        {
                            userAccountToAdd = new UserAccount(userAccountToUpdate.employeeId, userAccountToUpdate.firstName, userAccountToUpdate.lastName, userAccountToUpdate.fullName, userAccountToUpdate.gender, userAccountToUpdate.birthday, userAccountToUpdate.primaryEmail, textBoxEM.Text, userAccountToUpdate.primaryPhone, textBoxUN.Text, selectedRole, userAccountToUpdate.authorizationStatus, userAccountToUpdate.authorizedBy, dpRawData, userAccountToUpdate.departmentName, userAccountToUpdate.designationName, userAccountToUpdate.departmentId, userAccountToUpdate.designationId);

                            //update useraccount
                            if (userAccountDBHandler.updateUserAccountWithoutPassword(userAccountToAdd, userAccountToUpdate.role) == true)
                            {
                                userAccountToUpdate = userAccountToAdd;
                                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "User Account Details Updated Successfully.", NotificationStates.SUCCESS);
                                resetForm();

                                //update profile if updated user is the currently logged in user
                                updateCurrentUserInfo();
                            }
                        }
                    }
                    else
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Could not update the User Account", NotificationStates.ERROR);
                        return;
                    }
                }

                //updating the parent
                if (FormHandler.parentFormName.Trim() == "ManageUsers")
                {
                    ManageUsers parentForm = (ManageUsers)FormHandler.parentForm;
                    parentForm.panelInAppNotifications.Visible = false;
                    parentForm.loadUsers();
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

        private void updateCurrentUserInfo()
        {
            if (SessionManager.user.employeeId == userAccountToAdd.employeeId)
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
        
        private void peakPasswords_MouseUp(object sender, MouseEventArgs e)
        { 
            textBoxNPW.PasswordChar = '●';
            textBoxCPW.PasswordChar = '●';
        }

        private void peakPasswords_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxNPW.PasswordChar = '\0';
            textBoxCPW.PasswordChar = '\0';
        }

        private void textBoxCPW_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCPW.Text) || string.IsNullOrWhiteSpace(textBoxCPW.Text))
            {
                pictureBoxPWStatus.Visible = false;
            }
            else
            {
                pictureBoxPWStatus.Visible = true;

                if (ValidationHandler.IsValidPassword(textBoxNPW.Text, textBoxCPW.Text))
                {
                    pictureBoxPWStatus.BackgroundImage = Resources.tickC;
                }
                else
                {
                    pictureBoxPWStatus.BackgroundImage = Resources.closeC;
                }
            }
        }

        private void textBoxNPW_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCPW.Text) || string.IsNullOrWhiteSpace(textBoxCPW.Text))
            {
                pictureBoxPWStatus.Visible = false;
            }
            else
            {
                pictureBoxPWStatus.Visible = true;

                if (ValidationHandler.IsValidPassword(textBoxNPW.Text, textBoxCPW.Text))
                {
                    pictureBoxPWStatus.BackgroundImage = Resources.tickC;
                }
                else
                {
                    pictureBoxPWStatus.BackgroundImage = Resources.closeC;
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Images(*.BMP; *.JPG; *.PNG)| *.BMP; *.JPG; *.PNG" , ValidateNames=true, Multiselect = false })
            {
                DialogResult dialogResult = openFileDialog.ShowDialog();
                if(dialogResult == DialogResult.OK)
                {
                    dpPath = openFileDialog.FileName;
                    dpImage = Image.FromFile(dpPath);
                    fs = new FileStream(dpPath, FileMode.Open, FileAccess.Read);
                    dpFileSize = (int)fs.Length;

                    dpRawData = new byte[dpFileSize];
                    fs.Read(dpRawData, 0, dpFileSize);
                    fs.Close();

                    dp.BackgroundImage = ImageTools.getSqureSizedImage(dpImage);
                } else
                {
                    if(this.childType == ChildFormType.UPDATE)
                    {
                        dp.BackgroundImage = ImageTools.getImageFromByteArray(userAccountToUpdate.profilePicture);
                    }
                    else
                    {
                        dp.BackgroundImage = Resources.UserFlat;
                    }
                }
            }
        }

        private void textBoxEM_TextChanged(object sender, EventArgs e)
        {
            if (this.childType == ChildFormType.ADD && currentEmployee != null)
            {
                if (textBoxEM.Text != currentEmployee.primaryEmail)
                {
                    checkBoxPEM.Checked = false;
                }
                else
                {
                    checkBoxPEM.Checked = true;
                }
            }
            else if (this.childType == ChildFormType.UPDATE)
            {
                if (textBoxEM.Text == userAccountToUpdate.primaryEmail)
                {
                    checkBoxPEM.Checked = true;
                }
                else
                {
                    checkBoxPEM.Checked = false;
                }
            }
            else
            {
                checkBoxPEM.Checked = false;
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            this.textBoxEID.Text = "E2000011";
            this.textBoxUN.Text = "Johndoe24";
            this.textBoxNPW.Text = "test";
            this.textBoxCPW.Text = "test";
            this.textBoxEM.Text = "johndoe@jb.lk";
            this.comboBoxUR.SelectedIndex = 0;
            dp.BackgroundImage = Resources.avatar;
        }
    }
}
