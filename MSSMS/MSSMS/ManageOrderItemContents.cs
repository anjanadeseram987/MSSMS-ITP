using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class ManageOrderItemContents : Form
    {
        private BuyerDBHandler buyerDBHandler = new BuyerDBHandler();
        private List<OrderItemContent> orderItemContents = new List<OrderItemContent>();
        private String selectedContentId = null;

        public ManageOrderItemContents()
        {
            InitializeComponent();
        }

        private void ManageBuyers_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadOrderItemContents();
            comboBoxColumn.SelectedItem = "All";

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "PRMGR")
            {
                this.dataGridContents.Columns["Update"].Visible = false;
                this.dataGridContents.Columns["Delete"].Visible = false;
                this.btnAddOrderContent.Visible = false;
            }
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void btnAddOrderContent_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            FormHandler.openChildForm(this.Name, this, "AddOrderItemContents", ChildFormType.ADD, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            comboBoxColumn.SelectedItem = "All";
            textBoxKeyword.Clear();
            loadOrderItemContents();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Feed Refreshed.", NotificationStates.INFORMATION);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridContents.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridContents.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridContents.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridContents.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridContents.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridContents.Rows[i].Cells[j].Value.ToString();
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

        private void dataGridContents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridContents.Columns[e.ColumnIndex].Name;

            if (column == "Update")
            {
                selectedContentId = dataGridContents.CurrentRow.Cells["Barcode"].FormattedValue.ToString();

                foreach (OrderItemContent orderItemContent in orderItemContents)
                {
                    if (orderItemContent.barcode == selectedContentId)
                    {
                        NotificationManager.hideInAppNotification(panelInAppNotifications);
                        FormHandler.openChildForm(this.Name, this, "AddOrderItemContents", ChildFormType.UPDATE, orderItemContent);
                        break;
                    }
                }
            }
            else if (column == "Delete")
            {
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                selectedContentId = dataGridContents.CurrentRow.Cells["Barcode"].FormattedValue.ToString();
                int count = int.Parse(dataGridContents.CurrentRow.Cells["count"].FormattedValue.ToString());

                if (count == 0)
                {
                    DialogResult dialogResult;
                    dialogResult = MessageBox.Show("The selected Order Content will be permanently deleted.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.OK)
                    {
                        try
                        {
                            if (buyerDBHandler.deleteOrderItemContent(selectedContentId) == true)
                            {
                                loadOrderItemContents();
                                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Buyer Deleted Successfully.", NotificationStates.SUCCESS);
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
                    NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "The selected order content cannot be deleted as it is currently shared by several orders.", NotificationStates.ERROR);
                    return;
                }
            }
        }

        public void loadOrderItemContents()
        {
            try
            {
                orderItemContents = buyerDBHandler.getAllOrderItemContents();
                dataGridContents.Rows.Clear();
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                //binding
                foreach (OrderItemContent orderItemContent in orderItemContents)
                {
                    dataGridContents.Rows.Add(orderItemContent.barcode, orderItemContent.buyerName, orderItemContent.brandName, (orderItemContent.teaproduct.teaProductserialNo + ": " + orderItemContent.teaproduct.teaProductName + orderItemContent.teaproduct.teaProductflavor), (orderItemContent.teabag.materialSerialNo + ": " + orderItemContent.teabag.materialName + orderItemContent.teabag.teabagType), orderItemContent.teabagQuantity, orderItemContent.icQuantity, orderItemContent.teabagWeight, orderItemContent.MCMinWeight, orderItemContent.MCMaxWeight, orderItemContent.remark, orderItemContent.numberOfOrderItemsAvailable, "Update", "Delete");
                }
                dataGridContents.Columns["count"].Visible = false;

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
