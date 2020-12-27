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
    public partial class ManageDepts : Form
    {
        private DeptDBHandler deptDBHandler = new DeptDBHandler(); 
        private List<Department> departments = new List<Department>();
        private List<Department> departmentSearchResult = new List<Department>();
        private String selectedDeptId = null;

        public ManageDepts()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void ManageDepts_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadDepartments();
            comboBoxColumn.SelectedItem = "ID";

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "HRMGR")
            {
                this.dataGridDepts.Columns["Update"].Visible = false;
                this.dataGridDepts.Columns["Delete"].Visible = false;
                this.AddDept.Visible = false;
            }
        }

        private void AddDept_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            FormHandler.openChildForm(this.Name, this, "AddDepartments", ChildFormType.ADD, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            comboBoxColumn.SelectedItem = "All";
            textBoxKeyword.Clear();
            loadDepartments();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Feed Refreshed.", NotificationStates.INFORMATION);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridDepts.Rows.Count > 0)
            {
                Excel.Application excellApplication = new Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridDepts.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridDepts.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridDepts.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridDepts.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridDepts.Rows[i].Cells[j].Value.ToString();
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
            departmentSearchResult = null;

            try
            {
                switch (comboBoxColumn.SelectedItem.ToString())
                {
                    case "Department ID":
                        column = "dept_id";
                        break;
                    case "Department":
                        column = "dept_name";
                        break;
                    case "Description":
                        column = "dept_description";
                        break;
                    case "Number of Employees": //no such column in db, it displays count
                        column = "all";
                        break;
                    case "Contact Number":
                        column = "dept_phone";
                        break;
                    case "Email":
                        column = "dept_email";
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
                    departmentSearchResult = deptDBHandler.searchDepartment(keyword);
                }
                else
                {
                    departmentSearchResult = deptDBHandler.searchDepartmentsUsingColumn(column, keyword);
                }

                //binding
                dataGridDepts.Rows.Clear();
                foreach (Department dept in departmentSearchResult)
                {
                    dataGridDepts.Rows.Add(dept.dept_id, dept.dept_name, dept.description, "", dept.contact_no, dept.email, "Update", "Delete");
                }

                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Search Completed", NotificationStates.INFORMATION);
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }
        }

        private void dataGridDepts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridDepts.Columns[e.ColumnIndex].Name;
            if (column == "Update")
            {
                selectedDeptId = dataGridDepts.CurrentRow.Cells["DeptID"].FormattedValue.ToString();
                foreach(Department dept in departments)
                {
                    if (dept.dept_id == selectedDeptId)
                    {
                        NotificationManager.hideInAppNotification(panelInAppNotifications);
                        FormHandler.openChildForm(this.Name, this, "AddDepartments", ChildFormType.UPDATE,dept);
                        break;
                    }
                }
            }
            else if (column == "Delete")
            {
                selectedDeptId = dataGridDepts.CurrentRow.Cells["DeptID"].FormattedValue.ToString();

                NotificationManager.hideInAppNotification(panelInAppNotifications);
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("The selected Department will be permanently deleted.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (deptDBHandler.deleteDepartment(selectedDeptId) == true)
                        {
                            loadDepartments();
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Department Deleted Successfully.", NotificationStates.SUCCESS);
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

        //load departments
        public void loadDepartments()
        {
            try
            {
                departments = deptDBHandler.getAllDepartments();
                dataGridDepts.Rows.Clear();
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                //binding
                foreach (Department dept in departments)
                {
                    dataGridDepts.Rows.Add(dept.dept_id, dept.dept_name, dept.description, "", dept.contact_no, dept.email, "Update", "Delete");
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
