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

namespace MSSMS
{
    public partial class ManageIssues : Form
    {
        private MachineryDBHandler machineryDBHandler = new MachineryDBHandler();
        private List<MachineIssue> machineIssues = new List<MachineIssue>();
        private String selectedMachineId = null;

        public ManageIssues()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void ManageIssues_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadMachineIssues();
            comboBoxColumn.SelectedItem = "All";

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "FGOPR")
            {
                this.dataGridIssues.Columns["Update"].Visible = false;
                this.dataGridIssues.Columns["Delete"].Visible = false;
                this.btnAddIssue.Visible = false;
            }

            if(SessionManager.user.role != "ENGNR")
            {
                this.dataGridIssues.Columns["Resolve"].Visible = false;
            }
        }

        private void btnAddIssue_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            FormHandler.openChildForm(this.Name, this,"AddIssue", ChildFormType.ADD, null);
        }

        private void dataGridIssues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridIssues.Columns[e.ColumnIndex].Name;
            String status = dataGridIssues.CurrentRow.Cells["Status"].FormattedValue.ToString();
            String selectedIssueId = dataGridIssues.CurrentRow.Cells["IssueId"].FormattedValue.ToString();

            if (column == "Update")
            {
                foreach (MachineIssue machineIssue in machineIssues)
                {
                    if (machineIssue.issue_id == selectedIssueId)
                    {
                        NotificationManager.hideInAppNotification(panelInAppNotifications);
                        FormHandler.openChildForm(this.Name, this, "AddIssue", ChildFormType.UPDATE, machineIssue);
                        break;
                    }
                }
            }
            else if (column == "Delete")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                if (status == "Pending")
                {
                    DialogResult dialogResult;
                    dialogResult = MessageBox.Show("The selected Issue Details will be permanently deleted.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.OK)
                    {
                        try
                        {
                            if (machineryDBHandler.deleteMachineIssue(selectedIssueId) == true)
                            {
                                loadMachineIssues();
                                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Machine Issue Details Deleted Successfully.", NotificationStates.SUCCESS);
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
                else
                {
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "The Selected Issue has been already resolved. Resolved issues cannot be deleted as they are being kept for future references.", NotificationStates.ERROR);
                }
            }
            else if(column == "Resolve")
            {
                String newStatus = null;
                if(status == "Pending")
                {
                    newStatus = "Resolved";
                } else
                {
                    newStatus = "Pending";
                }

                try
                {
                    if (machineryDBHandler.updateMachineIssueStatus(selectedIssueId, newStatus) == true)
                    {
                        loadMachineIssues();
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Machine Issue status was modified Successfully.", NotificationStates.SUCCESS);
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
        }

        //load machines
        public void loadMachineIssues()
        {
            try
            {
                if (SessionManager.user.role == "ENGNR" || SessionManager.user.role == "PRMGR")
                {
                    machineIssues = machineryDBHandler.getAllMachineIssues();
                }
                else
                {
                    machineIssues = machineryDBHandler.getAllMachineIssuesByUser(SessionManager.user.employeeId);
                }

                dataGridIssues.Rows.Clear();

                //binding
                foreach (MachineIssue machineIssue in machineIssues)
                {
                    if (machineIssue.status == "Pending")
                    {
                        dataGridIssues.Rows.Add(machineIssue.issue_id, machineIssue.machine_id + " - " + machineIssue.machine.name + " [" + machineIssue.machine.serialNumber + "]", machineIssue.subject, machineIssue.description, machineIssue.submitted_by, machineIssue.submitted_date.ToString("MM/dd/yyyy"), machineIssue.status, "Mark as Resolved", "Update", "Delete");
                    }
                    else if (machineIssue.status == "Resolved")
                    {
                        dataGridIssues.Rows.Add(machineIssue.issue_id, machineIssue.machine_id + " - " + machineIssue.machine.name + " [" + machineIssue.machine.serialNumber + "]", machineIssue.subject, machineIssue.description, machineIssue.submitted_by, machineIssue.submitted_date.ToString("MM/dd/yyyy"), machineIssue.status, "Mark as Pending", "Update", "Delete");
                    }
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
            loadMachineIssues();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Feed Refreshed.", NotificationStates.INFORMATION);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridIssues.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridIssues.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridIssues.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridIssues.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridIssues.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridIssues.Rows[i].Cells[j].Value.ToString();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
