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
    public partial class ManageStorage : Form
    {
        private StoreDBHandler storeDBHandler = new StoreDBHandler();
        private List<StoredGood> storedGoods = new List<StoredGood>();
        private String selectedMcNo = null;
        private String selectedOrderItemNo = null;

        public ManageStorage()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void ManageStorage_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadStoredGoods();
            comboBoxColumn.SelectedItem = "All";

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "STKPR")
            {
                this.dataGridStoredGoods.Columns["Update"].Visible = false;
                this.dataGridStoredGoods.Columns["Delete"].Visible = false;
                this.btnAddItems.Visible = false;
                this.btnIssueGoods.Visible = false;
            }
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            FormHandler.openChildForm(this.Name, this, "AddItemsToStore", ChildFormType.ADD, null);
        }

        private void btnIssueItems_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            FormHandler.openChildForm(this.Name, this, "IssueGoods", ChildFormType.ADD, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            comboBoxColumn.SelectedItem = "All";
            textBoxKeyword.Clear();
            loadStoredGoods();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Feed Refreshed.", NotificationStates.INFORMATION);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridStoredGoods.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridStoredGoods.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridStoredGoods.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridStoredGoods.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridStoredGoods.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridStoredGoods.Rows[i].Cells[j].Value.ToString();
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

        private void dataGridStoredoods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridStoredGoods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridStoredGoods.Columns[e.ColumnIndex].Name;
            selectedOrderItemNo = dataGridStoredGoods.CurrentRow.Cells["OrderItemNo"].FormattedValue.ToString();
            selectedMcNo = dataGridStoredGoods.CurrentRow.Cells["MCNo"].FormattedValue.ToString();
            String selectedMcStatus = dataGridStoredGoods.CurrentRow.Cells["Status"].FormattedValue.ToString();

            if (column == "Update")
            {
                foreach (StoredGood storedGood in storedGoods)
                {
                    if (storedGood.sg_orderitem_no == selectedOrderItemNo && storedGood.sg_mc_no == selectedMcNo)
                    {
                        if (storedGood.sg_status == "In Storage")
                        {
                            NotificationManager.hideInAppNotification(panelInAppNotifications);
                            FormHandler.openChildForm(this.Name, this, "AddItemsToStore", ChildFormType.UPDATE, storedGood);
                        }
                        else
                        {
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "The Selected  MC details cannot be updated since the MC has been already released for shipping or removed from storage.", NotificationStates.ERROR);
                        }
                        break;
                    }
                }
            }
            else if (column == "Delete")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                if (selectedMcStatus == "In Storage")
                {
                    DialogResult dialogResult;
                    dialogResult = MessageBox.Show("The selected Master Carton Details will be permanently deleted from storage.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.OK)
                    {
                        StoredGood selectedStoredGood = null;
                        foreach (StoredGood storedGood in storedGoods)
                        {
                            if (storedGood.sg_orderitem_no == selectedOrderItemNo && storedGood.sg_mc_no == selectedMcNo)
                            {
                                selectedStoredGood = storedGood;
                                break;
                            }
                        }

                        if (selectedStoredGood == null)
                        {
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Could not delete the selected Master Carton.\nERRORCODE: ?", NotificationStates.ERROR);
                            return;
                        }

                        try
                        {
                            if (storeDBHandler.deleteMasterCartonFromStorage(int.Parse(selectedMcNo), selectedOrderItemNo, selectedStoredGood) == true)
                            {
                                loadStoredGoods();
                                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Master Carton Details Deleted Successfully.", NotificationStates.SUCCESS);
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
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "The selected MC Details cannot be deleted as it is either moved out from the storage or has been already shipped.", NotificationStates.ERROR);
                }
            }
        }

        public void loadStoredGoods()
        {
            try
            {
                storedGoods = storeDBHandler.getAllStoredMasterCartons();
                dataGridStoredGoods.Rows.Clear();
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                //binding
                foreach (StoredGood storedGood in storedGoods)
                {
                    dataGridStoredGoods.Rows.Add(storedGood.finishedGood.orderItem.order.order_no, storedGood.sg_orderitem_no, storedGood.sg_mc_no, storedGood.finishedGood.orderItem.buyer.buyerName + " - " + storedGood.finishedGood.orderItem.brand.brandName, storedGood.finishedGood.orderItem.orderItemContent.barcode, storedGood.finishedGood.orderItem.teaProduct.teaProductName + " " + storedGood.finishedGood.orderItem.teaProduct.teaProductflavor + " [" + storedGood.finishedGood.orderItem.teaProduct.teaProductserialNo + "]", "[" + storedGood.finishedGood.orderItem.orderItemContent.teabagWeight + "g] x [" + storedGood.finishedGood.orderItem.orderItemContent.teabagQuantity + "] x [" + storedGood.finishedGood.orderItem.orderItemContent.icQuantity + "]", storedGood.finishedGood.orderItem.location.location_name + " [" + storedGood.finishedGood.orderItem.location.location_id + "]", storedGood.sg_stored_by, storedGood.sg_stored_date, (storedGood.finishedGood.orderItem.shippingSchedule.loading_date == DateTime.MinValue) ? "N/A" : storedGood.finishedGood.orderItem.shippingSchedule.loading_date.ToString(), storedGood.finishedGood.fg_exp_date, storedGood.sg_status, "Update", "Delete");
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
