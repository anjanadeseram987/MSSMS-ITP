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
    public partial class ManageShipping : Form
    {
        public ManageShipping()
        {
            InitializeComponent();
        }

        private void ManageShipping_Load(object sender, EventArgs e)
        {
            panelInAppNotifications.Visible = false;

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "SHMGR")
            {
                this.dataGridShippedGoods.Columns["Update"].Visible = false;
                this.dataGridShippedGoods.Columns["Delete"].Visible = false;
            }
        }
    }
}
