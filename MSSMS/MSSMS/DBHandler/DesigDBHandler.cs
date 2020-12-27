using MSSMS.Models;
using MSSMS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSMS.DBHandler
{
    public class DesigDBHandler:DBHandler
    {
        //add designation
        public bool addDesignation(Designation designation)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "INSERT INTO `designation`(`desig_name`, `desig_description`, `dept_id`) VALUES(@desigName, @desigDesc, @deptId)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;

                    cmd.Parameters.Add("@desigName", MySqlDbType.VarChar).Value = designation.desig_name;
                    cmd.Parameters.Add("@desigDesc", MySqlDbType.VarChar).Value = designation.description;
                    cmd.Parameters.Add("@deptId", MySqlDbType.VarChar).Value = designation.dept_id;
                    cmd.Prepare();

                    try
                    {
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to add the designation", "ERRORCODE");
                    }
                }
            }
        }

        //update designation
        public bool updateDesignation(Designation designation)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "UPDATE `designation` SET `dept_id`=@deptId,`desig_name`=@desigName,`desig_description`=@desigDesc WHERE `desig_id`=@desigId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;

                    cmd.Parameters.Add("@desigName", MySqlDbType.VarChar).Value = designation.desig_name;
                    cmd.Parameters.Add("@desigDesc", MySqlDbType.VarChar).Value = designation.description;
                    cmd.Parameters.Add("@deptId", MySqlDbType.VarChar).Value = designation.dept_id;
                    cmd.Parameters.Add("@desigId", MySqlDbType.VarChar).Value = designation.desig_id;
                    cmd.Prepare();

                    try
                    {
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to update the designation", "ERRORCODE");
                    }
                }
            }
        }

        //delete designation
        public bool deleteDesignation(string desig_id)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "DELETE FROM `designation` WHERE `desig_id`=@desigId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;

                    cmd.Parameters.Add("@desigId", MySqlDbType.VarChar).Value = desig_id;
                    cmd.Prepare();

                    try
                    {
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to delete the designation", "ERRORCODE");
                    }
                }
            }
        }

        //view all designations
        public List<Designation> getAllDesignations()
        {
            List<Designation> designations = new List<Designation>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT desig.`desig_id`, desig.`dept_id`, desig.`desig_name`, desig.`desig_description`, dep.`dept_name` FROM `designation` desig, `department`dep WHERE desig.dept_id = dep.dept_id;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;
                    mySqlCommand.Prepare();

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                string desig_id = mySqlDataReader.GetString("desig_id");
                                string dept_id = mySqlDataReader.GetString("dept_id");
                                string desig_name = mySqlDataReader.GetString("desig_name");
                                string desig_desc = mySqlDataReader.GetString("desig_description");
                                string dept_name = mySqlDataReader.GetString("dept_name");

                                Designation designation = new Designation(desig_id,desig_name, desig_desc ,dept_id,dept_name);
                                designations.Add(designation);;
                            }

                            return designations;
                        }
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to fetch designations", "ERRORCODE");
                    }
                }
            }
        }

        //view available depts
        public List<Department> getAvailableDepartments()
        {
            List<Department> departments = new List<Department>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT `dept_id`, `dept_name` FROM `department`;";
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

                                Department department = new Department(dept_id, dept_name);
                                departments.Add(department); ;
                            }

                            return departments;
                        }
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to fetch Departments", "ERRORCODE");
                    }
                }
            }
        }

        //search queries
        //search by all colums in designation
        public List<Designation> searchDesignation(string keyword)
        {
            List<Designation> designations = new List<Designation>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT desig.`desig_id`, desig.`dept_id`, desig.`desig_name`, desig.`desig_description`, dep.`dept_name` FROM `designation` desig, `department`dep WHERE desig.dept_id = dep.dept_id AND desig.`desig_id` LIKE @keyword OR desig.`desig_name` LIKE @keyword OR desig.`desig_description` LIKE @keyword OR dep.`dept_name` LIKE @keyword;";

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
                                string desig_id = mySqlDataReader.GetString("desig_id");
                                string dept_id = mySqlDataReader.GetString("dept_id");
                                string desig_name = mySqlDataReader.GetString("desig_name");
                                string desig_desc = mySqlDataReader.GetString("desig_description");
                                string dept_name = mySqlDataReader.GetString("dept_name");

                                Designation designation = new Designation(desig_id, desig_name, desig_desc, dept_id, dept_name);
                                designations.Add(designation);
                            }

                            //return machines;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                    //}
                    return designations;
                }
            }
        }

        //search designations by column
        public List<Designation> searchDesignationsUsingColumn(string column, string keyword)
        {
            List<Designation> designations = new List<Designation>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    if (column.Equals("dept_name"))
                    {
                        mySqlCommand.CommandText = "SELECT desig.`desig_id`, desig.`dept_id`, desig.`desig_name`, desig.`desig_description`, dep.`dept_name` FROM `designation` desig, `department`dep WHERE desig.dept_id = dep.dept_id AND dep.dept_name LIKE @keyword;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@keyword", MySqlDbType.VarChar).Value = "%" + keyword + "%";
                        mySqlCommand.Prepare();
                    }
                    else
                    {
                        mySqlCommand.CommandText = "SELECT desig.`desig_id`, desig.`dept_id`, desig.`desig_name`, desig.`desig_description`, dep.`dept_name` FROM `designation` desig, `department`dep WHERE desig.dept_id = dep.dept_id AND desig.`" + column + "` LIKE @keyword;";
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
                                string desig_id = mySqlDataReader.GetString("desig_id");
                                string dept_id = mySqlDataReader.GetString("dept_id");
                                string desig_name = mySqlDataReader.GetString("desig_name");
                                string desig_desc = mySqlDataReader.GetString("desig_description");
                                string dept_name = mySqlDataReader.GetString("dept_name");

                                Designation designation = new Designation(desig_id, desig_name, desig_desc, dept_id, dept_name);
                                designations.Add(designation);
                            }

                            return designations;
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
