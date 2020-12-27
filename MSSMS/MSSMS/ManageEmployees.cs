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
    public partial class ManageEmployees : Form
    {
        private EmployeeDBHandler employeeDBHandler = new EmployeeDBHandler();
        private List<Employee> employees = new List<Employee>();
        private List<Employee> employeeSearchResult = new List<Employee>();
        private String selectedEmployeeId = null; 

        public ManageEmployees()
        {
            InitializeComponent();
        }

        private void btnCloseInAppNotification_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
        }

        private void ManageEmployees_Load(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            loadEmployees();
            comboBoxColumn.SelectedItem = "Employee ID";

            //hiding management tools/buttons when not necessary
            if (SessionManager.user.role != "HRMGR")
            {
                this.dataGridEmployees.Columns["updateEmp"].Visible = false;
                this.dataGridEmployees.Columns["deleteEmp"].Visible = false;
                this.btnAddEmployee.Visible = false;
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            FormHandler.openChildForm(this.Name, this,"AddEmployee", ChildFormType.ADD, null); 
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            comboBoxColumn.SelectedItem = "All";
            textBoxKeyword.Clear();
            loadEmployees();
            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Feed Refreshed.", NotificationStates.INFORMATION);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            string keyword = textBoxKeyword.Text;
            string column = null;
            employeeSearchResult = null;

            try
            {
                switch (comboBoxColumn.SelectedItem.ToString())
                {
                    case "Employee ID":
                        column = "employee_id";
                        break;
                    case "Full Name":
                        column = "full_name";
                        break;
                    case "First Name":
                        column = "first_name";
                        break;
                    case "Last Name":
                        column = "last_name";
                        break;
                    case "Gender":
                        column = "gender";
                        break;
                    case "Birthday":
                        column = "birthday";
                        break;
                    case "Designation":
                        column = "desig_name";
                        break;
                    case "Date Recruited":
                        column = "date_recruited";
                        break;
                    case "Primary Email":
                        column = "primary_email";
                        break;
                    case "Primary Phone":
                        column = "primary_phone";
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
                    employeeSearchResult = employeeDBHandler.searchEmployee(keyword);
                }
                else
                {
                    employeeSearchResult = employeeDBHandler.searchEmployeesUsingColumn(column, keyword);
                }

                //binding
                dataGridEmployees.Rows.Clear();
                foreach (Employee employee in employeeSearchResult)
                {
                    dataGridEmployees.Rows.Add(employee.employeeId, employee.fullName, employee.firstName, employee.lastName, employee.gender, employee.birthday.ToString("MM/dd/yyyy"), employee.designationName, employee.dateRecruited.ToString("MM/dd/yyyy"), employee.primaryEmail, employee.primaryPhone, "Update", "Delete");
                }

                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Search Completed", NotificationStates.INFORMATION);
            }
            catch (Exception ex)
            {
                NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, ex.Message, NotificationStates.ERROR);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NotificationManager.hideInAppNotification(panelInAppNotifications);
            if (dataGridEmployees.Rows.Count > 0)
            {
                Excel.Application excellApplication = new Excel.Application();
                excellApplication.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < dataGridEmployees.Columns.Count - 1; i++)
                {
                    try
                    {
                        excellApplication.Cells[1, i] = dataGridEmployees.Columns[i - 1].HeaderText;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                for (int i = 0; i < dataGridEmployees.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridEmployees.Columns.Count - 2; j++)
                    {
                        excellApplication.Cells[i + 2, j + 1] = dataGridEmployees.Rows[i].Cells[j].Value.ToString();
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

        private void dataGridEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String column = dataGridEmployees.Columns[e.ColumnIndex].Name;

            if (column == "updateEmp")
            {
                selectedEmployeeId = dataGridEmployees.CurrentRow.Cells["EmpID"].FormattedValue.ToString();

                foreach (Employee employee in employees)
                {
                    if (employee.employeeId == selectedEmployeeId)
                    {
                        NotificationManager.hideInAppNotification(panelInAppNotifications);
                        FormHandler.openChildForm(this.Name, this, "AddEmployee", ChildFormType.UPDATE, employee);
                        break;
                    }
                }
            }
            else if (column == "deleteEmp")
            {
                selectedEmployeeId = dataGridEmployees.CurrentRow.Cells["EmpID"].FormattedValue.ToString();

                NotificationManager.hideInAppNotification(panelInAppNotifications);
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("The selected Employee will be permanently deleted.", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (employeeDBHandler.deleteEmployee(selectedEmployeeId) == true)
                        {
                            loadEmployees();
                            NotificationManager.showInAppNotification(panelInAppNotifications, lableInAppNotification, pbInAppNotification, btnCloseInAppNotification, "Employee Deleted Successfully.", NotificationStates.SUCCESS);
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

        //load employees
        public void loadEmployees()
        {
            try
            {
                employees = employeeDBHandler.getAllEmployees();
                dataGridEmployees.Rows.Clear();
                NotificationManager.hideInAppNotification(panelInAppNotifications);

                //binding
                foreach (Employee employee in employees)
                {
                    dataGridEmployees.Rows.Add(employee.employeeId, employee.fullName, employee.firstName, employee.lastName, employee.gender, employee.birthday.ToString("MM/dd/yyyy"), employee.designationName, employee.dateRecruited.ToString("MM/dd/yyyy"), employee.primaryEmail, employee.primaryPhone, "Update", "Delete");
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
