using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class ManageTeaProducts : Form
    {
        private TeaProductDBHandler teaProductDBHandler = new TeaProductDBHandler();
        private List<TeaProduct> teaProducts = new List<TeaProduct>();
        private List<TeaProduct> teaProductsSearchResult = new List<TeaProduct>(); 
        private string selectedTeaProduct = null;
        

        public ManageTeaProducts(Object employeeDBHandler)
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void ManageTeaProducts_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadTeaProducts();
            comboBoxColumn.SelectedItem = "All";

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "PRMGR")
            {
                this.dataGridTeaProducts.Columns["updateTP"].Visible = false;
                this.dataGridTeaProducts.Columns["deleteTP"].Visible = false;
                this.btnAddTeaProduct.Visible = false;
            }
        }

        private void btnAddTeaProduct_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            FormHandler.openChildForm(this.Name, this, "AddTeaProducts", ChildFormType.ADD, null);
        }

        private void dataGridTeaProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridTeaProducts.Columns[e.ColumnIndex].Name;

            if (column == "updateTP")
            {
                selectedTeaProduct = dataGridTeaProducts.CurrentRow.Cells["teaProductId"].FormattedValue.ToString();

                foreach (TeaProduct teaProduct in teaProducts)
                {
                    if (teaProduct.teaProductId == selectedTeaProduct)
                    {
                        NotificationManager.hideInAppNotification(panelInAppNotifications);
                        FormHandler.openChildForm(this.Name, this, "AddTeaProducts", ChildFormType.UPDATE, teaProduct);
                        break;
                    }
                }
            }
            else if (column == "deleteTP")
            {
                selectedTeaProduct = dataGridTeaProducts.CurrentRow.Cells["teaProductId"].FormattedValue.ToString();

                NotificationManager.hideInAppNotification(panelInAppNotifications);
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("The selected Tea Product will be permanently deleted.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (teaProductDBHandler.deleteTeaProduct(selectedTeaProduct) == true)
                        {
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Tea Product Deleted Successfully.", NotificationStates.SUCCESS);
                            loadTeaProducts();
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
            loadTeaProducts();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Feed Refreshed.", NotificationStates.INFORMATION);
        }

        public void loadTeaProducts()
        {
            try
            {
                teaProducts = teaProductDBHandler.getAllTeaProducts();
                dataGridTeaProducts.Rows.Clear();
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                //binding
                foreach (TeaProduct teaProduct in teaProducts)
                {
                    dataGridTeaProducts.Rows.Add(teaProduct.teaProductId, teaProduct.teaProductserialNo, teaProduct.teaProductName, teaProduct.teaProductflavor, teaProduct.teaProductdescription, teaProduct.teaProductavailability, "Update", "Delete");
                }
                dataGridTeaProducts.Columns["teaProductId"].Visible = false;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            string keyword = textBoxKeyword.Text;
            string column = null;
            teaProductsSearchResult = null;

            try
            {
                switch (comboBoxColumn.SelectedItem.ToString())
                {
                    case "Serial Number":
                        column = "teaproduct_serial_no";
                        break;
                    case "Tea Flavor":
                        column = "teaproduct_flavor";
                        break;
                    case "Tea Type":
                        column = "teaproduct_name";
                        break;
                    case "Description":
                        column = "teaproduct_description";
                        break;
                    case "Availability":
                        column = "teaproduct_availability";
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
                    teaProductsSearchResult = teaProductDBHandler.searchTebproducts(keyword);
                }
                else
                {
                    teaProductsSearchResult = teaProductDBHandler.searchTebproductsUsingColumn(column, keyword);
                }

                //binding
                dataGridTeaProducts.Rows.Clear();
                foreach (TeaProduct teaProduct in teaProductsSearchResult)
                {
                    dataGridTeaProducts.Rows.Add(teaProduct.teaProductId, teaProduct.teaProductserialNo, teaProduct.teaProductName, teaProduct.teaProductflavor, teaProduct.teaProductdescription, teaProduct.teaProductavailability, "Update", "Delete");
                }

                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Search Completed", NotificationStates.INFORMATION);
                dataGridTeaProducts.Columns["teaProductId"].Visible = false;
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridTeaProducts.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridTeaProducts.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridTeaProducts.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridTeaProducts.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridTeaProducts.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridTeaProducts.Rows[i].Cells[j].Value.ToString();
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
