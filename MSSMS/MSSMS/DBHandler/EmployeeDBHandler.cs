using MSSMS.Models;
using MSSMS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace MSSMS.DBHandler
{
    class EmployeeDBHandler : DBHandler
    {
        //add employee
        public bool addEmployee(Employee employee)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "INSERT INTO `employee` (`first_name`, `last_name`, `full_name`, `gender`, `birthday`, `date_recruited`, `desig_id`, `primary_email`, `primary_phone`) VALUES(@firstName,@lastName,@fullName, @gender, @birthday, @dateRecruited, @desigId, @email, @phone)";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = employee.firstName;
                    mySqlCommand.Parameters.Add("@lastName", MySqlDbType.VarChar).Value = employee.lastName;
                    mySqlCommand.Parameters.Add("@fullName", MySqlDbType.VarChar).Value = employee.fullName;
                    mySqlCommand.Parameters.Add("@gender", MySqlDbType.VarChar).Value = employee.gender;
                    mySqlCommand.Parameters.Add("@birthday", MySqlDbType.DateTime).Value = employee.birthday;
                    mySqlCommand.Parameters.Add("@dateRecruited", MySqlDbType.DateTime).Value = employee.dateRecruited;
                    mySqlCommand.Parameters.Add("@desigId", MySqlDbType.VarChar).Value = employee.designationId;
                    mySqlCommand.Parameters.Add("@phone", MySqlDbType.VarChar).Value = employee.primaryPhone;
                    mySqlCommand.Parameters.Add("@email", MySqlDbType.VarChar).Value = employee.primaryEmail;
                    mySqlCommand.Prepare();

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to add the Employee" + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //update employee
        public bool updateEmployee(Employee employee)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `employee` SET `first_name`=@firstName,`last_name`=@lastName,`full_name`=@fullName, `gender`=@gender,`birthday`=@birthday,`date_recruited`=@dateRecruited,`desig_id`=@desigId,`primary_email`=@email,`primary_phone`=@phone WHERE `employee_id`=@employeeId;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = employee.firstName;
                    mySqlCommand.Parameters.Add("@lastName", MySqlDbType.VarChar).Value = employee.lastName;
                    mySqlCommand.Parameters.Add("@fullName", MySqlDbType.VarChar).Value = employee.fullName;
                    mySqlCommand.Parameters.Add("@gender", MySqlDbType.VarChar).Value = employee.gender;
                    mySqlCommand.Parameters.Add("@birthday", MySqlDbType.DateTime).Value = employee.birthday;
                    mySqlCommand.Parameters.Add("@dateRecruited", MySqlDbType.DateTime).Value = employee.dateRecruited;
                    mySqlCommand.Parameters.Add("@desigId", MySqlDbType.VarChar).Value = employee.designationId;
                    mySqlCommand.Parameters.Add("@phone", MySqlDbType.VarChar).Value = employee.primaryPhone;
                    mySqlCommand.Parameters.Add("@email", MySqlDbType.VarChar).Value = employee.primaryEmail;
                    mySqlCommand.Parameters.Add("@employeeId", MySqlDbType.VarChar).Value = employee.employeeId;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to update the Employee "+ ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //delete employee
        public bool deleteEmployee(string employee_id)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "DELETE FROM `employee` WHERE `employee_id`=@employeeID";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = employee_id;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to delete the Employee", "ERRORCODE");
                    }
                }
            }
        }

        //get all employees
        public List<Employee> getAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `employee` e, `designation` d WHERE e.`desig_id` = d.`desig_id`";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String employee_id = mySqlDataReader.GetString("employee_id");
                                String full_name = mySqlDataReader.GetString("full_name");
                                String first_name = mySqlDataReader.GetString("first_name");
                                String last_name = mySqlDataReader.GetString("last_name");
                                String gender = mySqlDataReader.GetString("gender");
                                DateTime birthday = mySqlDataReader.GetDateTime("birthday");
                                String designationId = mySqlDataReader.GetString("desig_id");
                                String designationName = mySqlDataReader.GetString("desig_name");
                                DateTime date_recruited = mySqlDataReader.GetDateTime("date_recruited");
                                String email = mySqlDataReader.GetString("primary_email");
                                String phone = mySqlDataReader.GetString("primary_phone");

                                Employee employee = new Employee(employee_id, full_name, first_name, last_name, gender, birthday, designationId, designationName, date_recruited, email, phone);
                                employees.Add(employee);
                            }

                            return employees;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to fetch Employees " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //get all available departments with designations assigned
        public DeptDesig getAvailableDesignations()
        {
            List<Department> departments = new List<Department>();
            List<Designation> designations = new List<Designation>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT des.dept_id, dep.dept_name FROM `designation` des, `department` dep WHERE des.dept_id = dep.dept_id GROUP BY des.dept_id, dep.dept_name;"; 
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                string dept_id = mySqlDataReader.GetString("dept_id");
                                string dept_name = mySqlDataReader.GetString("dept_name");

                                Department dept = new Department(dept_id, dept_name);
                                departments.Add(dept);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to fetch Departments and Designations", "ERRORCODE");
                    }

                    mySqlCommand.CommandText = "SELECT dep.dept_id, dep.dept_name, des.desig_id, des.desig_name FROM `designation` des, `department` dep WHERE des.dept_id = dep.dept_id;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                string dept_id = mySqlDataReader.GetString("dept_id");
                                string dept_name = mySqlDataReader.GetString("dept_name");
                                string desig_id = mySqlDataReader.GetString("desig_id");
                                string desig_name = mySqlDataReader.GetString("desig_name");

                                Designation desig = new Designation(desig_id, desig_name , "", dept_id, dept_name);
                                designations.Add(desig);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to fetch Departments and Designations", "ERRORCODE");
                    }

                    DeptDesig deptDesig = new DeptDesig(departments, designations);
                    return deptDesig;
                }
            }
        }

        //get employee by id
        public Employee getEmployeeById(string employee_id)
        {
            Employee employee = null;

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `employee` e, `designation` d WHERE e.`employee_id`=@employeeId AND e.`desig_id` = d.`desig_id`";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@employeeId", MySqlDbType.VarChar).Value = employee_id;

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                employee_id = mySqlDataReader.GetString("employee_id");
                                String full_name = mySqlDataReader.GetString("full_name");
                                String first_name = mySqlDataReader.GetString("first_name");
                                String last_name = mySqlDataReader.GetString("last_name");
                                String gender = mySqlDataReader.GetString("gender");
                                DateTime birthday = mySqlDataReader.GetDateTime("birthday");
                                String designationId = mySqlDataReader.GetString("desig_id");
                                String designationName = mySqlDataReader.GetString("desig_name");
                                DateTime date_recruited = mySqlDataReader.GetDateTime("date_recruited");
                                String email = mySqlDataReader.GetString("primary_email");
                                String phone = mySqlDataReader.GetString("primary_phone");

                                employee = new Employee(employee_id, full_name, first_name, last_name, gender, birthday, designationId, designationName, date_recruited, email, phone);
                            }

                            return employee;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Employee is not found " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //search queries
        //search by all colums in employee
        public List<Employee> searchEmployee(string keyword)
        {
            List<Employee> employees = new List<Employee>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT e.`employee_id`, e.`first_name`, e.`last_name`, e.`full_name`, e.`gender`, e.`birthday`, e.`date_recruited`, e.`desig_id`, e.`primary_email`, e.`primary_phone`, d.`desig_id`, d.`desig_name` FROM `employee` e, `designation` d WHERE e.`desig_id` = d.`desig_id` AND e.`employee_id` LIKE @keyword OR e.`first_name` LIKE @keyword OR e.`last_name` LIKE @keyword OR e.`full_name` LIKE @keyword OR e.`gender` LIKE @keyword OR e.`birthday` LIKE @keyword OR e.`primary_email` LIKE @keyword OR e.`primary_phone` LIKE @keyword OR DAY(e.date_recruited) LIKE @keyword OR MONTH(e.date_recruited) LIKE @keyword OR YEAR(e.date_recruited) LIKE @keyword OR d.`desig_name` LIKE @keyword;";

                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@keyword", MySqlDbType.VarChar).Value = "%" + keyword + "%";
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String employee_id = mySqlDataReader.GetString("employee_id");
                                String full_name = mySqlDataReader.GetString("full_name");
                                String first_name = mySqlDataReader.GetString("first_name");
                                String last_name = mySqlDataReader.GetString("last_name");
                                String gender = mySqlDataReader.GetString("gender");
                                DateTime birthday = mySqlDataReader.GetDateTime("birthday");
                                String designationId = mySqlDataReader.GetString("desig_id");
                                String designationName = mySqlDataReader.GetString("desig_name");
                                DateTime date_recruited = mySqlDataReader.GetDateTime("date_recruited");
                                String email = mySqlDataReader.GetString("primary_email");
                                String phone = mySqlDataReader.GetString("primary_phone");

                                Employee employee = new Employee(employee_id, full_name, first_name, last_name, gender, birthday, designationId, designationName, date_recruited, email, phone);

                                employees.Add(employee);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                    return employees;
                }
            }
        }

        //search employees by column
        public List<Employee> searchEmployeesUsingColumn(string column, string keyword)
        {
            List<Employee> employees = new List<Employee>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    if (column.Equals("date_recruited"))
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `employee` e, `designation` d WHERE DAY(e.date_recruited) LIKE @keyword OR MONTH(e.date_recruited) LIKE @keyword OR YEAR(e.date_recruited) LIKE @keyword AND e.`desig_id` = d.`desig_id` group by e.`date_recruited`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@keyword", MySqlDbType.VarChar).Value = "%" + keyword + "%";
                        mySqlCommand.Prepare();
                    }
                    else if (column.Equals("desig_name"))
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `employee` e, `designation` d WHERE d.`desig_name` LIKE @keyword AND e.`desig_id` = d.`desig_id`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@keyword", MySqlDbType.VarChar).Value = "%" + keyword + "%";
                        mySqlCommand.Prepare();
                    }
                    else
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `employee` e, `designation` d WHERE e.`" + column + "` LIKE @keyword AND e.`desig_id` = d.`desig_id`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@keyword", MySqlDbType.VarChar).Value = "%" + keyword + "%";
                        mySqlCommand.Prepare();
                    }

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String employee_id = mySqlDataReader.GetString("employee_id");
                                String full_name = mySqlDataReader.GetString("full_name");
                                String first_name = mySqlDataReader.GetString("first_name");
                                String last_name = mySqlDataReader.GetString("last_name");
                                String gender = mySqlDataReader.GetString("gender");
                                DateTime birthday = mySqlDataReader.GetDateTime("birthday");
                                String designationId = mySqlDataReader.GetString("desig_id");
                                String designationName = mySqlDataReader.GetString("desig_name");
                                DateTime date_recruited = mySqlDataReader.GetDateTime("date_recruited");
                                String email = mySqlDataReader.GetString("primary_email");
                                String phone = mySqlDataReader.GetString("primary_phone");

                                Employee employee = new Employee(employee_id, full_name, first_name, last_name, gender, birthday, designationId, designationName, date_recruited, email, phone);

                                employees.Add(employee);
                            }

                            return employees;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }
    }
}
