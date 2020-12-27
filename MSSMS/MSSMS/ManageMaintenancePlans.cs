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
    public partial class ManageMaintenancePlans : Form
    {
        public ManageMaintenancePlans()
        {
            InitializeComponent();
        }

        private void ManageMaintenancePlans_Load(object sender, EventArgs e)
        {
            panelInAppNotifications.Visible = false;

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "ENGNR")
            {
                this.dataGridMaintenancePlans.Columns["Update"].Visible = false;
                this.dataGridMaintenancePlans.Columns["Delete"].Visible = false;
                this.AddMaintenancePlan.Visible = false;
            }
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            panelInAppNotifications.Hide();
        }

        private void AddProductionPlan_Click(object sender, EventArgs e)
        {
            FormHandler.openChildForm(this.Name, this, "AddMaintenancePlan", ChildFormType.ADD, null); 
        }

        private void btnPrintOIP_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridMaintenancePlans.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridMaintenancePlans.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridMaintenancePlans.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridMaintenancePlans.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridMaintenancePlans.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridMaintenancePlans.Rows[i].Cells[j].Value.ToString();
                    }
                }
                excellApplication.Columns.AutoFit();
                excellApplication.Visible = true;

                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Data Exported.", NotificationStates.SUCCESS);
            }
            else
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Nothing to Export.", NotificationStates.INFORMATION);
            }
        }
    }
}
