using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class ManageProductionPlans : Form
    {
        private ProductionDBHandler productionDBHandler = new ProductionDBHandler();
        private List<ProductionPlan> productionPlans = new List<ProductionPlan>();
        private string selectedProdductionPlanId = null;

        public ManageProductionPlans()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void ManageProductionPlans_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadProductionPlans();
            comboBoxColumn.SelectedItem = "All";

            //hiding management tools/buttons when not necessary
            this.dataGridViewOngoingProductionPlans.Columns["OngoingPlanUpdate"].Visible = false;

            if (SessionManager.user.role != "PRMGR")
            {
                this.dataGridViewPendingProductionPlans.Columns["PendingPlanStart"].Visible = false;
                this.dataGridViewPendingProductionPlans.Columns["PendingPlanUpdate"].Visible = false;
                this.dataGridViewPendingProductionPlans.Columns["PendingPlanDelete"].Visible = false;
                this.dataGridViewOngoingProductionPlans.Columns["OngoingPlanStop"].Visible = false;
                this.dataGridViewOngoingProductionPlans.Columns["OngoingPlanUpdate"].Visible = false;
                this.dataGridViewExpiredProductionPlans.Columns["ExpiredPlanUpdate"].Visible = false;
                this.dataGridViewExpiredProductionPlans.Columns["ExpiredPlanDelete"].Visible = false;
                this.AddProductionPlan.Visible = false;
            }
            if (SessionManager.user.role != "GLMGR")
            {
                this.dataGridViewPendingProductionPlans.Columns["PendingPlanApprove"].Visible = false;
            }
        }

        private void AddProductionPlan_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            FormHandler.openChildForm(this.Name, this,"AddProductionPlan", ChildFormType.ADD, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            comboBoxColumn.SelectedItem = "All";
            textBoxKeyword.Clear();
            loadProductionPlans();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Feed Refreshed.", NotificationStates.INFORMATION);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridViewPendingProductionPlans.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridViewPendingProductionPlans.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridViewPendingProductionPlans.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridViewPendingProductionPlans.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewPendingProductionPlans.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridViewPendingProductionPlans.Rows[i].Cells[j].Value.ToString();
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

        private void btnPrintOngoing_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridViewOngoingProductionPlans.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridViewOngoingProductionPlans.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridViewOngoingProductionPlans.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridViewOngoingProductionPlans.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewOngoingProductionPlans.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridViewOngoingProductionPlans.Rows[i].Cells[j].Value.ToString();
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

        private void btnPrintCompleted_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridViewCompletedProductionPlans.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridViewCompletedProductionPlans.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridViewCompletedProductionPlans.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridViewCompletedProductionPlans.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewCompletedProductionPlans.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridViewCompletedProductionPlans.Rows[i].Cells[j].Value.ToString();
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

        private void btnPrintExpired_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridViewExpiredProductionPlans.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridViewExpiredProductionPlans.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridViewExpiredProductionPlans.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridViewExpiredProductionPlans.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewExpiredProductionPlans.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridViewExpiredProductionPlans.Rows[i].Cells[j].Value.ToString();
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

        private void dataGridViewPendingProductionPlans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridViewPendingProductionPlans.Columns[e.ColumnIndex].Name;
            selectedProdductionPlanId = dataGridViewPendingProductionPlans.CurrentRow.Cells["PendingPlanId"].FormattedValue.ToString();
            String approvalStatus = dataGridViewPendingProductionPlans.CurrentRow.Cells["PendingPlanApprovedBy"].FormattedValue.ToString();

            if (column == "PendingPlanUpdate")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);
                DialogResult dialogResult;

                foreach (ProductionPlan productionPlan in productionPlans)
                {
                    if (productionPlan.productionplan_id == selectedProdductionPlanId)
                    {
                        //resetting the approval status if already approved
                        if (approvalStatus != "N/A" && approvalStatus != null)
                        {
                            dialogResult = MessageBox.Show("This schedule has been approved.Please be advised that any modifications made will reset the approval status back to 'Pending'.", "Updating an Approved Schedule", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.OK)
                            {
                                productionDBHandler.modifyApprovalState(DateTime.MinValue, null, selectedProdductionPlanId);
                            }
                        }

                        FormHandler.openChildForm(this.Name, this, "AddProductionPlan", ChildFormType.UPDATE, productionPlan);
                        break;
                    }
                }
            }
            else if (column == "PendingPlanDelete")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);
                DialogResult dialogResult;
                String dialogText = null;
                
                if(approvalStatus != "N/A")
                {
                    dialogText = "The selected Production Plan is already approved and will be permanently deleted.";
                } 
                else
                {
                    dialogText = "The selected Production Plan will be permanently deleted.";
                }

                dialogResult = MessageBox.Show(dialogText, "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (productionDBHandler.deleteProductionPlan(selectedProdductionPlanId) == true)
                        {
                            loadProductionPlans();
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Production Plan Deleted Successfully.", NotificationStates.SUCCESS);
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
            else if (column == "PendingPlanApprove")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                try
                {
                    if (approvalStatus != "N/A")
                    {
                        if (productionDBHandler.modifyApprovalState(DateTime.MinValue, null, selectedProdductionPlanId) == true)
                        {
                            loadProductionPlans();
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Production Plan Rejected.", NotificationStates.SUCCESS);
                        }
                    }
                    else
                    {
                        if (productionDBHandler.modifyApprovalState(DateTime.Now, SessionManager.user.employeeId, selectedProdductionPlanId) == true)
                        {
                            loadProductionPlans();
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Production Plan Approved.", NotificationStates.SUCCESS);
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
            else if (column == "PendingPlanStart")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                try
                {
                    if (approvalStatus != "N/A")
                    {
                        if (productionDBHandler.changePlanStatus("In Production", selectedProdductionPlanId) == true)
                        {
                            loadProductionPlans();
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Production plan set for production successfully.", NotificationStates.SUCCESS);
                        }
                    }
                    else
                    {
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Production plan has not been approved yet.", NotificationStates.ERROR);
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

        private void dataGridViewOngoingProductionPlans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridViewOngoingProductionPlans.Columns[e.ColumnIndex].Name;
            selectedProdductionPlanId = dataGridViewOngoingProductionPlans.CurrentRow.Cells["OngoingPlanId"].FormattedValue.ToString();

            if (column == "OngoingPlanUpdate")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);
                foreach (ProductionPlan productionPlan in productionPlans)
                {
                    if (productionPlan.productionplan_id == selectedProdductionPlanId)
                    {
                        FormHandler.openChildForm(this.Name, this, "AddProductionPlan", ChildFormType.UPDATE, productionPlan);
                        break;
                    }
                }
            }
            else if (column == "OngoingPlanStop")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                try
                {
                    if (productionDBHandler.changePlanStatus("Pending", selectedProdductionPlanId) == true)
                    {
                        loadProductionPlans();
                        NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Production plan has been terminated.", NotificationStates.WARNING);
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

        private void dataGridViewExpiredProductionPlans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridViewExpiredProductionPlans.Columns[e.ColumnIndex].Name;
            selectedProdductionPlanId = dataGridViewExpiredProductionPlans.CurrentRow.Cells["ExpiredPlanId"].FormattedValue.ToString();
            
            if (column == "ExpiredPlanUpdate")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);
                foreach (ProductionPlan productionPlan in productionPlans)
                {
                    if (productionPlan.productionplan_id == selectedProdductionPlanId)
                    {
                        FormHandler.openChildForm(this.Name, this, "AddProductionPlan", ChildFormType.UPDATE, productionPlan);
                        break;
                    }
                }
            }
            else if (column == "ExpiredPlanDelete")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);
                DialogResult dialogResult;

                dialogResult = MessageBox.Show( "The selected Production Plan will be permanently deleted.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (productionDBHandler.deleteProductionPlan(selectedProdductionPlanId) == true)
                        {
                            loadProductionPlans();
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Production Plan Deleted Successfully.", NotificationStates.SUCCESS);
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

        public void loadProductionPlans()
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);

            try
            {
                productionPlans = productionDBHandler.getAllProductionPlans();
                dataGridViewPendingProductionPlans.Rows.Clear();
                dataGridViewOngoingProductionPlans.Rows.Clear();
                dataGridViewCompletedProductionPlans.Rows.Clear();
                dataGridViewExpiredProductionPlans.Rows.Clear();

                //binding
                foreach (ProductionPlan productionPlan in productionPlans)
                {
                    String expStatus = null;
                    if (ValidationHandler.IsBeforeDate(productionPlan.start_date) && productionPlan.status == "Pending")
                    {
                        expStatus = "Expired";
                        productionDBHandler.modifyApprovalState(DateTime.MinValue, null, productionPlan.productionplan_id);
                    }
                    else
                    {
                        expStatus = productionPlan.status;
                    }

                    if(expStatus == "Expired")
                    {
                        dataGridViewExpiredProductionPlans.Rows.Add(productionPlan.productionplan_id, productionPlan.productionplan_name, productionPlan.start_date, productionPlan.end_date, productionPlan.oi_count, productionPlan.added_date, productionPlan.added_by, "N/A", productionPlan.approved_by, expStatus, "Update", "Delete");
                    } 
                    else if (expStatus=="Pending")
                    {
                        if (productionPlan.approved_date == DateTime.MinValue || productionPlan.approved_by == "N/A")
                        {
                            dataGridViewPendingProductionPlans.Rows.Add(productionPlan.productionplan_id, productionPlan.productionplan_name, productionPlan.start_date, productionPlan.end_date, productionPlan.oi_count, productionPlan.added_date, productionPlan.added_by, "N/A", productionPlan.approved_by, expStatus, "Start", "Update", "Delete", "Approve");
                        }
                        else
                        {
                            dataGridViewPendingProductionPlans.Rows.Add(productionPlan.productionplan_id, productionPlan.productionplan_name, productionPlan.start_date, productionPlan.end_date, productionPlan.oi_count, productionPlan.added_date, productionPlan.added_by, productionPlan.approved_date, productionPlan.approved_by, expStatus, "Start", "Update", "Delete", "Reject");
                        }
                    }
                    else if (expStatus == "In Production")
                    {
                        dataGridViewOngoingProductionPlans.Rows.Add(productionPlan.productionplan_id, productionPlan.productionplan_name, productionPlan.start_date, productionPlan.end_date, productionPlan.oi_count, productionPlan.added_date, productionPlan.added_by, productionPlan.approved_date, productionPlan.approved_by, expStatus, "Stop", "Update");
                    }
                    else if (expStatus == "Completed")
                    {
                        dataGridViewCompletedProductionPlans.Rows.Add(productionPlan.productionplan_id, productionPlan.productionplan_name, productionPlan.start_date, productionPlan.end_date, productionPlan.oi_count, productionPlan.added_date, productionPlan.added_by, productionPlan.approved_date, productionPlan.approved_by, expStatus);
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
