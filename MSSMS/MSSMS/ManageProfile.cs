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
    public partial class ManageProfile : Form
    {
        UserAccount newProfile = null;
        UserAccountDBHandler userAccountDBHandler = new UserAccountDBHandler();
        string dpPath = null;
        Image dpImage = null;
        int dpFileSize;
        byte[] dpRawData;
        FileStream fs;

        public ManageProfile()
        {
            InitializeComponent();
        }

        private void ManageProfile_Load(object sender, EventArgs e)
        {
            panelInAppNotifications.Visible = false;
            loadDefaults();
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Images(*.BMP; *.JPG; *.PNG)| *.BMP; *.JPG; *.PNG", ValidateNames = true, Multiselect = false })
            {
                DialogResult dialogResult = openFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    dpPath = openFileDialog.FileName;
                    dpImage = Image.FromFile(dpPath);
                    fs = new FileStream(dpPath, FileMode.Open, FileAccess.Read);
                    dpFileSize = (int)fs.Length;

                    dpRawData = new byte[dpFileSize];
                    fs.Read(dpRawData, 0, dpFileSize);
                    fs.Close();

                    circularPanelProfilePicture.BackgroundImage = ImageTools.getSqureSizedImage(dpImage);
                }
                else
                {
                    if (SessionManager.user.profilePicture != null)
                    {
                        circularPanelProfilePicture.BackgroundImage = ImageTools.getImageFromByteArray(SessionManager.user.profilePicture);
                    }
                    else
                    {
                        circularPanelProfilePicture.BackgroundImage = Resources.UserFlat;
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
            loadDefaults();
        }

        private void loadDefaults()
        {
            textBoxEID.Text = SessionManager.user.employeeId;
            textBoxName.Text = SessionManager.user.fullName;
            textBoxDeptName.Text = SessionManager.user.departmentName;
            textBoxDesigName.Text = SessionManager.user.designationName;
            textBoxEmailReadOnly.Text = SessionManager.user.primaryEmail;
            dateTimePickerBirthday.Value = SessionManager.user.birthday;
            textBoxFirstName.Text = SessionManager.user.firstName;
            textBoxLastName.Text = SessionManager.user.lastName;
            textBoxFullName.Text = SessionManager.user.fullName;
            textBoxPhone.Text = SessionManager.user.primaryPhone;
            textBoxEmail.Text = SessionManager.user.primaryEmail;
            if (SessionManager.user.profilePicture != null)
            {
                circularPanelProfilePicture.BackgroundImage = ImageTools.getImageFromByteArray(SessionManager.user.profilePicture);
            }

            switch (SessionManager.user.gender)
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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

            if (ValidationHandler.IsValidInternationalContactNumber(textBoxPhone.Text) == false)
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

            //getting the display picture
            ImageConverter imageConverter = new ImageConverter();
            dpRawData = (byte[])imageConverter.ConvertTo(this.circularPanelProfilePicture.BackgroundImage, Type.GetType("System.Byte[]"));

            //save
            newProfile = new UserAccount(SessionManager.user.employeeId, textBoxFirstName.Text, textBoxLastName.Text, textBoxFullName.Text, comboBoxGender.SelectedItem.ToString(), dateTimePickerBirthday.Value, textBoxEmail.Text, textBoxPhone.Text, dpRawData);

            try
            {
                if (userAccountDBHandler.updateProfile(newProfile) == true)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Profile Updated Successfully.", NotificationStates.SUCCESS);
                    SessionManager.user = userAccountDBHandler.getUserAccountDetailsById(SessionManager.user.employeeId);
                    loadDefaults();

                    //refresh main interface
                    switch(SessionManager.userInterface)
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
    }
}
