using MSSMS.Enums;
using MSSMS.Properties;
using MSSMS.Utilities;
using System;
using System.Windows.Forms;
using System.Configuration;

namespace MSSMS
{
    public partial class EditConnectionSettings : Form
    {
        ConnectionSettings connectionSettingsParent = null;

        public EditConnectionSettings(Form connectionSettingsParent)
        {
            InitializeComponent();
            this.connectionSettingsParent = (ConnectionSettings)connectionSettingsParent;
        }

        private void EditConnectionSettings_Load(object sender, EventArgs e)
        {
            textBoxHost.Text = Settings.Default.MySQLHost;
            textBoxPort.Text = Settings.Default.MySQLPort;
            textBoxDBName.Text = Settings.Default.MySQLDatabase;
            textBoxUN.Text = Settings.Default.MySQLUsername;
            textBoxPW.Text = Settings.Default.MySQLPassword;
            textBoxCPW.Text = Settings.Default.MySQLPassword;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBoxHost.Text = Settings.Default.MySQLHost;
            textBoxPort.Text = Settings.Default.MySQLPort;
            textBoxDBName.Text = Settings.Default.MySQLDatabase;
            textBoxUN.Text = Settings.Default.MySQLUsername;
            textBoxPW.Text = Settings.Default.MySQLPassword;
            textBoxCPW.Text = Settings.Default.MySQLPassword;
        }

        private void peakPasswords_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxPW.PasswordChar = '\0';
            textBoxCPW.PasswordChar = '\0';
        }

