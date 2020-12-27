using MSSMS.Enums;
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
    public partial class ManageTasks : Form
    {
        public ManageTasks()
        {
            InitializeComponent();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            FormHandler.openChildForm(this.Name, this,"AddNewTask", ChildFormType.ADD, null);
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            panelInAppNotifications.Hide();
        }

        private void ManageTasks_Load(object sender, EventArgs e)
        {
            panelInAppNotifications.Visible = false;

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "HRMGR")
            {
                this.dataGridTasks.Columns["Update"].Visible = false;
                this.dataGridTasks.Columns["Delete"].Visible = false;
                this.btnAddTask.Visible = false;
            }
        }
    }
}
