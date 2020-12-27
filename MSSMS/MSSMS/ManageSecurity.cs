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
    public partial class ManageSecurity : Form
    {
        private UserAccountDBHandler userAccountDBHandler = new UserAccountDBHandler();
        private string newToken = null;
        private string newEmail = null;
        private bool isValidEmail = false;
        private bool isValidUsername = false;

        public ManageSecurity()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            panelInAppNotifications.Hide();
        }

        private void ManageSecurity_Load(object sender, EventArgs e)
        {
            panelInAppNotifications.Visible = false;
            resetUsername();
            resetPasswords();
            resetEmails();
        }

        private void resetUsername()
        {
            textBoxNUN.Text=SessionManager.user.username;
            labelNUN.Text = "";
            pictureBoxNUN.BackgroundImage = null;
        }

        private void resetPasswords()
        {
            textBoxOPW.Clear();
            textBoxNPW.Clear();
            textBoxCPW.Clear();
            pictureBoxPWStatus.BackgroundImage = null;
        }

        private void resetEmails()
        {
            newEmail = null;
            newToken = null;
            isValidEmail = false;
            textBoxEmail.Clear();
            textBoxToken.Clear();
            pictureBoxEmailValidity.BackgroundImage = null;
            pictureBoxTokenStatus.BackgroundImage = null;
            labelSecEmail.Text = SessionManager.user.secondaryEmail;
        }

        private void peakPassword_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxOPW.PasswordChar = '\0';
            textBoxNPW.PasswordChar = '\0';
            textBoxCPW.PasswordChar = '\0';
        }

        private void peakPassword_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxOPW.PasswordChar = '●';
            textBoxNPW.PasswordChar = '●';
            textBoxCPW.PasswordChar = '●';
        }

        private void buttonChangeUsername_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if(isValidUsername == true)
            {
                try
                {
                    //update username
                    if (userAccountDBHandler.updateUsername(textBoxNUN.Text.Trim(), SessionManager.user.employeeId) == true)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "User Account Details Updated Successfully.", NotificationStates.SUCCESS);
                        
                        //update profile for the currently logged in user
                        updateCurrentUserInfo();
                        resetUsername();
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
            else
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please Enter a valid Username First.", NotificationStates.WARNING);
            }
        }

        private void updateCurrentUserInfo()
        {
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

        private void buttonClearPasswords_Click(object sender, EventArgs e)
        {
            resetPasswords();
        }

        private async void buttonResetPassword_Click(object sender, EventArgs e)
        {
            //loading indicator
            NotificationManager.showLoader(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Password Resetting is in Progress...");

            if (String.IsNullOrEmpty(textBoxOPW.Text) || String.IsNullOrWhiteSpace(textBoxOPW.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Current password cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (String.IsNullOrEmpty(textBoxNPW.Text) || String.IsNullOrWhiteSpace(textBoxNPW.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "A new password should be provided.", NotificationStates.WARNING);
                return;
            }

            if (String.IsNullOrEmpty(textBoxCPW.Text) || String.IsNullOrWhiteSpace(textBoxCPW.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Confirmation password cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsValidPassword(textBoxNPW.Text.Trim(), textBoxCPW.Text.Trim()) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "New passwords do not match.", NotificationStates.ERROR);
                return;
            }

            //TODO: length check if necessary

            //Run Hashing and Updating as a Async Task
            try
            {
                if(await userAccountDBHandler.updatePasswordAsync(textBoxOPW.Text.Trim(), textBoxNPW.Text.Trim(), SessionManager.user.employeeId) == true)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Password updated successfully.", NotificationStates.SUCCESS);
                }
                else
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Password updating failed.", NotificationStates.ERROR);
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

            resetPasswords();
        }

        private async void buttonSendToken_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxEmail.Text) || String.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Email Address cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsValidEmail(textBoxEmail.Text) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Enter a valid email address first.", NotificationStates.WARNING);
                return;
            }


            newEmail = textBoxEmail.Text.Trim();
            newToken = ResetTokenGenerator.generateToken();

            try
            {
                //send mail
                await MailHandler.sendNewEmailAsync("Email Verification", newEmail, "Email Verification Token", "Please find your reset token attached below.\nReset Token: " + newToken +
                    "\n\nNote That this email verification token cannot be used if you exit Account Security Window after requesting it." +
                    "\n\n©2020 MSSMS. Jafferjee Brothers Tea Division.");
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please check your inbox for the verification token.", NotificationStates.SUCCESS);
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Unable to send the verification token.", NotificationStates.ERROR);
                newToken = null;
                newEmail = null;
                return;
            }
        }

        private void buttonVerifyToken_Click(object sender, EventArgs e)
        {
            if (isValidEmail != true || newToken == null)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Obtain a valid verification token first.", NotificationStates.ERROR);
                newToken = null;
                return;
            }
            if (String.IsNullOrEmpty(textBoxToken.Text) || String.IsNullOrWhiteSpace(textBoxToken.Text))
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Please enter the verification token.", NotificationStates.WARNING);
                newToken = null;
                return;
            }

            if (ValidationHandler.IsValidResetToken(textBoxToken.Text.Trim(), newToken) == false)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Invalid Token.", NotificationStates.ERROR);
                newToken = null;
                return;
            }

            //save
            try
            {
                if (userAccountDBHandler.updateSecondaryEmail(newEmail, SessionManager.user.employeeId) == true)
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "New Email Address Verified and Updated Successfully.", NotificationStates.SUCCESS);
                    //update session
                    SessionManager.user = userAccountDBHandler.getUserAccountDetailsById(SessionManager.user.employeeId);
                }
                
                resetEmails();

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

        private void textBoxNUN_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxNUN.Text) || String.IsNullOrEmpty(textBoxNUN.Text))
            {
                labelNUN.Text = "Enter a new Username.";
                pictureBoxNUN.BackgroundImage = Resources.closeC;
            }
            else
            {
                string username = textBoxNUN.Text;


                if (userAccountDBHandler.isUsernameTakenExceptCurrentUser(username, SessionManager.user.employeeId) == false)
                {
                    labelNUN.Text = "";
                    pictureBoxNUN.BackgroundImage = Resources.tickC;
                    isValidUsername = true;
                }
                else
                {
                    labelNUN.Text = "This username is already taken";
                    pictureBoxNUN.BackgroundImage = Resources.closeC;
                    isValidUsername = false;
                }
            }
        }

        private void textBoxNPW_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNPW.Text) || string.IsNullOrWhiteSpace(textBoxNPW.Text))
            {
                pictureBoxPWStatus.BackgroundImage = null;
            }
            else
            {
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

        private void textBoxCPW_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCPW.Text) || string.IsNullOrWhiteSpace(textBoxCPW.Text))
            {
                pictureBoxPWStatus.BackgroundImage = null;
            }
            else
            {
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

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                pictureBoxEmailValidity.BackgroundImage = null;
                pictureBoxTokenStatus.BackgroundImage = null;
                isValidEmail = false;
            }
            else
            {
                if (ValidationHandler.IsValidEmail(textBoxEmail.Text) == true)
                {
                    pictureBoxEmailValidity.BackgroundImage = Resources.tickC;
                    isValidEmail = true;
                }
                else
                {
                    pictureBoxEmailValidity.BackgroundImage = Resources.closeC;
                    isValidEmail = false;
                    newToken = null;
                }
            }
        }

        private void textBoxToken_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxToken.Text) || String.IsNullOrEmpty(textBoxToken.Text))
            {
                pictureBoxTokenStatus.BackgroundImage = null;
            }
            else
            {
                if (newToken != null && ValidationHandler.IsValidResetToken(textBoxToken.Text, newToken) == true)
                {
                    pictureBoxTokenStatus.BackgroundImage = Resources.tickC;
                }
                else
                {
                    pictureBoxTokenStatus.BackgroundImage = Resources.closeC;
                }
            }
        }
    }
}