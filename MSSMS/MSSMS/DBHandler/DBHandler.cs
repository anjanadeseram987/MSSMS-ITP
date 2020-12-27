using MSSMS.Properties;
using MySql.Data.MySqlClient;
using System;

namespace MSSMS.DBHandler
{
    public class DBHandler
    {
        public MySqlConnection connection = null;

        public DBHandler ()
        {
            string host = Settings.Default.MySQLHost;
            string database = Settings.Default.MySQLDatabase;
            string port = Settings.Default.MySQLPort;
            string username = Settings.Default.MySQLUsername;
            string password = Settings.Default.MySQLPassword;
            string connectionString = "datasource =" + host + "; database ="+database+"; port ="+port+"; username ="+username+"; password ="+password+"; SslMode=none";
            connection = new MySqlConnection(connectionString);
        }

        //test method
        public String getMYSQLVersion()
        {
            using (connection)
            {
                connection.Open();
                return "MySQL version : " + connection.ServerVersion;
            }
        }
    }
}
