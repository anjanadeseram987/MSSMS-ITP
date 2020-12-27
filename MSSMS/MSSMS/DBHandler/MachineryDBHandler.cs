using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MSSMS.Models;
using MSSMS.Utilities;
using MySql.Data.MySqlClient;

namespace MSSMS.DBHandler
{
    public class MachineryDBHandler : DBHandler
    {
        //add machine
        public bool addMachine(Machine machine)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "INSERT INTO `machine` (`location_id`, `serial_no`, `name`, `working_state`, `added_by`, `added_date`, `description`) VALUES(@locationId,@serialNumber,@name, @workingState, @addedBy, @addedDate, @description)";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@locationId", MySqlDbType.VarChar).Value = machine.locationId;
                    mySqlCommand.Parameters.Add("@serialNumber", MySqlDbType.VarChar).Value = machine.serialNumber;
                    mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = machine.name;
                    mySqlCommand.Parameters.Add("@workingState", MySqlDbType.VarChar).Value = machine.workingState;
                    mySqlCommand.Parameters.Add("@addedBy", MySqlDbType.VarChar).Value = machine.addedBy;
                    mySqlCommand.Parameters.Add("@addedDate", MySqlDbType.DateTime).Value = machine.addedDate;
                    mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = machine.description;
                    mySqlCommand.Prepare();

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to add the Machine" + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //update machine
        public bool updateMachine(Machine machine)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `machine` SET `serial_no`=@serialNumber,`name`=@name, `location_id`=@locationId, `working_state`=@workingState, `description`=@description WHERE `machine_id`=@machineId;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@serialNumber", MySqlDbType.VarChar).Value = machine.serialNumber;
                    mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = machine.name;
                    mySqlCommand.Parameters.Add("@locationId", MySqlDbType.VarChar).Value = machine.locationId;
                    mySqlCommand.Parameters.Add("@workingState", MySqlDbType.VarChar).Value = machine.workingState;
                    mySqlCommand.Parameters.Add("@addedBy", MySqlDbType.VarChar).Value = SessionManager.user.employeeId;
                    mySqlCommand.Parameters.Add("@addedDate", MySqlDbType.DateTime).Value = DateTime.Now;
                    mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = machine.description;
                    mySqlCommand.Parameters.Add("@machineId", MySqlDbType.VarChar).Value = machine.machineId;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to update the Machine " + ex.Message, "ERRORCODE");
                    }
                }
                connection.Close();
            }
        }

        //delete machine
        public bool deleteMachine(string machine_id)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "DELETE FROM `machine` WHERE `machine_id`=@machineID";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@machineID", MySqlDbType.VarChar).Value = machine_id;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to delete the Machine", "ERRORCODE");
                    }
                }
            }
        }

        //get all machines
        public List<Machine> getAllMachines()
        {
            List<Machine> machines = new List<Machine>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `machine`";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String machine_id = mySqlDataReader.GetString("machine_id");
                                String serial_no = mySqlDataReader.GetString("serial_no");
                                String name = mySqlDataReader.GetString("name");
                                String location_id = mySqlDataReader.GetString("location_id");
                                String working_state = mySqlDataReader.GetString("working_state");
                                String added_by = mySqlDataReader.GetString("added_by");
                                DateTime added_date = (DateTime)mySqlDataReader.GetDateTime("added_date");
                                String description = mySqlDataReader.GetString("description");

                                Machine machine = new Machine(machine_id, serial_no, name, location_id, working_state, added_by, added_date, description);
                                machines.Add(machine);
                            }

                            return machines;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to fetch Machines " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //get machine by id
        public Machine getMachineById(string machine_id)
        {
            Machine machine = null;

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `machine` WHERE `machine_id`=@machineId";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@machineId", MySqlDbType.VarChar).Value = machine_id;

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                machine_id = mySqlDataReader.GetString("machine_id");
                                String location_id = mySqlDataReader.GetString("location_id");
                                String serial_no = mySqlDataReader.GetString("serial_no");
                                String name = mySqlDataReader.GetString("name");
                                String working_state = mySqlDataReader.GetString("working_state");
                                String added_by = mySqlDataReader.GetString("added_by");
                                DateTime added_date = mySqlDataReader.GetDateTime("added_date");
                                String description = mySqlDataReader.GetString("description");

                                machine = new Machine(machine_id, location_id, serial_no, name, working_state, added_by, added_date, description);
                            }

                            return machine;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Employee is not found " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //get all locations 
        public List<Location> getAvailableLocations()
        {
            List<Location> locations = new List<Location>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `location`";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String location_id = mySqlDataReader.GetString("location_id");
                                String location_name = mySqlDataReader.GetString("location_name");
                                String location_description = mySqlDataReader.GetString("location_description");

                                Location location = new Location(location_id, location_name, location_description);
                                locations.Add(location);
                            }

                            return locations;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to fetch Locations " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }


        //search queries
        //search by all colums in machine
        public List<Machine> searchMachine(string keyword)
        {
            List<Machine> machines = new List<Machine>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    if (Regex.IsMatch(keyword, @"[0-9][0-9][0-9][0-9]\-[0-1][0-2]\-[0-3][0-9]"))
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `machine` WHERE CAST(added_date AS Date) = '" + keyword + "';";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        try
                        {
                            using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                            {
                                while (mySqlDataReader.Read())
                                {
                                    String machine_id = mySqlDataReader.GetString("machine_id");
                                    String serial_no = mySqlDataReader.GetString("serial_no");
                                    String name = mySqlDataReader.GetString("name");
                                    String location_id = mySqlDataReader.GetString("location_id");
                                    String working_state = mySqlDataReader.GetString("working_state");
                                    String added_by = mySqlDataReader.GetString("added_by");
                                    DateTime added_date = (DateTime)mySqlDataReader.GetDateTime("added_date");
                                    String description = mySqlDataReader.GetString("description");

                                    Machine machine = new Machine(machine_id, serial_no, name, location_id, working_state, added_by, added_date, description);

                                    machines.Add(machine);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                        }
                    }
                    else
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `machine` WHERE `machine_id` LIKE @keyword OR `location_id` LIKE @keyword OR `serial_no` LIKE @keyword OR `name` LIKE @keyword OR `description` LIKE @keyword OR `working_state` LIKE @keyword OR `added_by` LIKE @keyword;";

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
                                    String machine_id = mySqlDataReader.GetString("machine_id");
                                    String serial_no = mySqlDataReader.GetString("serial_no");
                                    String name = mySqlDataReader.GetString("name");
                                    String location_id = mySqlDataReader.GetString("location_id");
                                    String working_state = mySqlDataReader.GetString("working_state");
                                    String added_by = mySqlDataReader.GetString("added_by");
                                    DateTime added_date = (DateTime)mySqlDataReader.GetDateTime("added_date");
                                    String description = mySqlDataReader.GetString("description");

                                    Machine machine = new Machine(machine_id, serial_no, name, location_id, working_state, added_by, added_date, description);

                                    machines.Add(machine);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                        }
                    }
                    return machines;
                }
            }
        }

        //search machines by column
        public List<Machine> searchMachinesUsingColumn(string column, string keyword)
        {
            List<Machine> machines = new List<Machine>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    /*mySqlCommand.CommandText = "SELECT * FROM `machine` WHERE `" + column + "` LIKE @keyword;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;*/

                    if (column.Equals("added_date"))
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `machine` WHERE CAST(added_date AS Date) = '" + keyword + "';";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();
                    }
                    else
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `machine` WHERE `" + column + "` LIKE @keyword;";
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
                                String machine_id = mySqlDataReader.GetString("machine_id");
                                String serial_no = mySqlDataReader.GetString("serial_no");
                                String name = mySqlDataReader.GetString("name");
                                String location_id = mySqlDataReader.GetString("location_id");
                                String working_state = mySqlDataReader.GetString("working_state");
                                String added_by = mySqlDataReader.GetString("added_by");
                                DateTime added_date = (DateTime)mySqlDataReader.GetDateTime("added_date");
                                String description = mySqlDataReader.GetString("description");

                                Machine machine = new Machine(machine_id, serial_no, name, location_id, working_state, added_by, added_date, description);
                                machines.Add(machine);
                            }

                            return machines;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //MACHINE ISSUES
        //add issue
        public Boolean addMachineIssue(MachineIssue machineIssue)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "INSERT INTO `issue`(`issue_machine_id`, `issue_submitted_by`, `issue_submitted_date`, `issue_subject`, `issue_description`, `issue_priority_level`, `issue_status`) VALUES (@machineId, @submittedBy, @submittedDate, @subject, @description, @priorityLevel, @status);";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@machineId", MySqlDbType.VarChar).Value = machineIssue.machine_id;
                    mySqlCommand.Parameters.Add("@submittedBy", MySqlDbType.VarChar).Value = machineIssue.submitted_by;
                    mySqlCommand.Parameters.Add("@submittedDate", MySqlDbType.DateTime).Value = machineIssue.submitted_date;
                    mySqlCommand.Parameters.Add("@subject", MySqlDbType.VarChar).Value = machineIssue.subject;
                    mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = machineIssue.description;
                    mySqlCommand.Parameters.Add("@priorityLevel", MySqlDbType.VarChar).Value = machineIssue.priority_level;
                    mySqlCommand.Parameters.Add("@status", MySqlDbType.VarChar).Value = machineIssue.status;
                    mySqlCommand.Prepare();

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to add Machine Issue" + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //update issue
        public bool updateMachineIssue(MachineIssue machineIssue)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `issue` SET `issue_machine_id`=@machineId, `issue_submitted_by`=@submittedBy, `issue_submitted_date`=@submittedDate, `issue_subject`=@subject, `issue_description`=@description, `issue_priority_level`=@priorityLevel, `issue_status`=@status WHERE `issue_id`=@issueId;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@issueId", MySqlDbType.VarChar).Value = machineIssue.issue_id;
                    mySqlCommand.Parameters.Add("@machineId", MySqlDbType.VarChar).Value = machineIssue.machine_id; 
                    mySqlCommand.Parameters.Add("@submittedBy", MySqlDbType.VarChar).Value = machineIssue.submitted_by;
                    mySqlCommand.Parameters.Add("@submittedDate", MySqlDbType.DateTime).Value = machineIssue.submitted_date;
                    mySqlCommand.Parameters.Add("@subject", MySqlDbType.VarChar).Value = machineIssue.subject;
                    mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = machineIssue.description;
                    mySqlCommand.Parameters.Add("@priorityLevel", MySqlDbType.VarChar).Value = machineIssue.priority_level;
                    mySqlCommand.Parameters.Add("@status", MySqlDbType.VarChar).Value = machineIssue.status;
                    mySqlCommand.Prepare();

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to update Machine Issue Details." + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //delete issue
        public bool deleteMachineIssue(string issue_id)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "DELETE FROM `issue` WHERE `issue_id`=@issueID";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@issueID", MySqlDbType.VarChar).Value = issue_id;
                    mySqlCommand.Prepare();

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to delete the Machine Issue Details.", "ERRORCODE");
                    }
                }
            }
        }

        //get all issues
        public List<MachineIssue> getAllMachineIssues()
        {
            List<MachineIssue> machineIssues = new List<MachineIssue>();

            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `issue` i LEFT JOIN `machine` m ON i.issue_machine_id = m.machine_id;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                //machine
                                String machine_id = mySqlDataReader.GetString("machine_id");
                                String serial_no = mySqlDataReader.GetString("serial_no");
                                String name = mySqlDataReader.GetString("name");
                                String location_id = mySqlDataReader.GetString("location_id");
                                String working_state = mySqlDataReader.GetString("working_state");
                                String added_by = mySqlDataReader.GetString("added_by");
                                DateTime added_date = (DateTime)mySqlDataReader.GetDateTime("added_date");
                                String description = mySqlDataReader.GetString("description");

                                Machine machine = new Machine(machine_id, serial_no, name, location_id, working_state, added_by, added_date, description);

                                //issue
                                String issue_id = mySqlDataReader.GetString("issue_id");
                                String issue_machine_id = mySqlDataReader.GetString("issue_machine_id");
                                String issue_subject = mySqlDataReader.GetString("issue_subject");
                                String issue_description = mySqlDataReader.GetString("issue_description");
                                String issue_status = mySqlDataReader.GetString("issue_status");
                                String issue_priority_level = mySqlDataReader.GetString("issue_priority_level");
                                DateTime issue_submitted_date = (DateTime)mySqlDataReader.GetDateTime("issue_submitted_date");
                                String issue_submitted_by = mySqlDataReader.GetString("issue_submitted_by");

                                MachineIssue machineIssue = new MachineIssue(issue_id, issue_subject, issue_machine_id, issue_submitted_by, issue_submitted_date, issue_description, issue_priority_level, issue_status);
                                machineIssue.machine = machine;
                                machineIssues.Add(machineIssue);
                            }
                        }

                        return machineIssues;
                    }
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to fetch Machine Issues " + ex.Message, "ERRORCODE");
                }
            }
        }

        //get all issues by user
        public List<MachineIssue> getAllMachineIssuesByUser(String userId)
        {
            List<MachineIssue> machineIssues = new List<MachineIssue>();

            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `issue` i LEFT JOIN `machine` m ON i.issue_machine_id = m.machine_id WHERE i.issue_submitted_by=@userId;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection; 

                        mySqlCommand.Parameters.Add("@userId", MySqlDbType.VarChar).Value = userId;

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                //machine
                                String machine_id = mySqlDataReader.GetString("machine_id");
                                String serial_no = mySqlDataReader.GetString("serial_no");
                                String name = mySqlDataReader.GetString("name");
                                String location_id = mySqlDataReader.GetString("location_id");
                                String working_state = mySqlDataReader.GetString("working_state");
                                String added_by = mySqlDataReader.GetString("added_by");
                                DateTime added_date = (DateTime)mySqlDataReader.GetDateTime("added_date");
                                String description = mySqlDataReader.GetString("description");

                                Machine machine = new Machine(machine_id, serial_no, name, location_id, working_state, added_by, added_date, description);

                                //issue
                                String issue_id = mySqlDataReader.GetString("issue_id");
                                String issue_machine_id = mySqlDataReader.GetString("issue_machine_id");
                                String issue_subject = mySqlDataReader.GetString("issue_subject");
                                String issue_description = mySqlDataReader.GetString("issue_description");
                                String issue_status = mySqlDataReader.GetString("issue_status");
                                String issue_priority_level = mySqlDataReader.GetString("issue_priority_level");
                                DateTime issue_submitted_date = (DateTime)mySqlDataReader.GetDateTime("issue_submitted_date");
                                String issue_submitted_by = mySqlDataReader.GetString("issue_submitted_by");

                                MachineIssue machineIssue = new MachineIssue(issue_id, issue_subject, issue_machine_id, issue_submitted_by, issue_submitted_date, issue_description, issue_priority_level, issue_status);
                                machineIssue.machine = machine;
                                machineIssues.Add(machineIssue);
                            }
                        }

                        return machineIssues;
                    }
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to fetch Machine Issues submitted by currently logged in user." + ex.Message, "ERRORCODE");
                }
            }
        }

        //modify issue status
        public Boolean updateMachineIssueStatus(String issue_id, String newStatus)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `issue` SET `issue_status`=@status WHERE `issue_id`=@issueId;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@issueId", MySqlDbType.VarChar).Value = issue_id;
                    mySqlCommand.Parameters.Add("@status", MySqlDbType.VarChar).Value = newStatus;
                    mySqlCommand.Prepare();

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to modify the Machine Issue Status." + ex.Message, "ERRORCODE");
                    }
                }
            }
        }
    }
}
