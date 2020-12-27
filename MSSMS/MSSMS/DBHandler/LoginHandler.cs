using MSSMS.Enums;
using MSSMS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSMS.DBHandler
{
    public class LoginHandler : DBHandler
    {
        PasswordHasher passwordHasher = new PasswordHasher();

        //Synchronized version of validateUser method
        public UserAccountState validateUser(String username, String password)
        {
            string salt = null;
            string hash = null;

            using (connection)
            {
                connection.Open();
                string queryCredentials = "SELECT * FROM `user_credentials` WHERE (`username` = @username || `email` = @email || `employee_id` = @employeeId)";

                using (MySqlCommand mySqlCommand = new MySqlCommand(queryCredentials, connection))
                {
                    mySqlCommand.Parameters.AddWithValue("@username", username);
                    mySqlCommand.Parameters.AddWithValue("@email", username);
                    mySqlCommand.Parameters.AddWithValue("@employeeId", username);
                    mySqlCommand.Prepare();

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        if (mySqlDataReader.HasRows)
                        {
                            while (mySqlDataReader.Read())
                            {
                                //hash = Encoding.UTF8.GetBytes(mySqlDataReader.GetString("password_hash"));
                                //salt = Encoding.UTF8.GetBytes(mySqlDataReader.GetString("password_salt"));
                                hash = mySqlDataReader.GetString("password_hash");
                                salt = mySqlDataReader.GetString("password_salt");
                            }

                            if (passwordHasher.VerifyHash(password, Convert.FromBase64String(salt), Convert.FromBase64String(hash)) == true)
                            {
                                return UserAccountState.VALID;
                            }
                            else
                            {
                                return UserAccountState.INCORRECT;
                            }
                        }
                        else
                        {
                            return UserAccountState.INVALID;
                        }
                    }
                }
            }
        }

        //Async version of validateUser Method
        public async Task<UserAccountState> validateUserAsync(String username, String password)
        {
            string salt = null;
            string hash = null;

            using (connection)
            {
                await connection.OpenAsync();
                string queryCredentials = "SELECT * FROM `user_credentials` WHERE (`username` = @username || `email` = @email || `employee_id` = @employeeId)";

                using (MySqlCommand mySqlCommand = new MySqlCommand(queryCredentials, connection))
                {
                    mySqlCommand.Parameters.AddWithValue("@username", username);
                    mySqlCommand.Parameters.AddWithValue("@email", username);
                    mySqlCommand.Parameters.AddWithValue("@employeeId", username);
                    mySqlCommand.Prepare();

                    using (MySqlDataReader mySqlDataReader = (MySqlDataReader)await mySqlCommand.ExecuteReaderAsync())
                    {
                        if (mySqlDataReader.HasRows)
                        {
                            while (await mySqlDataReader.ReadAsync())
                            {
                                hash = mySqlDataReader.GetString("password_hash");
                                salt = mySqlDataReader.GetString("password_salt");
                            }

                            if (passwordHasher.VerifyHash(password, Convert.FromBase64String(salt), Convert.FromBase64String(hash)) == true)
                            {
                                return UserAccountState.VALID;
                            }
                            else
                            {
                                return UserAccountState.INCORRECT;
                            }
                        }
                        else
                        {
                            return UserAccountState.INVALID;
                        }
                    }
                }
            }
        }

        //check username validity against the useraccount data
        public async Task<bool> isValidUsernameAsync(string username)
        {
            bool status = false;
            using (connection)
            {
                await connection.OpenAsync();
                string queryGetEmail = "SELECT * FROM `user_credentials` WHERE (`username` = @username || `email` = @email || `employee_id` = @employeeId)";

                MySqlCommand mySqlCommand = new MySqlCommand(queryGetEmail, connection);
                mySqlCommand.CommandType = CommandType.Text;
                mySqlCommand.Parameters.AddWithValue("@username", username);
                mySqlCommand.Parameters.AddWithValue("@email", username);
                mySqlCommand.Parameters.AddWithValue("@employeeId", username);
                mySqlCommand.Prepare();

                using (MySqlDataReader mySqlDataReader = (MySqlDataReader)await mySqlCommand.ExecuteReaderAsync())
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

        //check db connection
        public async Task<bool> checkConnectionAsync()
        {
            bool connStatus = false;
            using (connection)
            {
                try
                {
                    await connection.OpenAsync();
                    connStatus = true;
                    connection.Close();
                } 
                catch (Exception ex)
                {
                    connStatus = false;
                    throw new MSSMUIException("Could not connect to the Server. " ,"SERVERERROR11");
                }
                return connStatus;
            }
        }
    }
}
