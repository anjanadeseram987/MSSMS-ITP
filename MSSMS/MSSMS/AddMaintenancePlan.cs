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
    public partial class AddMaintenancePlan : Form
    {
        public AddMaintenancePlan()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            panelInAppNotifications.Hide();
        }

        private void AddMaintenancePlan_Load(object sender, EventArgs e)
        {
            panelInAppNotifications.Visible = false;
        }
    }
}
