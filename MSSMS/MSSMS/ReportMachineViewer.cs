using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSSMS.DBHandler;
using MSSMS.Models;

namespace MSSMS
{
    public partial class ReportMachineViewer : Form
    {
        private ReportsDBHandler reportsDBHandler = new ReportsDBHandler();
        private List<Machine> machines = new List<Machine>();
        private List<Machine> machineReportDaily = new List<Machine>();
        private Machine machine = null;
        private string type, columnDaily, dateDaily, monthMonthly, yearMonthly, yearYearly, dateStart, dateEnd;

        public ReportMachineViewer()
        {
            InitializeComponent();
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            panelInAppNotifications.Visible = false;

            if (type.Equals("daily"))
            {
                machineReportDaily = reportsDBHandler.searchMachineReportDaily(dateDaily);
            }
            else if (type.Equals("monthly"))
            {
                machineReportDaily = reportsDBHandler.searchMachineReportMonthly(monthMonthly, yearMonthly);
            }
            else if (type.Equals("yearly"))
            {
                machineReportDaily = reportsDBHandler.searchMachineReportYearly(yearYearly);
            }
            else if (type.Equals("duration"))
            {
                machineReportDaily = reportsDBHandler.searchMachineReportDuration(dateStart, dateEnd);
            }

            dataGridViewReportMachines.Rows.Clear();

            foreach (Machine machine in machineReportDaily)
            {
                dataGridViewReportMachines.Rows.Add(machine.machineId, machine.serialNumber, machine.name, machine.locationId, machine.workingState, machine.addedBy, machine.addedDate.ToString("MM/dd/yyyy"), machine.description);
            }
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            panelInAppNotifications.Hide();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridViewReportMachines.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridViewReportMachines.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridViewReportMachines.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridViewReportMachines.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewReportMachines.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridViewReportMachines.Rows[i].Cells[j].Value.ToString();
                    }
                }
                excellApplication.Columns.AutoFit();
                excellApplication.Visible = true;
            }
        }

        public void setType(string type)
        {
            this.type = type;
        }

        public void setDateDaily(string date)
        {
            this.dateDaily = date;
        }

        public void setMonthMonthly(string month)
        {
            this.monthMonthly = month;
        }

        public void setYearMonthly(string year)
        {
            this.yearMonthly = year;
        }

        public void setYearYearly(string year)
        {
            this.yearYearly = year;
        }
        public void setDateStart(string dateStart)
        {
            this.dateStart = dateStart;
        }
        public void setDateEnd(string dateEnd)
        {
            this.dateEnd = dateEnd;
        }
    }
}
