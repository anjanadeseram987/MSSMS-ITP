using MSSMS.Models;
using MSSMS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace MSSMS.DBHandler
{
    public class DeptDBHandler:DBHandler
    {
        //add department
        public bool addDepartment(Department department)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "INSERT INTO `department`(`dept_name`, `dept_email`, `dept_phone`, `dept_description`) VALUES (@deptName, @deptMail, @deptContact, @deptDesc)";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@deptName", MySqlDbType.VarChar).Value = department.dept_name;
                    mySqlCommand.Parameters.Add("@deptMail", MySqlDbType.VarChar).Value = department.email;
                    mySqlCommand.Parameters.Add("@deptContact", MySqlDbType.VarChar).Value = department.contact_no;
                    mySqlCommand.Parameters.Add("@deptDesc", MySqlDbType.VarChar).Value = department.description;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    } catch (Exception)
                    {
                        throw new MSSMUIException("Failed to add the department", "ERRORCODE");
                    }
                }
            }
        }

        //update department
        public bool updateDepartment(Department department)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `department` SET `dept_name`=@deptName,`dept_email`=@deptMail,`dept_phone`=@deptContact,`dept_description`=@deptDesc WHERE `dept_id`=@deptID";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@deptName", MySqlDbType.VarChar).Value = department.dept_name;
                    mySqlCommand.Parameters.Add("@deptMail", MySqlDbType.VarChar).Value = department.email;
                    mySqlCommand.Parameters.Add("@deptContact", MySqlDbType.VarChar).Value = department.contact_no;
                    mySqlCommand.Parameters.Add("@deptDesc", MySqlDbType.VarChar).Value = department.description;
                    mySqlCommand.Parameters.Add("@deptID", MySqlDbType.VarChar).Value = department.dept_id;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to update the department", "ERRORCODE");
                    }
                }
            }
        }

        //delete department
        public bool deleteDepartment(string dept_id)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "DELETE FROM `department` WHERE `dept_id`=@deptID";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@deptID", MySqlDbType.VarChar).Value = dept_id;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to delete the department", "ERRORCODE");
                    }
                }
            }
        }

        //view all departments
        public List<Department> getAllDepartments()
        {
            List<Department> departments = new List<Department>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `department`";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String dept_id = mySqlDataReader.GetString("dept_id");
                                String dept_name = mySqlDataReader.GetString("dept_name");
                                String dept_desc = mySqlDataReader.GetString("dept_description");
                                String dept_email = mySqlDataReader.GetString("dept_email");
                                String dept_contact = mySqlDataReader.GetString("dept_phone");

                                Department department = new Department(dept_id,dept_name,dept_desc,dept_contact,dept_email);
                                departments.Add(department);
                            }

                            return departments;
                        }
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to fetch department", "ERRORCODE");
                    }
                }
            }
        }

        //SEARCH QUERIES
        //search by all colums in department
        public List<Department> searchDepartment(string keyword)
        {
            List<Department> departments = new List<Department>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `department` WHERE `dept_id` LIKE @keyword OR `dept_id` LIKE @keyword OR `dept_email` LIKE @keyword OR `dept_phone` LIKE @keyword;";

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
                                String dept_id = mySqlDataReader.GetString("dept_id");
                                String dept_name = mySqlDataReader.GetString("dept_name");
                                String dept_desc = mySqlDataReader.GetString("dept_description");
                                String dept_email = mySqlDataReader.GetString("dept_email");
                                String dept_contact = mySqlDataReader.GetString("dept_phone");

                                Department department = new Department(dept_id, dept_name, dept_desc, dept_contact, dept_email);
                                departments.Add(department);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }

                    return departments;
                }
            }
        }

        //search departments by column
        public List<Department> searchDepartmentsUsingColumn(string column, string keyword)
        {
            List<Department> departments = new List<Department>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `department` WHERE `" + column + "` LIKE @keyword;";
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
                                String dept_id = mySqlDataReader.GetString("dept_id");
                                String dept_name = mySqlDataReader.GetString("dept_name");
                                String dept_desc = mySqlDataReader.GetString("dept_description");
                                String dept_email = mySqlDataReader.GetString("dept_email");
                                String dept_contact = mySqlDataReader.GetString("dept_phone");

                                Department department = new Department(dept_id, dept_name, dept_desc, dept_contact, dept_email);
                                departments.Add(department);
                            }

                            return departments;
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
