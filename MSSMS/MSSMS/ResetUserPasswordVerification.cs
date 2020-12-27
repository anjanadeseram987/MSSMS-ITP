using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Properties;
using MSSMS.Utilities;
using System;
using System.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace MSSMS
{
    public partial class ResetUserPasswordVerification : Form
    {
        private ResetUserPassword resetUserPasswordParent = null;
        private bool isValidEmail = false;
        private bool isValidToken = false;
        private string email = null;
        private string tokenDigits = null;
        private string textToken = null;
        private ResetToken resetToken = null;
        private DateTime tokenExpiration;
        private bool isConnectionAvailable = false;

        private UserAccountDBHandler userAccountDBHandler = new UserAccountDBHandler();

        public ResetUserPasswordVerification(Form resetUserPassword)
        {
            InitializeComponent();
            this.resetUserPasswordParent = (ResetUserPassword)resetUserPassword;
        }

        private async void ResetUserPasswordVerification_Load(object sender, EventArgs e)
        {
            resetUserPasswordParent.panelInAppNotifications.Visible=false;
            resetUserPasswordParent.panelHeader.Visible = true;
            resetUserPasswordParent.Text = "Password Reset Token";
            resetUserPasswordParent.lblTitle.Text = "Password Security";
            resetUserPasswordParent.lblDescription.Text = "Please enter your email address associated with the MSSMS user account to receive the reset token in order to continue the password resetting process.";

            pictureBoxEmailStatus.Visible = false;
            pictureBoxTokenStatus.Visible = false;
            lblTokenValidity.Visible = false;

            await checkConnectionAsync();

        }

        private async void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            //stop ongoing countdown
            timerTokenCountdown.Stop();
            lblTokenValidity.Text = "";
            textBoxResetToken.Text = "";

            email = textBoxEmail.Text;

            //checking for a valid connection
            if (isConnectionAvailable == true)
            {
                //make sure the connection is still available while typing
                await checkConnectionAsync();
                if (isConnectionAvailable == false)
                {
                    return;
                }

                if (String.IsNullOrWhiteSpace(email) || String.IsNullOrEmpty(email))
                {
                    pictureBoxEmailStatus.Visible = false;
                }
                else
                {
                    try
                    {
                        pictureBoxEmailStatus.Visible = true;
                        if (userAccountDBHandler.isValidEmailAddess(email) == true)
                        {
                            pictureBoxEmailStatus.BackgroundImage = Resources.tickC;
                            isValidEmail = true;

                            checkResetToken();

                        }
                        else
                        {
                            pictureBoxEmailStatus.BackgroundImage = Resources.closeC;
                            isValidEmail = false;
                            lblTokenValidity.Visible = false;
                            lblTokenValidity.Text = "";
                        }
                    }
                    catch(Exception ex)
                    {
                        try
                        {
                            await checkConnectionAsync();
                        }
                        catch (Exception ex2)
                        {
                            NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, ex2.Message, NotificationStates.ERROR);
                            return;
                        }
                    }
                }
            }
        }

        private void textBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Email cannot contain spaces.", NotificationStates.WARNING);
            }
        }

        private void textBoxEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnSendToken.Focus();
                btnSendToken.PerformClick();
            }
        }

        private async void btnPRS_Click(object sender, EventArgs e)
        {
            textBoxResetToken.Text = "";

            if (String.IsNullOrEmpty(textBoxEmail.Text) || String.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Email Address cannot be empty.", NotificationStates.WARNING);
                return;
            }

            //check connection
            //loading indicator
            NotificationManager.showLoader(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Sending Password Reset Token...");

            await checkConnectionAsync();

            if (isConnectionAvailable == false)
            {
                return;
            }
            else
            {

                if (isValidEmail == true)
                {
                    try
                    {
                        tokenDigits = ResetTokenGenerator.generateToken();
                        tokenExpiration = DateTime.Now.AddMinutes(Properties.Settings.Default.DefaultTokenExpTime);
                        ResetToken newToken = new ResetToken(email, tokenDigits, tokenExpiration, 0);
                        isValidToken = userAccountDBHandler.saveNewToken(newToken);
                    }
                    catch (MSSMUIException ex)
                    {
                        isValidToken = false;
                        NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                        return;
                    }
                    catch (Exception ex)
                    {
                        isValidToken = false;
                        NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Unable to generate the reset token.", NotificationStates.ERROR);
                        return;
                    }

                    //send token
                    if (isValidToken == true && String.IsNullOrEmpty(tokenExpiration.ToString()) == false)
                    {
                        try
                        {
                            //send mail
                            await MailHandler.sendNewEmailAsync("Privacy", email, "Reset Token for MSSMS Account", "Please find your reset token attached below.\nReset Token: " + tokenDigits + "\nValid Until: " + tokenExpiration
                                + "\n\nNote That the password reset token is only valid till the specified time above and cannot be used after it is expired." +
                                "\n\n©2020 MSSMS. Jafferjee Brothers Tea Division.");
                            NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Please check your inbox for the reset token.", NotificationStates.SUCCESS);

                            //get new token details
                            checkResetToken();

                        }
                        catch (Exception ex)
                        {
                            NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Unable to send the reset token.", NotificationStates.ERROR);
                            await checkConnectionAsync();
                            return;
                        }
                    }
                }
                else
                {
                    NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Please enter a valid Email address first.", NotificationStates.ERROR);
                }
            }
        }

        private void textBoxResetToken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnVerifyToken.Focus();
                btnVerifyToken.PerformClick();
            }
        }

        private void textBoxResetToken_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Reset Tokens cannot contain spaces.", NotificationStates.WARNING);
            }
        }

        private async void btnVerifyToken_Click(object sender, EventArgs e)
        {
            if (resetToken != null)
            {
                if (String.IsNullOrEmpty(textBoxResetToken.Text) || String.IsNullOrWhiteSpace(textBoxResetToken.Text))
                {
                    NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Reset Token cannot be empty.", NotificationStates.WARNING);
                    return;
                }

                //checking connection
                //loading indicator
                NotificationManager.showLoader(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Verifying Token...");

                await checkConnectionAsync();

                if (isConnectionAvailable == false)
                {
                    return;
                }
                else
                {
                    if (ValidationHandler.IsValidResetToken(textBoxResetToken.Text, resetToken.token) == false)
                    {
                        NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "The entered Reset Token is invalid.", NotificationStates.ERROR);
                        return;
                    }
                    else
                    {
                        NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Reset Token has been verified successfully", NotificationStates.SUCCESS);
                        resetUserPasswordParent.openUpdate(email);
                    }
                }
            }
            else
            {
                NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Please obtain a valid Reset Token first.", NotificationStates.ERROR);
                return;
            }
        }


        public async void checkResetToken()
        {
            //checking for a valid connection
            if (isConnectionAvailable == false)
            {
                return;
            }
            else
            {
                resetToken = userAccountDBHandler.getTokenByEmail(email);
                if (resetToken.token != "-1" && resetToken.isTokenUsed !=-1)
                {
                    if (resetToken.token != null || resetToken.token == "")
                    {
                        try
                        {
                            if (ValidationHandler.IsTokenExpired(resetToken) == false)
                            {
                                if (resetToken.isTokenUsed == 1)
                                {
                                    lblTokenValidity.Visible = true;
                                    lblTokenValidity.Text = "This Token has been already used.\nPlease obtain a new token.";
                                    resetToken = null;
                                    return;
                                }
                                else
                                {
                                    showCountdown();
                                }
                            }
                            else
                            {
                                lblTokenValidity.Visible = true;
                                lblTokenValidity.Text = "Your Last Token has Expired on:\n" + resetToken.tokenExpiration.ToString() + "\nPlease obtain a new token.";
                                resetToken = null;
                            }
                        }
                        catch (Exception ex)
                        {
                            await checkConnectionAsync();
                        }
                    }
                    else
                    {
                        lblTokenValidity.Visible = true;
                        lblTokenValidity.Text = "No valid reset tokens available yet.\nPlease obtain a token to reset the password.";
                    }
                }
                else
                {
                    lblTokenValidity.Visible = true;
                    lblTokenValidity.Text = "No valid reset tokens available yet.\nPlease obtain a token to reset the password.";
                }
            }
        }

        private void showCountdown()
        {
            lblTokenValidity.Visible = true;
            //begin new countdown
            timerTokenCountdown.Start();
        }

        private void timerTokenCountdown_Tick(object sender, EventArgs e)
        {
            TimeSpan timeSpan = resetToken.tokenExpiration.Subtract(DateTime.Now);
            //lblTokenValidity.Text = timeSpan.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
            lblTokenValidity.Text = String.Format("Valid Token Available for:\n{0} Minutes {1} Seconds",timeSpan.Minutes.ToString(),timeSpan.Seconds.ToString());

            if (timeSpan.Minutes <= 0 && timeSpan.Seconds <= 0)
            {
                timerTokenCountdown.Stop();
                lblTokenValidity.Text = "Your Last Token has Expired on:\n" + resetToken.tokenExpiration.ToString() + "\nPlease obtain a new token.";
                resetToken = null;
            }
        }

        private async void textBoxResetToken_TextChanged(object sender, EventArgs e)
        {
            textToken = textBoxResetToken.Text;

            //checking for a valid connection
            if (isConnectionAvailable == true)
            {
                //make sure the connection is still available while typing
                await checkConnectionAsync();
                if (isConnectionAvailable == false)
                {
                    return;
                }

                if (String.IsNullOrWhiteSpace(textToken) || String.IsNullOrEmpty(textToken) || resetToken == null)
                {
                    pictureBoxTokenStatus.Visible = false;
                }
                else
                {
                    pictureBoxTokenStatus.Visible = true;

                    try
                    {
                        if (ValidationHandler.IsValidResetToken(textToken, resetToken.token) == true)
                        {
                            pictureBoxTokenStatus.BackgroundImage = Resources.tickC;
                        }
                        else
                        {
                            pictureBoxTokenStatus.BackgroundImage = Resources.closeC;
                        }
                    }
                    catch (Exception ex)
                    {
                        isConnectionAvailable = false;
                        NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                    }
                }
            }
        }

        //check connection
        private async Task checkConnectionAsync()
        {
            try
            {
                isConnectionAvailable = await Task.Run(() => resetUserPasswordParent.loginHandler.checkConnectionAsync());
                lblReconnect.Visible = false;
            }
            catch (MSSMUIException ex)
            {
                isConnectionAvailable = false;
                lblReconnect.Visible = true;
                NotificationManager.showInAppNotification(resetUserPasswordParent.panelInAppNotifications, resetUserPasswordParent.lableInAppNotification, resetUserPasswordParent.pbInAppNotification, resetUserPasswordParent.btnCloseInAppNotification, "Could not connect to the Server.", NotificationStates.WARNING);
                pictureBoxEmailStatus.Visible = false;
                pictureBoxTokenStatus.Visible = false;
                lblTokenValidity.Visible = false;
            }
        }

        private async void lblReconnect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            await checkConnectionAsync();
        }
    }
}
