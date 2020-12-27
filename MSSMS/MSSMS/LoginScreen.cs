using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Properties;
using MSSMS.Utilities;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace MSSMS
{
    public partial class LoginScreen : Form
    {

        PasswordHasher passwordHasher = new PasswordHasher();
        LoginHandler loginHandler = new LoginHandler();
        private bool isConnectionAvailable = false;

        public LoginScreen()
        {
            InitializeComponent();
        }


        private async void LoginScreen_Load(object sender, EventArgs e)
        {
            pictureBoxUNIndicator.Visible = false;

            //check connection
            try
            {
                await checkConnectionAsync();
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, ex.Message, NotificationStates.ERROR);
            }
        }

        private void LoginScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SessionManager.sessionState == SessionState.SESSION_ISNOTSET)
            {
                Application.Exit();
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            //loading indicator
            NotificationManager.showLoader(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, "User Authenticating in Progress...");

            if (String.IsNullOrWhiteSpace(textBoxUsername.Text) || String.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                NotificationManager.showInAppNotification(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, "Credential feilds cannot be empty.",NotificationStates.ERROR);
                if (String.IsNullOrWhiteSpace(textBoxUsername.Text)){
                    textBoxUsername.Text = "";
                    textBoxUsername.Focus();
                } 
                else
                {
                    textBoxPassword.Text = "";
                    textBoxPassword.Focus();
                }
                return;
            }

            //connection checking
            if (isConnectionAvailable == false)
            {
                try
                {
                    await checkConnectionAsync();
                }
                catch (Exception ex)
                {
                    NotificationManager.showInAppNotification(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, ex.Message, NotificationStates.ERROR);
                    return;
                }
            }

            try
            {
                UserAccountState userAccountState = await validateUser();//loginHandler.validateUser(textBoxUsername.Text.ToLower(), textBoxPassword.Text);
                if (userAccountState == UserAccountState.VALID)
                {

                    SessionState sessionState = SessionManager.getSession(textBoxUsername.Text);
                    if (sessionState == SessionState.SESSION_ISSET)
                    {
                        NotificationManager.showInAppNotification(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, "Logged in successfully.", NotificationStates.SUCCESS);
                        FormHandler.loadLobby(this.Name, this, SessionManager.userInterfaceName);
                        this.Close();
                    }
                    else
                    {
                        textBoxPassword.Text = "";
                        textBoxUsername.Text = "";
                        textBoxUsername.Focus();
                    }
                }
                else if (userAccountState == UserAccountState.INCORRECT)
                {
                    NotificationManager.showInAppNotification(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, "Incorrect credentials. Please try again.", NotificationStates.ERROR);
                    textBoxPassword.Text = "";
                    textBoxPassword.Focus();
                }
                else
                {
                    textBoxPassword.Text = "";
                    textBoxUsername.Text = "";
                    textBoxUsername.Focus();
                    throw new MSSMUIException("Invalid credentials. Please enter valid user credentials", "0001");
                }


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //NotificationManager.showInAppNotification(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, ex.Message, NotificationStates.ERROR);
                NotificationManager.showInAppNotification(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, "Could not connect to the application services. Contact system administrator.\nError Code: 003", NotificationStates.ERROR);
            }
            catch (MSSMUIException ex)
            {
                NotificationManager.showInAppNotification(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, ex.Message, NotificationStates.ERROR);
            }
            catch (Exception ex)
            {
                //NotificationManager.showInAppNotification(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, ex.Message, NotificationStates.ERROR);
                NotificationManager.showInAppNotification(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, "Connection Error. Contact system administrator. More info: " + ex.Message + "\nError Code: 004", NotificationStates.ERROR);
            }
        }

        private async Task<UserAccountState> validateUser()
        {
            UserAccountState state;

            try
            {
                state = await Task.Run (()=>loginHandler.validateUserAsync(textBoxUsername.Text.ToLower(), textBoxPassword.Text));
            }
            catch (Exception ex)
            {
                throw new MSSMUIException(ex.Message, "666");
            }

            return state;
            
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                btnLogin.Focus();
                btnLogin.PerformClick();
            }
        }

        private void textBoxUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnLogin.Focus();
                btnLogin.PerformClick();
            }
        }

        private void textBoxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                NotificationManager.showInAppNotification(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, "Username cannot contain spaces.", NotificationStates.WARNING);
            }
        }

        private async void lblForgotPWD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(isConnectionAvailable == false)
            {
                try
                {
                    loginHandler = new LoginHandler();
                    await checkConnectionAsync();
                } 
                catch (Exception ex)
                {
                    NotificationManager.showInAppNotification(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, ex.Message, NotificationStates.ERROR);
                }
            } 
            else
            {
                ResetUserPassword resetUserPassword = new ResetUserPassword(loginHandler);
                resetUserPassword.ShowDialog();
            }
            
        }

        private void peakPassword_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxPassword.PasswordChar = '\0';
        }

        private void peakPassword_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxPassword.PasswordChar = '●';
        }

        private async void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();

            if (String.IsNullOrEmpty(username) || String.IsNullOrWhiteSpace(username))
            {
                pictureBoxUNIndicator.Visible = false;
            }
            else
            {
                if (isConnectionAvailable == true)
                {
                    pictureBoxUNIndicator.BackgroundImage = null;
                    pictureBoxUNIndicator.Visible = true;

                    try
                    {
                        if (await Task.Run(()=>loginHandler.isValidUsernameAsync(username)) == true)
                        {
                            pictureBoxUNIndicator.BackgroundImage = Resources.tickC;
                        }
                        else
                        {
                            pictureBoxUNIndicator.BackgroundImage = Resources.closeC;
                        }
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            await checkConnectionAsync();
                        }
                        catch (Exception ex2)
                        {
                            NotificationManager.showInAppNotification(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, ex2.Message, NotificationStates.ERROR);
                            return;
                        }
                    }
                }
                else
                {
                    //show connection error.
                }
            }
        }

        //check connection
        private async Task checkConnectionAsync()
        {
            try
            {
                NotificationManager.showLoader(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, "Reconnecting to the Server...");
                isConnectionAvailable = await Task.Run(()=>loginHandler.checkConnectionAsync());
                if (isConnectionAvailable == true)
                {
                    lblForgotPWD.Text = "Forgot Password";
                    pictureBoxConnectionSettings.Visible = false;
                    NotificationManager.showInAppNotification(panelLoginMsgBox, lblLoginMsgBoxText, pbLoginMsgBoxIcon, "If you are experiencing login errors or you don't have an authorized MSSMS account please kindly contact the System Administrator.", NotificationStates.INFORMATION);
                }
            }
            catch (MSSMUIException ex)
            {
                lblForgotPWD.Text = "Reconnect";
                pictureBoxConnectionSettings.Visible = true;
                isConnectionAvailable = false;
                throw new MSSMUIException(ex.Message);
            }
        }

        private void pictureBoxConnectionSettings_Click(object sender, EventArgs e)
        {
            ConnectionSettings connectionSettings = new ConnectionSettings();
            connectionSettings.ShowDialog();
        }
    }
}
