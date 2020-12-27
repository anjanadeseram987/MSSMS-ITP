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
    public partial class ManageCargoLoading : Form
    {
        public ManageCargoLoading()
        {
            InitializeComponent();
        }

        private void ManageCargoLoading_Load(object sender, EventArgs e)
        {
            panelInAppNotifications.Visible = false;

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "SHMGR")
            {
                this.dataGridCargoLoadingCharts.Columns["Update"].Visible = false;
                this.dataGridCargoLoadingCharts.Columns["Delete"].Visible = false;
                this.AddCargoLoadingChart.Visible = false;
            }
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            panelInAppNotifications.Hide();
        }

        private void AddProductionPlan_Click(object sender, EventArgs e)
        {
            FormHandler.openChildForm(this.Name, this, "StartNewCargoLoading", ChildFormType.ADD, null);
        }
    }
}
