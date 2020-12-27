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
    public partial class ManageDesigs : Form
    {
        private DesigDBHandler desigDBHandler = new DesigDBHandler();
        private List<Designation> designations = new List<Designation>();
        private List<Designation> designationSearchResult = new List<Designation>(); 
        private String selectedDesignationId = null;

        public ManageDesigs()
        {
            InitializeComponent();
        }

        private void ManageDesigs_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadDesignations();
            comboBoxColumn.SelectedItem = "Designation ID";

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "HRMGR")
            {
                this.dataGridDesignations.Columns["UpdateDesig"].Visible = false;
                this.dataGridDesignations.Columns["DeleteDesig"].Visible = false;
                this.AddDesig.Visible = false;
            }
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void AddDesig_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            FormHandler.openChildForm(this.Name, this, "AddDesignations", ChildFormType.ADD, null); 
        }

        private void dataGridDesignations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridDesignations.Columns[e.ColumnIndex].Name;
            if (column == "UpdateDesig")
            {
                selectedDesignationId = dataGridDesignations.CurrentRow.Cells["DesignationID"].FormattedValue.ToString();
                foreach (Designation desig in designations)
                {
                    if (desig.desig_id == selectedDesignationId)
                    {
                        NotificationManager.hideInAppNotification(panelInAppNotifications);
                        FormHandler.openChildForm(this.Name, this, "AddDesignations", ChildFormType.UPDATE, desig);
                        break;
                    }
                }
            }
            else if (column == "DeleteDesig")
            {
                selectedDesignationId = dataGridDesignations.CurrentRow.Cells["DesignationID"].FormattedValue.ToString();

                NotificationManager.hideInAppNotification(panelInAppNotifications);
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("The selected Designation will be permanently deleted.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (desigDBHandler.deleteDesignation(selectedDesignationId) == true)
                        {
                            loadDesignations();
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Designation Deleted Successfully.", NotificationStates.SUCCESS);
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

        //load designations
        public void loadDesignations()
        {
            try
            {
                designations = desigDBHandler.getAllDesignations();
                dataGridDesignations.Rows.Clear();
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                //binding
                foreach (Designation desig in designations)
                {
                    dataGridDesignations.Rows.Add(desig.desig_id, desig.desig_name, desig.dept_name, desig.description, "Update", "Delete");
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            comboBoxColumn.SelectedItem = "All";
            textBoxKeyword.Clear();
            loadDesignations();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Feed Refreshed.", NotificationStates.INFORMATION);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridDesignations.Rows.Count > 0)
            {
                Excel.Application excellApplication = new Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridDesignations.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridDesignations.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridDesignations.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridDesignations.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridDesignations.Rows[i].Cells[j].Value.ToString();
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
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            string keyword = textBoxKeyword.Text;
            string column = null;
            designationSearchResult = null;

            try
            {
                switch (comboBoxColumn.SelectedItem.ToString())
                {
                    case "Designation ID":
                        column = "desig_id";
                        break;
                    case "Designation":
                        column = "desig_name";
                        break;
                    case "Department":
                        column = "dept_name";
                        break;
                    case "Description":
                        column = "desig_description";
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
                    designationSearchResult = desigDBHandler.searchDesignation(keyword);
                }
                else
                {
                    designationSearchResult = desigDBHandler.searchDesignationsUsingColumn(column, keyword);
                }

                //binding
                dataGridDesignations.Rows.Clear();
                foreach (Designation desig in designationSearchResult)
                {
                    dataGridDesignations.Rows.Add(desig.desig_id, desig.desig_name, desig.dept_name, desig.description, "Update", "Delete");
                }

                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Search Completed", NotificationStates.INFORMATION);
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }

        }
    }
}
