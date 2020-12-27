using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MSSMS
{
    public partial class ManageBrands : Form
    {
        private BuyerDBHandler buyerDBHandler = new BuyerDBHandler();
        private List<Brand> brands = new List<Brand>();
        private List<Brand> brandsSearchResults = new List<Brand>();
        private String selectedBrandId = null;

        public ManageBrands()
        {
            InitializeComponent();
        }

        private void ManageBrands_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadBrands();
            comboBoxColumn.SelectedItem = "All";

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "PRMGR")
            {
                this.dataGridBrands.Columns["Update"].Visible = false;
                this.dataGridBrands.Columns["Delete"].Visible = false;
                this.AddBrand.Visible = false;
            }
        }

        private void AddBrand_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            FormHandler.openChildForm(this.Name, this, "AddNewBrand", ChildFormType.ADD, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            string keyword = textBoxKeyword.Text;
            string column = null;
            brandsSearchResults = null;
            
            try
            {
                switch (comboBoxColumn.SelectedItem.ToString())
                {
                    case "Brand ID":
                        column = "brand_id";
                        break;
                    case "Buyer Name":
                        column = "buyer_name";
                        break;
                    case "Brand Name":
                        column = "brand_name";
                        break;
                    case "Brand Description":
                        column = "brand_description";
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
                    brandsSearchResults = buyerDBHandler.searchBrands(keyword);
                }
                else
                {
                    brandsSearchResults = buyerDBHandler.searchBrandsUsingColumn(column, keyword);
                }

                //binding
                dataGridBrands.Rows.Clear();
                foreach (Brand brand in brandsSearchResults)
                {
                    dataGridBrands.Rows.Add(brand.brandId, brand.buyerName, brand.brandName,  brand.brandDesc, "Update", "Delete");
                }

                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Search Completed", NotificationStates.INFORMATION);
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
            loadBrands();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Feed Refreshed.", NotificationStates.INFORMATION);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridBrands.Rows.Count > 0)
            {
                Excel.Application excellApplication = new Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridBrands.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridBrands.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridBrands.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridBrands.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridBrands.Rows[i].Cells[j].Value.ToString();
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

        private void dataGridBrands_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridBrands.Columns[e.ColumnIndex].Name;
            if (column == "Update")
            {
                selectedBrandId = dataGridBrands.CurrentRow.Cells["BrandID"].FormattedValue.ToString();
                foreach (Brand brand in brands)
                {
                    if (brand.brandId == selectedBrandId)
                    {
                        NotificationManager.hideInAppNotification(panelInAppNotifications);
                        FormHandler.openChildForm(this.Name, this, "AddNewBrand", ChildFormType.UPDATE, brand);
                        break;
                    }
                }
            }
            else if (column == "Delete")
            {
                selectedBrandId = dataGridBrands.CurrentRow.Cells["BrandID"].FormattedValue.ToString();

                NotificationManager.hideInAppNotification(panelInAppNotifications);
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("The selected Brand will be permanently deleted.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (buyerDBHandler.deleteBrand(selectedBrandId) == true)
                        {
                            loadBrands();
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Brand Deleted Successfully.", NotificationStates.SUCCESS);
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

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        public void loadBrands()
        {
            try
            {
                brands = buyerDBHandler.getAllBrands();
                dataGridBrands.Rows.Clear();
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                //binding
                foreach (Brand brand in brands)
                {
                    dataGridBrands.Rows.Add(brand.brandId,  brand.buyerName, brand.brandName, brand.brandDesc, "Update", "Delete");
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
