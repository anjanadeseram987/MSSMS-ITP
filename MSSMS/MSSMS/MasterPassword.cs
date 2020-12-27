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
    public partial class MasterPassword : Form
    {
        ConnectionSettings connectionSettingsParent = null;
        public MasterPassword(Form connectionSettingsParent)
        {
            InitializeComponent();
            this.connectionSettingsParent = (ConnectionSettings)connectionSettingsParent;
        }

        private void peakPasswords_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxPW.PasswordChar = '●';
        }

        private void peakPasswords_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxPW.PasswordChar = '\0';
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

                if (ValidationHandler.IsValidPassword(textBoxPW.Text, Settings.Default.MSSMMasterPassword.ToString()))
                {
                    pictureBoxPWStatus.BackgroundImage = Resources.tickC;
                }
                else
                {
                    pictureBoxPWStatus.BackgroundImage = Resources.closeC;
                }
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if(ValidationHandler.IsValidPassword(textBoxPW.Text, Settings.Default.MSSMMasterPassword.ToString()))
            {
                connectionSettingsParent.showEditConnectionSettings();
            }
            else
            {

                return;
            }
        }
    }
}
