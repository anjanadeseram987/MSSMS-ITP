using MSSMS.DBHandler;
using MSSMS.Enums;
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
    public partial class ResetUserPasswordNewPassword : Form
    {
        private UserAccountDBHandler userAccountDBHandler = new UserAccountDBHandler();
        private ResetUserPassword resetUserPasswordParent = null;
        private string email = null;
        private string salt = null;
        private string hash = null;
        private bool isSuccessful = false;

        public ResetUserPasswordNewPassword(Form resetUserPassword, string email)
        {
            InitializeComponent();
            this.resetUserPasswordParent = (ResetUserPassword)resetUserPassword;
            this.email = email;
        }

        private void ResetUserPasswordNewPassword_Load(object sender, EventArgs e)
        {
            if (email != null)
            {
                resetUserPasswordParent.panelInAppNotifications.Visible = true;
            } else
            {
                resetUserPasswordParent.panelInAppNotifications.Visible = false;
            }
            resetUserPasswordParent.panelHeader.Visible = true;
            resetUserPasswordParent.Text = "New Password";
            resetUserPasswordParent.lblTitle.Text = "Password Security";
            resetUserPasswordParent.lblDescription.Text = "Please enter a new strong password. We recommend a password with at least 8 characters.";

            pictureBoxPWStatus.Visible = false;
        }

        private void textBoxPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnResetPW.Focus();
                btnResetPW.PerformClick();
            }
        }

        private void textBoxConfPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnResetPW.Focus();
                btnResetPW.PerformClick();
            }
        }

        private async void btnResetPW_Click(object sender, EventArgs e)
        {
            //loading indicator
            NotificationManager.showLoader(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Password Resetting is in Progress...");

            if (String.IsNullOrEmpty(textBoxPW.Text) || String.IsNullOrWhiteSpace(textBoxPW.Text))
            {
                NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Password cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (String.IsNullOrEmpty(textBoxConfPW.Text) || String.IsNullOrWhiteSpace(textBoxConfPW.Text))
            {
                NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Confirmation password cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsValidPassword(textBoxPW.Text.Trim(), textBoxConfPW.Text.Trim()) == false)
            {
                NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Passwords do not match.", NotificationStates.ERROR);
                return;
            }

            //TODO: length check if necessary

            //Run Hashing and Updating as a Async Task
            try
            {
                isSuccessful = await Task.Run(() => updateNewPasswordAsync());
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }

            resetUserPasswordParent.openSuccess(isSuccessful);
        }

        private void textBoxConfPW_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxConfPW.Text) || string.IsNullOrWhiteSpace(textBoxConfPW.Text))
            {
                pictureBoxPWStatus.Visible = false;
            }
            else
            {
                pictureBoxPWStatus.Visible = true;

                if (ValidationHandler.IsValidPassword(textBoxPW.Text, textBoxConfPW.Text))
                {
                    pictureBoxPWStatus.BackgroundImage = Resources.tickC;
                }
                else
                {
                    pictureBoxPWStatus.BackgroundImage = Resources.closeC;
                }
            }
        }

        private void textBoxPW_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPW.Text) || string.IsNullOrWhiteSpace(textBoxPW.Text))
            {
                pictureBoxPWStatus.Visible = false;
            }
            else
            {
                pictureBoxPWStatus.Visible = true;

                if (ValidationHandler.IsValidPassword(textBoxPW.Text, textBoxConfPW.Text))
                {
                    pictureBoxPWStatus.BackgroundImage = Resources.tickC;
                }
                else
                {
                    pictureBoxPWStatus.BackgroundImage = Resources.closeC;
                }
            }
        }

        //updateNewPasswordAsync
        public async Task<bool> updateNewPasswordAsync()
        {
            isSuccessful = false;

            //hasher for hash new password
            PasswordHasher passwordHasher = new PasswordHasher();

            //save new password
            try
            {
                salt = Convert.ToBase64String(passwordHasher.CreateSalt());
                hash = Convert.ToBase64String(passwordHasher.HashPassword(textBoxPW.Text.Trim(), Convert.FromBase64String(salt)));

                if (email != null && salt != null && hash != null)
                {
                    await userAccountDBHandler.saveNewPasswordByEmail(email, hash, salt);
                    isSuccessful = true;
                }
                else
                {
                    isSuccessful = false;
                    throw new MSSMUIException("Faild to reset the password", "DBERROR0");
                }
            }
            catch (MSSMUIException ex)
            {
                throw new MSSMUIException("Faild to reset the password "+ex.Message);
            }
            catch (Exception ex)
            {
                throw new MSSMUIException("Faild to reset the password "+ex.Message, "DBERROR2");
            }

            return isSuccessful;
        }

        private void peakPasswords_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxPW.PasswordChar = '\0';
            textBoxConfPW.PasswordChar = '\0';
        }

        private void peakPasswords_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxPW.PasswordChar = '●';
            textBoxConfPW.PasswordChar = '●';
        }
    }
}
