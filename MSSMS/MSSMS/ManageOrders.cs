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
using Excel = Microsoft.Office.Interop.Excel;

namespace MSSMS
{
    public partial class ManageOrders : Form
    {
        private OrderDBHandler orderDBHandler = new OrderDBHandler();
        private List<OrderItem> orderItems = new List<OrderItem>();
        private List<OrderItem> orderItemsSearchResult = new List<OrderItem>();
        private string selectedOrderItem = null;

        public ManageOrders()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void ManageOrders_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadAllOrderItems();
            comboBoxColumn.SelectedItem = "All";

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "PRMGR")
            {
                this.dataGridOrderItems.Columns["Delete"].Visible = false;
            }

        }

        private void dataGridOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridOrderItems.Columns[e.ColumnIndex].Name;

            /*if (column == "Update")
            {
                selectedTeabagMaterial = dataGridTeabagMaterials.CurrentRow.Cells["TeabagMaterialId"].FormattedValue.ToString();

                foreach (TeabagMaterial teabagMaterial in teabagMaterials)
                {
                    if (teabagMaterial.materialId == selectedTeabagMaterial)
                    {
                        NotificationManager.hideInAppNotification(panelInAppNotifications);
                        FormHandler.openChildForm(this.Name, this, "AddTeabagMaterial", ChildFormType.UPDATE, teabagMaterial);
                        break;
                    }
                }
            }
            else */if (column == "Delete")
            {
                selectedOrderItem = dataGridOrderItems.CurrentRow.Cells["OrderItemNo"].FormattedValue.ToString();

                NotificationManager.hideInAppNotification(panelInAppNotifications);
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("The selected Order Item will be permanently deleted.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (orderDBHandler.deleteOrderItem(selectedOrderItem) == true)
                        {
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Order Item Deleted Successfully.", NotificationStates.SUCCESS);
                            loadAllOrderItems();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            comboBoxColumn.SelectedItem = "All";
            textBoxKeyword.Clear();
            loadAllOrderItems();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Feed Refreshed.", NotificationStates.INFORMATION);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridOrderItems.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridOrderItems.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridOrderItems.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridOrderItems.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridOrderItems.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridOrderItems.Rows[i].Cells[j].Value.ToString();
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

        public void loadAllOrderItems()
        {
            try
            {
                orderItems = orderDBHandler.getAllOrderItems();
                dataGridOrderItems.Rows.Clear();
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                //binding
                foreach (OrderItem orderItem in orderItems)
                {
                    dataGridOrderItems.Rows.Add(orderItem.contractNo, orderItem.order.order_no, orderItem.orderItemNo, orderItem.buyer.buyerName, orderItem.brand.brandName, (orderItem.orderItemContent.barcode + " " + orderItem.teaProduct.teaProductName + " " + orderItem.teaProduct.teaProductflavor + " (" + orderItem.teaProduct.teaProductserialNo + ") " + orderItem.orderItemContent.teabagWeight+"g x"+orderItem.orderItemContent.teabagQuantity+"x"+orderItem.mcQuantity), orderItem.mcQuantity, orderItem.shippingDetails.location, orderItem.shippingDetails.address, orderItem.orderitem_status, "Delete");
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
