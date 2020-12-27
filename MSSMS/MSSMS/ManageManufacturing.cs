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
    public partial class ManageManufacturing : Form
    {
        private FinishedGoodsDBHandler finishedGoodsDBHandler = new FinishedGoodsDBHandler();
        private List<FinishedGood> finishedGoods = new List<FinishedGood>();
        private String selectedMcNo = null;
        private String selectedOrderItemNo = null;

        public ManageManufacturing()
        {
            InitializeComponent();
        }

        private void ManageManufacturing_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadFinishedGoods();
            comboBoxColumn.SelectedItem = "All";

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "FGOPR")
            {
                this.dataGridFinishedGoods.Columns["Update"].Visible = false;
                this.dataGridFinishedGoods.Columns["Delete"].Visible = false;
                this.btnAddFinishedGoods.Visible = false;
            }
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void btnAddFinishedGoods_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            FormHandler.openChildForm(this.Name, this, "AddFinishedGoods", ChildFormType.ADD, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            comboBoxColumn.SelectedItem = "All";
            textBoxKeyword.Clear();
            loadFinishedGoods();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Feed Refreshed.", NotificationStates.INFORMATION);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridFinishedGoods.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridFinishedGoods.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridFinishedGoods.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridFinishedGoods.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridFinishedGoods.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridFinishedGoods.Rows[i].Cells[j].Value.ToString();
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

        private void dataGridFinishedGoods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridFinishedGoods.Columns[e.ColumnIndex].Name;
            selectedOrderItemNo = dataGridFinishedGoods.CurrentRow.Cells["OrderItemNo"].FormattedValue.ToString();
            selectedMcNo = dataGridFinishedGoods.CurrentRow.Cells["MCNo"].FormattedValue.ToString();
            String selectedMcStatus = dataGridFinishedGoods.CurrentRow.Cells["Status"].FormattedValue.ToString();

            if (column == "Update")
            {
                foreach (FinishedGood finishedGood in finishedGoods)
                {
                    if (finishedGood.fg_orderitem_no == selectedOrderItemNo && finishedGood.fg_mc_no == selectedMcNo)
                    {
                        if (finishedGood.fg_status != "Shipped")
                        {
                            NotificationManager.hideInAppNotification(panelInAppNotifications);
                            FormHandler.openChildForm(this.Name, this, "AddFinishedGoods", ChildFormType.UPDATE, finishedGood);
                        }
                        else
                        {
                             NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "The Selected MC has been already shipped. Shipped MC details cannot be updated unless they are returned.", NotificationStates.ERROR);
                        }
                        break;
                    }
                }
            }
            else if (column == "Delete")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                if (selectedMcStatus == "Completed")
                {
                    DialogResult dialogResult;
                    dialogResult = MessageBox.Show("The selected Master Carton Details will be permanently deleted.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.OK)
                    {
                        FinishedGood selectedFinishedGood = null;
                        foreach (FinishedGood finishedGood in finishedGoods)
                        {
                            if (finishedGood.fg_orderitem_no == selectedOrderItemNo && finishedGood.fg_mc_no == selectedMcNo)
                            {
                                selectedFinishedGood = finishedGood;
                                break;
                            }
                        }

                        if (selectedFinishedGood == null)
                        {
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Could not delete the selected Master Carton.", NotificationStates.ERROR);
                            return;
                        }

                        try
                        {
                            if (finishedGoodsDBHandler.deleteMasterCarton(int.Parse(selectedMcNo), selectedOrderItemNo, selectedFinishedGood) == true)
                            {
                                loadFinishedGoods();
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
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "The selected MC Details cannot be deleted as it is either in storage or has been already shipped.", NotificationStates.ERROR);
                }
            }
        }

        public void loadFinishedGoods()
        {
            try
            {
                finishedGoods = finishedGoodsDBHandler.getAllCompletedMasterCartos();
                dataGridFinishedGoods.Rows.Clear();
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                //binding
                foreach (FinishedGood finishedGood in finishedGoods)
                {
                    dataGridFinishedGoods.Rows.Add(finishedGood.orderItem.order.order_no, finishedGood.fg_orderitem_no, finishedGood.fg_mc_no, finishedGood.orderItem.buyer.buyerName, finishedGood.orderItem.brand.brandName, finishedGood.orderItem.orderItemContent.barcode, finishedGood.orderItem.teaProduct.teaProductName + " " + finishedGood.orderItem.teaProduct.teaProductflavor + " [" + finishedGood.orderItem.teaProduct.teaProductserialNo + "]", finishedGood.orderItem.teabagMaterial.materialName + " " + finishedGood.orderItem.teabagMaterial.teabagType + " [" + finishedGood.orderItem.teabagMaterial.materialSerialNo + "]", "[" + finishedGood.orderItem.orderItemContent.teabagWeight + "g] x [" + finishedGood.orderItem.orderItemContent.teabagQuantity + "] x [" + finishedGood.orderItem.orderItemContent.icQuantity + "]", finishedGood.fg_exp_date, finishedGood.fg_mc_weight, finishedGood.fg_added_date, finishedGood.fg_added_by, finishedGood.orderItem.location.location_name + " [" + finishedGood.orderItem.location.location_id + "]", finishedGood.fg_status, (finishedGood.orderItem.shippingSchedule.loading_date == DateTime.MinValue) ? "N/A" : finishedGood.orderItem.shippingSchedule.loading_date.ToString(), "Update", "Delete");
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
