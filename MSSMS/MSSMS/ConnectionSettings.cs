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
    public partial class ConnectionSettings : Form
    {
        public ConnectionSettings()
        {
            InitializeComponent();
        }

        private void ConnectionSettings_Load(object sender, EventArgs e)
        {
            RequestMasterPassword();
            panelInAppNotifications.Visible = false;
        }

        public void RequestMasterPassword()
        {
            FormHandler formHandler = new FormHandler(panelCSContainer);
            formHandler.changeMainContent(new MasterPassword(this));
        }

        public void showEditConnectionSettings()
        {
            FormHandler formHandler = new FormHandler(panelCSContainer);
            formHandler.changeMainContent(new EditConnectionSettings(this));
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            panelInAppNotifications.Hide();
        }
    }
}
