using MSSMS.Enums;
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
    public partial class ManageAssignedTasks : Form
    {
        public ManageAssignedTasks()
        {
            InitializeComponent();
        }

        private void ManageAssignedTasks_Load(object sender, EventArgs e)
        {
            panelInAppNotifications.Visible = false;
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            panelInAppNotifications.Hide();
        }

        private void btnAssignTask_Click(object sender, EventArgs e)
        {
            FormHandler.openChildForm(this.Name, this, "AssignTask", ChildFormType.ADD, null); 
        }
    }
}
