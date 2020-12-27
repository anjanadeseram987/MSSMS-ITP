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
    public partial class ManageShippingShedules : Form
    {
        private ShippingDBHandler shippingDBHandler = new ShippingDBHandler();
        private List<ShippingSchedule> shippingSchedules = new List<ShippingSchedule>();
        private string selectedScheduleId = null;

        public ManageShippingShedules()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void ManageShippingShedules_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadShippingShedules();
            comboBoxColumn.SelectedItem = "All";

            //hiding management tools/buttons when not necessary
            this.dataGridOngoingSchedules.Columns["OngoingScheduleUpdate"].Visible = false;
            this.dataGridPendingSchedules.Columns["PendingScheduleLoad"].Visible = false;
            this.dataGridOngoingSchedules.Columns["OngoingScheduleStop"].Visible = false;

            if (SessionManager.user.role != "SHMGR")
            {
                this.dataGridPendingSchedules.Columns["PendingScheduleLoad"].Visible = false;
                this.dataGridPendingSchedules.Columns["PendingScheduleUpdate"].Visible = false;
                this.dataGridPendingSchedules.Columns["PendingScheduleDelete"].Visible = false;
                this.dataGridOngoingSchedules.Columns["OngoingScheduleStop"].Visible = false;
                this.dataGridOngoingSchedules.Columns["OngoingScheduleUpdate"].Visible = false;
                this.dataGridExpiredSchedules.Columns["ExpiredScheduleUpdate"].Visible = false;
                this.dataGridExpiredSchedules.Columns["ExpiredScheduleDelete"].Visible = false;
                this.AddShippingSchedule.Visible = false;
            }
            if (SessionManager.user.role != "GLMGR")
            {
                this.dataGridPendingSchedules.Columns["PendingScheduleApprove"].Visible = false;
            }
        }

        private void AddProductionPlan_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            FormHandler.openChildForm(this.Name, this, "AddShippingSchedules", ChildFormType.ADD, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            comboBoxColumn.SelectedItem = "All";
            textBoxKeyword.Clear();
            loadShippingShedules();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Feed Refreshed.", NotificationStates.INFORMATION);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridPendingSchedules.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridPendingSchedules.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridPendingSchedules.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridPendingSchedules.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridPendingSchedules.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridPendingSchedules.Rows[i].Cells[j].Value.ToString();
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

        private void dataGridPendingSchedules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridPendingSchedules.Columns[e.ColumnIndex].Name;
            selectedScheduleId = dataGridPendingSchedules.CurrentRow.Cells["PendingScheduleId"].FormattedValue.ToString();
            String approvalStatus = dataGridPendingSchedules.CurrentRow.Cells["PendingScheduleApprovedBy"].FormattedValue.ToString();

            if (column == "PendingScheduleUpdate")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);
                DialogResult dialogResult;

                foreach (ShippingSchedule shippingSchedule in shippingSchedules)
                {
                    if (shippingSchedule.shippingschedule_id == selectedScheduleId)
                    {
                        //resetting the approval status if already approved
                        if (approvalStatus != "N/A" && approvalStatus != null)
                        {
                            dialogResult = MessageBox.Show("This schedule has been approved.Please be advised that any modifications made will reset the approval status back to 'Pending'.", "Updating an Approved Schedule", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.OK)
                            {
                                shippingDBHandler.modifyApprovalState(DateTime.MinValue, null, shippingSchedule.shippingschedule_id);
                                loadShippingShedules();
                                FormHandler.openChildForm(this.Name, this, "AddShippingSchedules", ChildFormType.UPDATE, shippingSchedule);
                            }
                            else
                            {
                                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Updating cancelled.", NotificationStates.WARNING);
                            }
                        }
                        else
                        {
                            FormHandler.openChildForm(this.Name, this, "AddShippingSchedules", ChildFormType.UPDATE, shippingSchedule);
                        }
                        break;
                    }
                }
            }
            else if (column == "PendingScheduleDelete")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);
                DialogResult dialogResult;
                String dialogText = null;

                if (approvalStatus != "N/A")
                {
                    dialogText = "Please be advised that the selected Shipping Schedule is already approved and will be permanently deleted.";
                }
                else
                {
                    dialogText = "The selected Shipping Schedule will be permanently deleted.";
                }

                dialogResult = MessageBox.Show(dialogText, "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        foreach (ShippingSchedule shippingSchedule in shippingSchedules)
                        {
                            if (shippingSchedule.shippingschedule_id == selectedScheduleId)
                            {
                                if (shippingDBHandler.deleteShippingSchedule(selectedScheduleId, shippingSchedule.contract_no) == true)
                                {
                                    loadShippingShedules();
                                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Shipping Schedule has been deleted Successfully.", NotificationStates.SUCCESS);
                                }
                                break;
                            }
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
            else if (column == "PendingScheduleApprove")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                try
                {
                    if (approvalStatus != "N/A")
                    {
                        if (shippingDBHandler.modifyApprovalState(DateTime.MinValue, null, selectedScheduleId) == true)
                        {
                            loadShippingShedules();
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Shipping Schedule Rejected.", NotificationStates.SUCCESS);
                        }
                    }
                    else
                    {
                        if (shippingDBHandler.modifyApprovalState(DateTime.Now, SessionManager.user.employeeId, selectedScheduleId) == true)
                        {
                            loadShippingShedules();
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Shipping Schedule Approved.", NotificationStates.SUCCESS);
                        }
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
            else if (column == "PendingScheduleStart")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);
                try
                {
                    if (approvalStatus != "N/A")
                    {
                        if (shippingDBHandler.changeScheduleStatus("Loading", selectedScheduleId) == true)
                        {
                            loadShippingShedules();
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Shipping Schedule has been started.", NotificationStates.SUCCESS);
                        }
                    }
                    else
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Shipping Schedule has not been approved yet.", NotificationStates.ERROR);
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

        private void dataGridOngoingSchedules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridOngoingSchedules.Columns[e.ColumnIndex].Name;
            selectedScheduleId = dataGridOngoingSchedules.CurrentRow.Cells["OngoingScheduleId"].FormattedValue.ToString();

            if (column == "OngoingScheduleUpdate")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);
                foreach (ShippingSchedule shippingSchedule in shippingSchedules)
                {
                    if (shippingSchedule.shippingschedule_id == selectedScheduleId)
                    {
                        FormHandler.openChildForm(this.Name, this, "AddShippingSchedule", ChildFormType.UPDATE, shippingSchedule);
                        break;
                    }
                }
            }
            else if (column == "OngoingScheduleStop")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                try
                {
                    if (shippingDBHandler.changeScheduleStatus("Pending", selectedScheduleId) == true)
                    {
                        loadShippingShedules();
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Shipping Schedule has been terminated.", NotificationStates.WARNING);
                        this.VerticalScroll.Value = 0;
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

        private void dataGridExpiredSchedules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridExpiredSchedules.Columns[e.ColumnIndex].Name;
            selectedScheduleId = dataGridExpiredSchedules.CurrentRow.Cells["ExpiredScheduleId"].FormattedValue.ToString();

            if (column == "ExpiredScheduleUpdate")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);
                foreach (ShippingSchedule shippingSchedule in shippingSchedules)
                {
                    if (shippingSchedule.shippingschedule_id == selectedScheduleId)
                    {
                        FormHandler.openChildForm(this.Name, this, "AddShippingSchedule", ChildFormType.UPDATE, shippingSchedule);
                        break;
                    }
                }
            }
            else if (column == "ExpiredScheduleDelete")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);
                DialogResult dialogResult;

                dialogResult = MessageBox.Show("The selected Shipping Schedule will be permanently deleted.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        foreach (ShippingSchedule shippingSchedule in shippingSchedules)
                        {
                            if (shippingSchedule.shippingschedule_id == selectedScheduleId)
                            {
                                if (shippingDBHandler.deleteShippingSchedule(selectedScheduleId, shippingSchedule.contract_no) == true)
                                {
                                    loadShippingShedules();
                                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Shipping Schedule has been deleted Successfully.", NotificationStates.SUCCESS);
                                }
                            }
                            break;
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

        public void loadShippingShedules()
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);

            try
            {
                shippingSchedules = shippingDBHandler.getShippingSchedules();
                dataGridPendingSchedules.Rows.Clear();
                dataGridOngoingSchedules.Rows.Clear();
                dataGridCompletedSchedules.Rows.Clear();
                dataGridExpiredSchedules.Rows.Clear();

                //binding
                foreach (ShippingSchedule shippingSchedule in shippingSchedules)
                {
                    String expStatus = null;
                    if (ValidationHandler.IsBeforeDate(shippingSchedule.loading_date) && shippingSchedule.status == "Pending")
                    {
                        expStatus = "Expired";
                        shippingDBHandler.modifyApprovalState(DateTime.MinValue, null, shippingSchedule.shippingschedule_id);
                    }
                    else
                    {
                        expStatus = shippingSchedule.status;
                    }

                    if (expStatus == "Expired")
                    {
                        dataGridExpiredSchedules.Rows.Add(shippingSchedule.shippingschedule_id, shippingSchedule.contract_no, shippingSchedule.loading_date.ToShortDateString(), shippingSchedule.destination, shippingSchedule.address, shippingSchedule.added_date, shippingSchedule.added_by, shippingSchedule.approved_date, shippingSchedule.approved_by, shippingSchedule.remarks, shippingSchedule.oi_per_ss_count, shippingSchedule.total_mc_count, "Update", "Delete");
                    }
                    else if (expStatus == "Pending")
                    {
                        if (shippingSchedule.approved_date == DateTime.MinValue || shippingSchedule.approved_by == "N/A")
                        {
                            dataGridPendingSchedules.Rows.Add(shippingSchedule.shippingschedule_id, shippingSchedule.contract_no, shippingSchedule.loading_date.ToShortDateString(), shippingSchedule.destination, shippingSchedule.address, shippingSchedule.added_date, shippingSchedule.added_by, "N/A", "N/A", shippingSchedule.remarks, shippingSchedule.oi_per_ss_count, shippingSchedule.total_mc_count, "Approve", "Load", "Update", "Delete");
                        }
                        else
                        {
                            dataGridPendingSchedules.Rows.Add(shippingSchedule.shippingschedule_id, shippingSchedule.contract_no, shippingSchedule.loading_date.ToShortDateString(), shippingSchedule.destination, shippingSchedule.address, shippingSchedule.added_date, shippingSchedule.added_by, shippingSchedule.approved_date, shippingSchedule.approved_by, shippingSchedule.remarks, shippingSchedule.oi_per_ss_count, shippingSchedule.total_mc_count, "Reject", "Load", "Update", "Delete");
                        }
                    }
                    else if (expStatus == "Loading")
                    {
                        dataGridOngoingSchedules.Rows.Add(shippingSchedule.shippingschedule_id, shippingSchedule.contract_no, shippingSchedule.loading_date.ToShortDateString(), shippingSchedule.destination, shippingSchedule.address, shippingSchedule.added_date, shippingSchedule.added_by, shippingSchedule.approved_date, shippingSchedule.approved_by, shippingSchedule.remarks, shippingSchedule.oi_per_ss_count, shippingSchedule.total_mc_count, "Stop", "Update");
                    }
                    else if (expStatus == "Completed")
                    {
                        dataGridCompletedSchedules.Rows.Add(shippingSchedule.shippingschedule_id, shippingSchedule.contract_no, shippingSchedule.loading_date.ToShortDateString(), shippingSchedule.destination, shippingSchedule.address, shippingSchedule.added_date, shippingSchedule.added_by, shippingSchedule.approved_date, shippingSchedule.approved_by, shippingSchedule.remarks, shippingSchedule.oi_per_ss_count, shippingSchedule.total_mc_count);
                    }
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
}