        private void peakPasswords_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxPW.PasswordChar = '●';
            textBoxCPW.PasswordChar = '●';
        }

        private void textBoxCPW_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPW.Text) || string.IsNullOrWhiteSpace(textBoxPW.Text) || string.IsNullOrEmpty(textBoxCPW.Text) || string.IsNullOrWhiteSpace(textBoxCPW.Text))
            {
                pictureBoxPWStatus.Visible = false;
            }
            else
            {
                pictureBoxPWStatus.Visible = true;

                if (ValidationHandler.IsValidPassword(textBoxPW.Text, textBoxCPW.Text))
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
            if (string.IsNullOrEmpty(textBoxPW.Text) || string.IsNullOrWhiteSpace(textBoxPW.Text) || string.IsNullOrEmpty(textBoxCPW.Text) || string.IsNullOrWhiteSpace(textBoxCPW.Text))
            {
                pictureBoxPWStatus.Visible = false;
            }
            else
            {
                pictureBoxPWStatus.Visible = true;

                if (ValidationHandler.IsValidPassword(textBoxPW.Text, textBoxCPW.Text))
                {
                    pictureBoxPWStatus.BackgroundImage = Resources.tickC;
                }
                else
                {
                    pictureBoxPWStatus.BackgroundImage = Resources.closeC;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //validations
            if(string.IsNullOrEmpty(textBoxHost.Text) || string.IsNullOrWhiteSpace(textBoxHost.Text))
            {
                NotificationManager.showInAppNotification(connectionSettingsParent.panelInAppNotifications, connectionSettingsParent.lableInAppNotification, connectionSettingsParent.pbInAppNotification, connectionSettingsParent.btnCloseInAppNotification, "Host name cannot be empty.", NotificationStates.WARNING);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPort.Text) || string.IsNullOrWhiteSpace(textBoxPort.Text))
            {
                NotificationManager.showInAppNotification(connectionSettingsParent.panelInAppNotifications, connectionSettingsParent.lableInAppNotification, connectionSettingsParent.pbInAppNotification, connectionSettingsParent.btnCloseInAppNotification, "Port Number cannot be empty.", NotificationStates.WARNING);
                return;
            }
            if (string.IsNullOrEmpty(textBoxDBName.Text) || string.IsNullOrWhiteSpace(textBoxDBName.Text))
            {
                NotificationManager.showInAppNotification(connectionSettingsParent.panelInAppNotifications, connectionSettingsParent.lableInAppNotification, connectionSettingsParent.pbInAppNotification, connectionSettingsParent.btnCloseInAppNotification, "Database name cannot be empty.", NotificationStates.WARNING);
                return;
            }
            if (string.IsNullOrEmpty(textBoxUN.Text) || string.IsNullOrWhiteSpace(textBoxUN.Text))
            {
                NotificationManager.showInAppNotification(connectionSettingsParent.panelInAppNotifications, connectionSettingsParent.lableInAppNotification, connectionSettingsParent.pbInAppNotification, connectionSettingsParent.btnCloseInAppNotification, "Username cannot be empty.", NotificationStates.WARNING);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPW.Text) || string.IsNullOrWhiteSpace(textBoxPW.Text))
            {
                NotificationManager.showInAppNotification(connectionSettingsParent.panelInAppNotifications, connectionSettingsParent.lableInAppNotification, connectionSettingsParent.pbInAppNotification, connectionSettingsParent.btnCloseInAppNotification, "Passwords cannot be empty.", NotificationStates.WARNING);
                return;
            }
            if (string.IsNullOrEmpty(textBoxCPW.Text) || string.IsNullOrWhiteSpace(textBoxCPW.Text))
            {
                NotificationManager.showInAppNotification(connectionSettingsParent.panelInAppNotifications, connectionSettingsParent.lableInAppNotification, connectionSettingsParent.pbInAppNotification, connectionSettingsParent.btnCloseInAppNotification, "Passwords cannot be empty.", NotificationStates.WARNING);
                return;
            }

            if (ValidationHandler.IsValidPassword(textBoxPW.Text, textBoxCPW.Text) == false)
            {
                NotificationManager.showInAppNotification(connectionSettingsParent.panelInAppNotifications, connectionSettingsParent.lableInAppNotification, connectionSettingsParent.pbInAppNotification, connectionSettingsParent.btnCloseInAppNotification, "Passwords do not match.", NotificationStates.WARNING);
                return;
            }

            //save
            try
            {
                Settings.Default.MySQLHost = textBoxHost.Text;
                Settings.Default.MySQLPort = textBoxPort.Text;
                Settings.Default.MySQLDatabase = textBoxDBName.Text;
                Settings.Default.MySQLUsername = textBoxUN.Text;
                Settings.Default.MySQLPassword = textBoxPW.Text;
                Settings.Default.Save();
                Settings.Default.Reload();
                Settings.Default.Upgrade();
                Settings.Default.Save();
                Settings.Default.Reload();

                NotificationManager.showInAppNotification(connectionSettingsParent.panelInAppNotifications, connectionSettingsParent.lableInAppNotification, connectionSettingsParent.pbInAppNotification, connectionSettingsParent.btnCloseInAppNotification, "Connection Settings saved successfully.", NotificationStates.SUCCESS);

            }
            catch (Exception)
            {
                NotificationManager.showInAppNotification(connectionSettingsParent.panelInAppNotifications, connectionSettingsParent.lableInAppNotification, connectionSettingsParent.pbInAppNotification, connectionSettingsParent.btnCloseInAppNotification, "Could not save connection settings.\nPrevious settings will be restored.", NotificationStates.ERROR);
            }
        }

        private void textBoxHost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                NotificationManager.showInAppNotification(connectionSettingsParent.panelInAppNotifications, connectionSettingsParent.lableInAppNotification, connectionSettingsParent.pbInAppNotification, connectionSettingsParent.btnCloseInAppNotification, "Host name cannot contain spaces.", NotificationStates.WARNING);
            }
        }

        private void textBoxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                NotificationManager.showInAppNotification(connectionSettingsParent.panelInAppNotifications, connectionSettingsParent.lableInAppNotification, connectionSettingsParent.pbInAppNotification, connectionSettingsParent.btnCloseInAppNotification, "Port number cannot contain spaces.", NotificationStates.WARNING);
            }
        }

        private void textBoxDBName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                NotificationManager.showInAppNotification(connectionSettingsParent.panelInAppNotifications, connectionSettingsParent.lableInAppNotification, connectionSettingsParent.pbInAppNotification, connectionSettingsParent.btnCloseInAppNotification, "Database name cannot contain spaces.", NotificationStates.WARNING);
            }
        }

        private void textBoxUN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                NotificationManager.showInAppNotification(connectionSettingsParent.panelInAppNotifications, connectionSettingsParent.lableInAppNotification, connectionSettingsParent.pbInAppNotification, connectionSettingsParent.btnCloseInAppNotification, "Username cannot contain spaces.", NotificationStates.WARNING);
            }
        }
    }
}
