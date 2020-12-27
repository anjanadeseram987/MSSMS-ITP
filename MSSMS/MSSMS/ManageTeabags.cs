using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using MSSMS.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MSSMS
{
    public partial class ManageTeabags : Form
    {
        private TeaProductDBHandler teaProductDBHandler = new TeaProductDBHandler();
        private List<TeabagMaterial> teabagMaterials = new List<TeabagMaterial>();
        private List<TeabagMaterial> teabagMaterialsSearchResult = new List<TeabagMaterial>(); 
        private string selectedTeabagMaterial = null;

        public ManageTeabags()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void btnAddTeabagMaterial_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications); 
            FormHandler.openChildForm(this.Name, this, "AddTeabagMaterial", ChildFormType.ADD, null);
        }

        private void ManageTeabags_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            comboBoxColumn.SelectedItem = "All";
            loadTeabagMaterials();

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "PRMGR")
            {
                this.dataGridTeabagMaterials.Columns["Update"].Visible = false;
                this.dataGridTeabagMaterials.Columns["Delete"].Visible = false;
                this.btnAddTeabagMaterial.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            string keyword = textBoxKeyword.Text;
            string column = null;
            teabagMaterialsSearchResult = null;

            try
            {
                switch (comboBoxColumn.SelectedItem.ToString())
                {
                    case "Serial Number":
                        column = "teabag_serial_no";
                        break;
                    case "Material Name":
                        column = "teabag_name";
                        break;
                    case "Teabag Type":
                        column = "teabag_type";
                        break;
                    case "Material Description":
                        column = "teabag_description";
                        break;
                    case "Availability":
                        column = "teabag_availability";
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
                if(column == "all")
                {
                    teabagMaterialsSearchResult = teaProductDBHandler.searchTebagMaterials(keyword);
                }
                else
                {
                    teabagMaterialsSearchResult = teaProductDBHandler.searchTebagMaterialsUsingColumn(column, keyword);
                }

                //binding
                dataGridTeabagMaterials.Rows.Clear();
                foreach (TeabagMaterial teabagMaterial in teabagMaterialsSearchResult)
                {
                    dataGridTeabagMaterials.Rows.Add(teabagMaterial.materialId, teabagMaterial.materialSerialNo, teabagMaterial.materialName, teabagMaterial.teabagType, teabagMaterial.materialDescription, teabagMaterial.materialAvailability, "Update", "Delete");
                }

                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Search Completed", NotificationStates.INFORMATION);
                dataGridTeabagMaterials.Columns["TeabagMaterialId"].Visible = false;
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
            loadTeabagMaterials();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Feed Refreshed.", NotificationStates.INFORMATION);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridTeabagMaterials.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excellApplication = new Microsoft.Office.Interop.Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridTeabagMaterials.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridTeabagMaterials.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridTeabagMaterials.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridTeabagMaterials.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridTeabagMaterials.Rows[i].Cells[j].Value.ToString();
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

        private void dataGridTeabagMaterials_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridTeabagMaterials.Columns[e.ColumnIndex].Name;

            if (column == "Update")
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
            else if (column == "Delete")
            {
                selectedTeabagMaterial = dataGridTeabagMaterials.CurrentRow.Cells["TeabagMaterialId"].FormattedValue.ToString();

                NotificationManager.hideInAppNotification(panelInAppNotifications);
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("The selected Teabag Material will be permanently deleted.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (teaProductDBHandler.deleteTeabagMaterial(selectedTeabagMaterial) == true)
                        {
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Teabag Material Deleted Successfully.", NotificationStates.SUCCESS);
                            loadTeabagMaterials();
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

        public void loadTeabagMaterials()
        {
            try
            {
                teabagMaterials = teaProductDBHandler.getAllTeabagMaterials();
                dataGridTeabagMaterials.Rows.Clear();
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                //binding
                foreach (TeabagMaterial teabagMaterial in teabagMaterials)
                {
                    dataGridTeabagMaterials.Rows.Add(teabagMaterial.materialId, teabagMaterial.materialSerialNo, teabagMaterial.materialName, teabagMaterial.teabagType, teabagMaterial.materialDescription, teabagMaterial.materialAvailability, "Update", "Delete");
                }
                dataGridTeabagMaterials.Columns["TeabagMaterialId"].Visible = false;
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
