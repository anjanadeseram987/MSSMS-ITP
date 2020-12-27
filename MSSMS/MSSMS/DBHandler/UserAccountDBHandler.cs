using MSSMS.Models;
using MSSMS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace MSSMS.DBHandler
{
    public class UserAccountDBHandler:DBHandler
    {
        //fetch useraccount details
        public UserAccount getUserAccountDetailsById(String username)
        {
            UserAccount user = null;
            using (connection)
            {
                connection.Open();
                string queryGetEmployeeById = "SELECT e.employee_id, e.first_name, e.last_name, e.full_name, e.gender, e.birthday, e.primary_email, e.primary_phone, u.username, u.email, u.DP, u.role, u.authorization_status, u.last_authorized_by, dept.dept_name, dept.dept_id, desig.desig_name, desig.desig_id FROM employee e, user_credentials u, designation desig, department dept WHERE e.employee_id = u.employee_id AND (u.username =@username OR u.email=@email OR u.employee_id=@employeeId) AND e.desig_id = desig.desig_id AND desig.dept_id = dept.dept_id";

                MySqlCommand mySqlCommand = new MySqlCommand(queryGetEmployeeById, connection);
                mySqlCommand.CommandType = CommandType.Text;
                mySqlCommand.Parameters.AddWithValue("@username", username);
                mySqlCommand.Parameters.AddWithValue("@email", username);
                mySqlCommand.Parameters.AddWithValue("@employeeId", username);
                mySqlCommand.Prepare();

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        String employeeID = mySqlDataReader.GetString("employee_id");
                        String firstName = mySqlDataReader.GetString("first_name");
                        String lastName = mySqlDataReader.GetString("last_name");
                        String fullName = mySqlDataReader.GetString("full_name");
                        String gender = mySqlDataReader.GetString("gender");
                        DateTime birthday = mySqlDataReader.GetDateTime("birthday");
                        String primaryEmail = mySqlDataReader.GetString("primary_email");
                        String secondaryEmail = mySqlDataReader.GetString("email");
                        String primaryPhone = mySqlDataReader.GetString("primary_phone");
                        username = mySqlDataReader.GetString("username");
                        byte[] displayPicture = (byte[]) mySqlDataReader["DP"];
                        String role = mySqlDataReader.GetString("role");
                        String authorizationStatus = mySqlDataReader.GetString("authorization_status");
                        String authorizedBy = mySqlDataReader.GetString("last_authorized_by");
                        String deptId = mySqlDataReader.GetString("dept_id");
                        String desigId = mySqlDataReader.GetString("desig_id");
                        String deptName = mySqlDataReader.GetString("dept_name");
                        String desigName = mySqlDataReader.GetString("desig_name");

                        user = new UserAccount(employeeID, firstName, lastName, fullName, gender, birthday, primaryEmail, secondaryEmail, primaryPhone, username, role, authorizationStatus, authorizedBy , displayPicture, deptName, desigName, deptId, desigId);
                    }
                    mySqlDataReader.Close();
                }
            }
            return user;
        }

        //check username validity when user does not exist
        public bool isUsernameTaken(string username)
        {
            bool status = false;
            using (connection)
            {
                connection.Open();
                string queryGetEmployeeById = "SELECT * FROM `user_credentials` u, `employee` e WHERE u.employee_id=@username OR u.username=@username OR u.email=@username OR e.employee_id=@username OR e.primary_email=@username;";

                MySqlCommand mySqlCommand = new MySqlCommand(queryGetEmployeeById, connection);
                mySqlCommand.CommandType = CommandType.Text;
                mySqlCommand.Parameters.AddWithValue("@username", username);
                mySqlCommand.Prepare();

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
            }

            return status;
        }

        //check username except current user's if user already exists
        public bool isUsernameTakenExceptCurrentUser(string username, string employee_id)
        {
            bool status = false;
            using (connection)
            {
                connection.Open();
                string queryGetEmployeeById = "SELECT * FROM employee e LEFT JOIN user_credentials u ON e.employee_id = u.employee_id WHERE e.employee_id != @employeeId AND(e.employee_id = @username OR e.primary_email = @username OR u.username = @username OR u.email = @username)";

                MySqlCommand mySqlCommand = new MySqlCommand(queryGetEmployeeById, connection);
                mySqlCommand.CommandType = CommandType.Text;
                mySqlCommand.Parameters.AddWithValue("@username", username);
                mySqlCommand.Parameters.AddWithValue("@employeeId", employee_id);
                mySqlCommand.Prepare();

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
            }

            return status;
        }


        //check useraccount availability
        public bool isUseraccountPresent(string employeeID)
        {
            bool status = false;
            using (connection)
            {
                connection.Open();
                string queryGetEmployeeById = "SELECT * FROM `user_credentials` WHERE (`employee_id` = @employeeID)";

                MySqlCommand mySqlCommand = new MySqlCommand(queryGetEmployeeById, connection);
                mySqlCommand.CommandType = CommandType.Text;
                mySqlCommand.Parameters.AddWithValue("@employeeID", employeeID);
                mySqlCommand.Prepare();

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
            }

            return status;
        }

        //check employee id validity
        public bool isValidEmployeeID(string employeeID)
        {
            bool status = false;
            using (connection)
            {
                connection.Open();
                string queryGetEmployeeById = "SELECT * FROM `employee` WHERE (`employee_id` = @employeeID)";

                MySqlCommand mySqlCommand = new MySqlCommand(queryGetEmployeeById, connection);
                mySqlCommand.CommandType = CommandType.Text;
                mySqlCommand.Parameters.AddWithValue("@employeeID", employeeID);
                mySqlCommand.Prepare();

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
            }

            return status;
        }
        
        //check email validity against the useraccount data
        public bool isValidEmailAddess(string email)
        {
            bool status = false;
            using (connection)
            {
                connection.Open();
                string queryGetEmail = "SELECT * FROM `user_credentials` WHERE `email` = @email";

                MySqlCommand mySqlCommand = new MySqlCommand(queryGetEmail, connection);
                mySqlCommand.CommandType = CommandType.Text;
                mySqlCommand.Parameters.AddWithValue("@email", email);
                mySqlCommand.Prepare();

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
            }

            return status;
        }

        //save new reset token
        public bool saveNewToken(ResetToken newToken)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `user_credentials` SET `latestTFToken`=@token,`TFToken_expirydatetime`=@tokenExpiration, `isTokenUsed`=@isTokenUsed WHERE `email`=@email";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@email", MySqlDbType.VarChar).Value = newToken.userEmail;
                    mySqlCommand.Parameters.Add("@token", MySqlDbType.VarChar).Value = newToken.token;
                    mySqlCommand.Parameters.Add("@tokenExpiration", MySqlDbType.DateTime).Value = newToken.tokenExpiration;
                    mySqlCommand.Parameters.Add("@isTokenUsed", MySqlDbType.Int16).Value = newToken.isTokenUsed;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Reset Token generating process failed.", "DB0012");
                    }
                }
            }
        }

        //get Reset Token
        public ResetToken getTokenByEmail(String email)
        {
            ResetToken token = null;
            using (connection)
            {
                connection.Open();
                string queryGetTokenByEmail = "SELECT `email`, `latestTFToken`, `TFToken_expirydatetime`, `isTokenUsed` FROM `user_credentials` WHERE `email`=@email";

                MySqlCommand mySqlCommand = new MySqlCommand(queryGetTokenByEmail, connection);
                mySqlCommand.CommandType = CommandType.Text;
                mySqlCommand.Parameters.AddWithValue("@email", email);
                mySqlCommand.Prepare();

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    try
                    {
                        while (mySqlDataReader.Read())
                        {
                            string tokenDigits = mySqlDataReader.GetString("latestTFToken");
                            DateTime tokenExp = mySqlDataReader.GetDateTime("TFToken_expirydatetime");
                            email = mySqlDataReader.GetString("email");
                            int isTokenUsed = mySqlDataReader.GetUInt16("isTokenUsed");

                            token = new ResetToken(email, tokenDigits, tokenExp, isTokenUsed);
                        }
                    }
                    catch (Exception e)
                    {
                        throw new MSSMUIException("Failed to retrieve token data. " + e.Message, "DBERROR");
                    }
                }
            }

            return token;
        }

        //save new password
        public async Task<bool> saveNewPasswordByEmail(string email, string hash, string salt)
        {
            using (connection)
            {
                await connection.OpenAsync();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `user_credentials` SET `password_hash`=@hash,`password_salt`=@salt, `isTokenUsed`=@isTokenUsed WHERE `email`=@email";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@hash", MySqlDbType.VarChar).Value = hash;
                    mySqlCommand.Parameters.Add("@salt", MySqlDbType.VarChar).Value = salt;
                    mySqlCommand.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                    mySqlCommand.Parameters.Add("@isTokenUsed", MySqlDbType.UInt16).Value = 1;

                    try
                    {
                        await mySqlCommand.ExecuteNonQueryAsync();
                        await connection.CloseAsync();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to reset the password.", "DBERROR");
                    }
                }
            }
        }
        
        //update profile details
        public bool updateProfile(UserAccount newProfile)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `employee` e, `user_credentials` u SET e.`first_name`=@firstName, e.`last_name`=@lastName, e.`full_name`=@fullName, e.`gender`=@gender, e.`birthday`=@birthday, e.`primary_email`=@email, e.`primary_phone`=@phone, u.`dp`=@dp WHERE e.`employee_id`= u.`employee_id` AND e.`employee_id`=@employeeId;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = newProfile.firstName;
                    mySqlCommand.Parameters.Add("@lastName", MySqlDbType.VarChar).Value = newProfile.lastName;
                    mySqlCommand.Parameters.Add("@fullName", MySqlDbType.VarChar).Value = newProfile.fullName;
                    mySqlCommand.Parameters.Add("@gender", MySqlDbType.VarChar).Value = newProfile.gender;
                    mySqlCommand.Parameters.Add("@birthday", MySqlDbType.DateTime).Value = newProfile.birthday;
                    mySqlCommand.Parameters.Add("@phone", MySqlDbType.VarChar).Value = newProfile.primaryPhone;
                    mySqlCommand.Parameters.Add("@dp", MySqlDbType.Blob).Value = newProfile.profilePicture;
                    mySqlCommand.Parameters.Add("@email", MySqlDbType.VarChar).Value = newProfile.primaryEmail;
                    mySqlCommand.Parameters.Add("@employeeId", MySqlDbType.VarChar).Value = newProfile.employeeId;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to update the profile details " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //get current password
        public bool getCurrentPassword(string password, string employeeId)
        {
            string hash = null;
            string salt = null;
            bool isValidPassword = false;

            using (connection)
            {
                connection.Open();
                string queryGetTokenByEmail = "SELECT `password_hash`, `password_salt` FROM `user_credentials` WHERE `employee_id`=@employeeId";

                MySqlCommand mySqlCommand = new MySqlCommand(queryGetTokenByEmail, connection);
                mySqlCommand.CommandType = CommandType.Text;
                mySqlCommand.Parameters.AddWithValue("@employeeId", employeeId);
                mySqlCommand.Prepare();

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        hash = mySqlDataReader.GetString("password_hash");
                        salt = mySqlDataReader.GetString("password_salt");
                    }
                    mySqlDataReader.Close();

                    PasswordHasher passwordHasher = new PasswordHasher();
                    isValidPassword = passwordHasher.VerifyHash(password, Convert.FromBase64String(salt), Convert.FromBase64String(hash));
                }
            }

            return isValidPassword;
        }

        //add user accounts
        public bool addUserAccount(UserAccount userAccount)
        {
            PasswordHasher passwordHasher = new PasswordHasher();
            string salt = Convert.ToBase64String(passwordHasher.CreateSalt());
            string hash = Convert.ToBase64String(passwordHasher.HashPassword(userAccount.newPassword, Convert.FromBase64String(salt)));

            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `user_credentials` (`employee_id`, `username`, `email`, `password_hash`, `password_salt`, `dp`, `role`, `authorization_status`, `last_authorized_by`, `latestTFToken`, `TFToken_expirydatetime`, `isTokenUsed`) VALUES(@employeeId, @username, @email, @hash, @salt, @dp, @role, @authStatus, @authBy, @token, @tokenExp, @isTokenUsed)";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@employeeId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                        mySqlCommand.Parameters.Add("@username", MySqlDbType.VarChar).Value = userAccount.username;
                        mySqlCommand.Parameters.Add("@email", MySqlDbType.VarChar).Value = userAccount.secondaryEmail;
                        mySqlCommand.Parameters.Add("@hash", MySqlDbType.VarChar).Value = hash;
                        mySqlCommand.Parameters.Add("@salt", MySqlDbType.VarChar).Value = salt;
                        mySqlCommand.Parameters.Add("@dp", MySqlDbType.Blob).Value = userAccount.profilePicture;
                        mySqlCommand.Parameters.Add("@role", MySqlDbType.VarChar).Value = userAccount.role;
                        mySqlCommand.Parameters.Add("@authStatus", MySqlDbType.VarChar).Value = userAccount.authorizationStatus;
                        mySqlCommand.Parameters.Add("@authBy", MySqlDbType.VarChar).Value = userAccount.authorizedBy;
                        mySqlCommand.Parameters.Add("@token", MySqlDbType.VarChar).Value = "-1";
                        mySqlCommand.Parameters.Add("@tokenExp", MySqlDbType.DateTime).Value = DateTime.MinValue;
                        mySqlCommand.Parameters.Add("@isTokenUsed", MySqlDbType.VarChar).Value = -1;
                        mySqlCommand.Prepare();


                        mySqlCommand.ExecuteNonQuery();
                    }

                    switch (userAccount.role)
                    {
                        case "ADMIN":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "INSERT INTO `admin` (`admin_id`) VALUES(@adminId)";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@adminId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        case "PRMGR":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "INSERT INTO `productionmanager` (`productionmanager_id`) VALUES(@productionmanagerId)";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@productionmanagerId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        case "GLMGR":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "INSERT INTO `generalmanager` (`generalmanager_id`) VALUES(@generalmanagerId)";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@generalmanagerId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        case "HRMGR":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "INSERT INTO `hrmanager` (`hrmanager_id`) VALUES(@hrmanagerId)";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@hrmanagerId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        case "FGOPR":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "INSERT INTO `operator` (`operator_id`) VALUES(@operatorId)";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@operatorId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        case "STKPR":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "INSERT INTO `storekeeper` (`storekeeper_id`) VALUES(@storekeeperId)";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@storekeeperId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        case "SHMGR":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "INSERT INTO `shippingmanager` (`shippingmanager_id`) VALUES(@shippingmanagerId)";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@shippingmanagerId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        case "ENGNR":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "INSERT INTO `engineer` (`engineer_id`) VALUES(@engineerId)";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@engineerId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        default:
                            //do nothing
                            break;
                    }

                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to create the User Account" + ex.Message, "45");
                }
            }
        }

        //update user account
        public bool updateUserAccount(UserAccount userAccount, string oldRole)
        {
            PasswordHasher passwordHasher = new PasswordHasher();
            string salt = Convert.ToBase64String(passwordHasher.CreateSalt());
            string hash = Convert.ToBase64String(passwordHasher.HashPassword(userAccount.newPassword, Convert.FromBase64String(salt)));

            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `user_credentials` SET `username`=@username,`password_hash`=@hash, `password_salt`=@salt, `dp`=@dp, `email`=@email,`role`=@role WHERE `employee_id`=@employeeId";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@username", MySqlDbType.VarChar).Value = userAccount.username;
                        mySqlCommand.Parameters.Add("@hash", MySqlDbType.VarChar).Value = hash;
                        mySqlCommand.Parameters.Add("@salt", MySqlDbType.VarChar).Value = salt;
                        mySqlCommand.Parameters.Add("@dp", MySqlDbType.Blob).Value = userAccount.profilePicture;
                        mySqlCommand.Parameters.Add("@email", MySqlDbType.VarChar).Value = userAccount.secondaryEmail;
                        mySqlCommand.Parameters.Add("@role", MySqlDbType.VarChar).Value = userAccount.role;
                        mySqlCommand.Parameters.Add("@employeeId", MySqlDbType.VarChar).Value = userAccount.employeeId;

                        mySqlCommand.ExecuteNonQuery();
                    }

                    if (oldRole != userAccount.role)
                    {
                        switch (oldRole)
                        {
                            case "ADMIN":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `admin` WHERE `admin_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "PRMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `productionmanager` WHERE productionmanager_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "GLMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `generalmanager` WHERE `generalmanager_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "HRMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `hrmanager` WHERE `hrmanager_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "FGOPR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `operator` WHERE `operator_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "STKPR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `storekeeper` WHERE `storekeeper_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "SHMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `shippingmanager` WHERE `shippingmanager_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "ENGNR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `engineer` WHERE `engineer_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            default:
                                //do nothing
                                break;
                        }

                        switch (userAccount.role)
                        {
                            case "ADMIN":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `admin` (`admin_id`) VALUES(@adminId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@adminId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "PRMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `productionmanager` (`productionmanager_id`) VALUES(@productionmanagerId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@productionmanagerId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "GLMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `generalmanager` (`generalmanager_id`) VALUES(@generalmanagerId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@generalmanagerId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "HRMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `hrmanager` (`hrmanager_id`) VALUES(@hrmanagerId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@hrmanagerId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "FGOPR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `operator` (`operator_id`) VALUES(@operatorId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@operatorId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "STKPR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `storekeeper` (`storekeeper_id`) VALUES(@storekeeperId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@storekeeperId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "SHMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `shippingmanager` (`shippingmanager_id`) VALUES(@shippingmanagerId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@shippingmanagerId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "ENGNR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `engineer` (`engineer_id`) VALUES(@engineerId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@engineerId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            default:
                                //do nothing
                                break;
                        }
                    }

                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to update the user account " + ex.Message, "ERRORCODE");
                }
            }
        }

        //update user account w/o password
        public bool updateUserAccountWithoutPassword(UserAccount userAccount, string oldRole)
        {
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `user_credentials` SET `username`=@username,`dp`=@dp, `email`=@email,`role`=@role WHERE `employee_id`=@employeeId";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@username", MySqlDbType.VarChar).Value = userAccount.username;
                        mySqlCommand.Parameters.Add("@dp", MySqlDbType.Blob).Value = userAccount.profilePicture;
                        mySqlCommand.Parameters.Add("@email", MySqlDbType.VarChar).Value = userAccount.secondaryEmail;
                        mySqlCommand.Parameters.Add("@role", MySqlDbType.VarChar).Value = userAccount.role;
                        mySqlCommand.Parameters.Add("@employeeId", MySqlDbType.VarChar).Value = userAccount.employeeId;

                        mySqlCommand.ExecuteNonQuery();
                    }

                    if (oldRole != userAccount.role)
                    {
                        switch (oldRole)
                        {
                            case "ADMIN":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `admin` WHERE `admin_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "PRMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `productionmanager` WHERE `productionmanager_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "GLMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `generalmanager` WHERE `generalmanager_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "HRMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `hrmanager` WHERE `hrmanager_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "FGOPR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `operator` WHERE `operator_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "STKPR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `storekeeper` WHERE `storekeeper_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "SHMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `shippingmanager` WHERE `shippingmanager_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "ENGNR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "DELETE FROM `engineer` WHERE `engineer_id`=@employeeID";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            default:
                                //do nothing
                                break;
                        }

                        switch (userAccount.role)
                        {
                            case "ADMIN":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `admin` (`admin_id`) VALUES(@adminId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@adminId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "PRMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `productionmanager` (`productionmanager_id`) VALUES(@productionmanagerId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@productionmanagerId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "GLMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `generalmanager` (`generalmanager_id`) VALUES(@generalmanagerId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@generalmanagerId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "HRMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `hrmanager` (`hrmanager_id`) VALUES(@hrmanagerId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@hrmanagerId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "FGOPR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `operator` (`operator_id`) VALUES(@operatorId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@operatorId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "STKPR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `storekeeper` (`storekeeper_id`) VALUES(@storekeeperId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@storekeeperId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "SHMGR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `shippingmanager` (`shippingmanager_id`) VALUES(@shippingmanagerId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@shippingmanagerId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            case "ENGNR":
                                using (MySqlCommand mySqlCommand = new MySqlCommand())
                                {
                                    mySqlCommand.CommandText = "INSERT INTO `engineer` (`engineer_id`) VALUES(@engineerId)";
                                    mySqlCommand.CommandType = CommandType.Text;
                                    mySqlCommand.Connection = connection;

                                    mySqlCommand.Parameters.Add("@engineerId", MySqlDbType.VarChar).Value = userAccount.employeeId;
                                    mySqlCommand.Prepare();

                                    mySqlCommand.ExecuteNonQuery();
                                }
                                break;
                            default:
                                //do nothing
                                break;
                        }
                    }

                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to update the user account w/p " + ex.Message, "ERRORCODE");
                }
            }
        }

        //delete user account
        public bool deleteUserAccount(string employee_id, string role)
        {
            using (connection)
            {
                try
                {
                    connection.Open();
                    switch (role)
                    {
                        case "ADMIN":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "DELETE FROM `admin` WHERE `admin_id`=@employeeID";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = employee_id;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        case "PRMGR":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "DELETE FROM `productionmanager` WHERE `productionmanager_id`=@employeeID";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = employee_id;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        case "GLMGR":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "DELETE FROM `generalmanager` WHERE `generalmanager_id`=@employeeID";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = employee_id;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        case "HRMGR":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "DELETE FROM `hrmanager` WHERE `hrmanager_id`=@employeeID";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = employee_id;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        case "FGOPR":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "DELETE FROM `operator` WHERE `operator_id`=@employeeID";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = employee_id;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        case "STKPR":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "DELETE FROM `storekeeper` WHERE `storekeeper_id`=@employeeID";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = employee_id;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        case "SHMGR":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "DELETE FROM `shippingmanager` WHERE `shippingmanager_id`=@employeeID";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = employee_id;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        case "ENGNR":
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "DELETE FROM `engineer` WHERE `engineer_id`=@employeeID";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = employee_id;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                            break;
                        default:
                            //do nothing
                            break;
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "DELETE FROM `user_credentials` WHERE `employee_id`=@employeeID";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = employee_id;

                        mySqlCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
                catch (Exception)
                {
                    throw new MSSMUIException("Failed to delete the User Account", "ERRORCODE");
                }
            }
        }

        //get all accounts
        public List<UserAccount> getAllUserAccounts()
        {
            List<UserAccount> userAccounts = new List<UserAccount>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT e.employee_id, e.first_name, e.last_name, e.full_name, e.gender, e.birthday, e.primary_email, e.primary_phone, u.username, u.email, u.DP, u.role, u.authorization_status, u.last_authorized_by, dept.dept_name, dept.dept_id, desig.desig_name, desig.desig_id FROM employee e, user_credentials u, designation desig, department dept WHERE e.employee_id = u.employee_id AND e.desig_id = desig.desig_id AND desig.dept_id = dept.dept_id";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String employeeID = mySqlDataReader.GetString("employee_id");
                                String firstName = mySqlDataReader.GetString("first_name");
                                String lastName = mySqlDataReader.GetString("last_name");
                                String fullName = mySqlDataReader.GetString("full_name");
                                String gender = mySqlDataReader.GetString("gender");
                                DateTime birthday = mySqlDataReader.GetDateTime("birthday");
                                String primaryEmail = mySqlDataReader.GetString("primary_email");
                                String secondaryEmail = mySqlDataReader.GetString("email");
                                String primaryPhone = mySqlDataReader.GetString("primary_phone");
                                String username = mySqlDataReader.GetString("username");
                                byte[] displayPicture = (byte[]) mySqlDataReader["DP"];
                                String role = mySqlDataReader.GetString("role");
                                String authorizationStatus = mySqlDataReader.GetString("authorization_status");
                                String authorizedBy = mySqlDataReader.GetString("last_authorized_by");
                                String deptId = mySqlDataReader.GetString("dept_id");
                                String desigId = mySqlDataReader.GetString("desig_id");
                                String deptName = mySqlDataReader.GetString("dept_name");
                                String desigName = mySqlDataReader.GetString("desig_name");

                                UserAccount userAccount = new UserAccount(employeeID, firstName, lastName, fullName, gender, birthday, primaryEmail, secondaryEmail, primaryPhone, username, role, authorizationStatus, authorizedBy, displayPicture, deptName, desigName, deptId, desigId);
                                userAccounts.Add(userAccount);
                            }

                            return userAccounts;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw new MSSMUIException("Failed to fetch User Accounts " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //authorize or deauthorize user account
        public bool modifyUserAccountAuthorizationLevel(string authLevel, string admin_Id, string employee_id)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `user_credentials` SET `authorization_status`=@authLevel,`last_authorized_by`=@adminId WHERE `employee_id`=@employeeId";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@authLevel", MySqlDbType.VarChar).Value = authLevel;
                    mySqlCommand.Parameters.Add("@adminId", MySqlDbType.VarChar).Value = admin_Id;
                    mySqlCommand.Parameters.Add("@employeeId", MySqlDbType.VarChar).Value = employee_id;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to modify account authorization level.", "ERRORCODE");
                    }
                }
            }
        }

        //modify user account role
        public bool modifyUserAccountRole(string role, string employee_id)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `user_credentials` SET `role`=@role WHERE `employee_id`=@employeeId";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@role", MySqlDbType.VarChar).Value = role;
                    mySqlCommand.Parameters.Add("@employeeId", MySqlDbType.VarChar).Value = employee_id;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to modify user account role.", "ERRORCODE");
                    }
                }
            }
        }

        //update username
        public bool updateUsername(string newUsername, string employee_id)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `user_credentials` SET `username`=@newUsername WHERE `employee_id`=@employeeId;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@newUsername", MySqlDbType.VarChar).Value = newUsername;
                    mySqlCommand.Parameters.Add("@employeeId", MySqlDbType.VarChar).Value = employee_id;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to update the username.", "ERRORCODE");
                    }
                }
            }
        }

        //update password
        public async Task<bool> updatePasswordAsync(string oldPassword, string newPassword, string employee_id)
        {
            byte[] hash = null;
            byte[] salt = null;
            PasswordHasher passwordHasher = new PasswordHasher();

            using (connection)
            {
                try
                {
                    await connection.OpenAsync();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {

                        mySqlCommand.CommandText = "SELECT `password_hash`, `password_salt` FROM `user_credentials` WHERE `employee_id`=@employeeId";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@employeeId", MySqlDbType.VarChar).Value = employee_id;
                        mySqlCommand.Prepare();

                        await mySqlCommand.ExecuteNonQueryAsync();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (await mySqlDataReader.ReadAsync())
                            {
                                hash = Convert.FromBase64String(mySqlDataReader.GetString("password_hash"));
                                salt = Convert.FromBase64String(mySqlDataReader.GetString("password_salt"));
                            }
                            mySqlDataReader.Close();
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        if (await Task.Run(()=>passwordHasher.VerifyHash(oldPassword, salt, hash)) == true)
                        {
                            salt = await Task.Run(()=>passwordHasher.CreateSalt());
                            hash = await Task.Run(()=>passwordHasher.HashPassword(newPassword, salt));

                            mySqlCommand.CommandText = "UPDATE `user_credentials` SET `password_hash`=@newHash, `password_salt`=@newSalt WHERE `employee_id`=@employeeId;";
                            mySqlCommand.CommandType = CommandType.Text;
                            mySqlCommand.Connection = connection;

                            mySqlCommand.Parameters.Add("@newHash", MySqlDbType.VarChar).Value = Convert.ToBase64String(hash);
                            mySqlCommand.Parameters.Add("@newSalt", MySqlDbType.VarChar).Value = Convert.ToBase64String(salt);
                            mySqlCommand.Parameters.Add("@employeeId", MySqlDbType.VarChar).Value = employee_id;

                            await mySqlCommand.ExecuteNonQueryAsync();
                            await connection.CloseAsync();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to update the password." + ex.Message, "ERRORCODE");
                }
            }
        }
                
        //update username
        public bool updateSecondaryEmail(string newEmail, string employee_id)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `user_credentials` SET `email`=@newEmail WHERE `employee_id`=@employeeId;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@newEmail", MySqlDbType.VarChar).Value = newEmail;
                    mySqlCommand.Parameters.Add("@employeeId", MySqlDbType.VarChar).Value = employee_id;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to update the email address.", "ERRORCODE");
                    }
                }
            }
        }
    }
}
