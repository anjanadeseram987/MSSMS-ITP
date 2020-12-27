using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
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
using System.Data.SqlClient;
using MSSMS.Properties;
using Excel = Microsoft.Office.Interop.Excel;

namespace MSSMS
{
    public partial class ManageMachines : Form
    {
        private MachineryDBHandler machineryDBHandler = new MachineryDBHandler();
        private List<Machine> machines = new List<Machine>();
        private List<Machine> machineSearchResult = new List<Machine>();
        private Machine machine = null;
        private String selectedMachineId = null;

        public ManageMachines()
        {
            InitializeComponent();
        }

        private void ManageMachines_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadMachines();
            comboBoxColumn.SelectedItem = "All";

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "ENGNR")
            {
                this.dataGridMachines.Columns["UpdateMachine"].Visible = false;
                this.dataGridMachines.Columns["DeleteMachine"].Visible = false;
                this.btnAddMachine.Visible = false;
            }
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void btnAddMachine_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            FormHandler.openChildForm(this.Name, this, "AddMachines", ChildFormType.ADD, null);
        }

        private void dataGridMachines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridMachines.Columns[e.ColumnIndex].Name;

            if (column == "UpdateMachine")
            //if (column == "Update")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);
                selectedMachineId = dataGridMachines.CurrentRow.Cells["machineId"].FormattedValue.ToString();

                foreach (Machine machine in machines)
                {
                    if (machine.machineId == selectedMachineId)
                    {
                        FormHandler.openChildForm(this.Name, this, "AddMachines", ChildFormType.UPDATE, machine);
                        break;
                    }
                }
            }
            else if (column == "DeleteMachine")
            //else if (column == "Delete")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);
                selectedMachineId = dataGridMachines.CurrentRow.Cells["machineId"].FormattedValue.ToString();

                DialogResult dialogResult;
                dialogResult = MessageBox.Show("The selected Machine will be permanently deleted.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (machineryDBHandler.deleteMachine(selectedMachineId) == true)
                        {
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Machine Deleted Successfully.", NotificationStates.SUCCESS);
                            loadMachines();
                        }
                    }
                    catch (MSSMUIException ex)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                    }
                    catch (Exception ex)
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
                    }
                }
                else
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Deleting cancelled.", NotificationStates.WARNING);
                }

            }
        }

        //load machines
        public void loadMachines()
        {
            try
            {
                machines = machineryDBHandler.getAllMachines();
                dataGridMachines.Rows.Clear();
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                //binding
                foreach (Machine machine in machines)
                {
                    dataGridMachines.Rows.Add(machine.machineId, machine.serialNumber, machine.name, machine.locationId, machine.workingState, machine.addedBy, machine.addedDate.ToString("MM/dd/yyyy"), machine.description, "Update", "Delete");
                }
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            comboBoxColumn.SelectedItem = "All";
            textBoxKeyword.Clear();
            loadMachines();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Feed Refreshed.", NotificationStates.INFORMATION);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            string keyword = textBoxKeyword.Text;
            string column = null;
            machineSearchResult = null;

            try
            {
                switch (comboBoxColumn.SelectedItem.ToString())
                {
                    case "Machine ID":
                        column = "machine_id";
                        break;
                    case "Location":
                        column = "location_id";
                        break;
                    case "Serial Number":
                        column = "serial_no";
                        break;
                    case "Name":
                        column = "name";
                        break;
                    case "Description":
                        column = "description";
                        break;
                    case "Working State":
                        column = "working_state";
                        break;
                    case "Added By":
                        column = "added_by";
                        break;
                    case "Added Date":
                        column = "added_date";
                        break;
                    case "All":
                        column = "all";
                        break;
                    default:
                        column = "all";
                        break;
                }
            }
            catch (Exception)
            {
                column = "all";
            }

            try
            {
                if (column == "all")
                {
                    machineSearchResult = machineryDBHandler.searchMachine(keyword);
                }
                else
                {
                    machineSearchResult = machineryDBHandler.searchMachinesUsingColumn(column, keyword);
                }

                //binding
                dataGridMachines.Rows.Clear();
                foreach (Machine machine in machineSearchResult)
                {
                    dataGridMachines.Rows.Add(machine.machineId, machine.serialNumber, machine.name, machine.locationId, machine.workingState, machine.addedBy, machine.addedDate.ToString("MM/dd/yyyy"), machine.description, "Update", "Delete");
                }

                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Search Completed", NotificationStates.INFORMATION);
                //dataGridMachines.Columns["machineId"].Visible = false;
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
        }

        private void textBoxKeyword_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Search using keywords or YYYY-MM-DD format for dates", textBoxKeyword);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridMachines.Rows.Count > 0)
            {
                Excel.Application excellApplication = new Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridMachines.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridMachines.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridMachines.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridMachines.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridMachines.Rows[i].Cells[j].Value.ToString();
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
