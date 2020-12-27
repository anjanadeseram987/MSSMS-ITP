using MSSMS.DBHandler;
using MSSMS.Enums;
using MSSMS.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MSSMS.Utilities
{
    public class SessionManager
    {
        //DAO
        private static UserAccountDBHandler userAccountDBHandler = new UserAccountDBHandler();

        //session variables
        public static SessionState sessionState { get; private set; } = SessionState.SESSION_ISNOTSET;
        public static UserInterface userInterface { get; private set; } = UserInterface.NOTSET;
        public static object currentLobby { get; set; } = null;
        public static String userInterfaceName { get; private set; } = null;
        public static UserAccount user { get; set; } = null;

        //
        //summery
        //      starts a new session by fetching the user details. returns false if userdetails cannot be fetched.
        public static SessionState getSession(String userId)
        {
            try
            {
                user = userAccountDBHandler.getUserAccountDetailsById(userId);
            }
            catch (Exception ex)
            {
                throw new MSSMUIException(ex.Message, "0006");
            }

            if (user != null)
            {
                if (user.authorizationStatus == "AUTH")
                {
                    setMainUserInterface();
                    if (userInterface != UserInterface.NOTSET)
                    {
                        sessionState = SessionState.SESSION_ISSET;
                    }
                    else
                    {
                        sessionState = SessionState.SESSION_ISNOTSET;
                        throw new MSSMUIException("Unable to start the application. Contact system administrator.", "0009");
                    }
                } 
                else
                {
                    sessionState = SessionState.SESSION_ISNOTSET;
                    throw new MSSMUIException("This is an unauthorized account. Contact system administrator.", "0008");
                }
                
            }
            else
            {
                sessionState = SessionState.SESSION_ISNOTSET;
                throw new MSSMUIException("Unable to start a session. Contact system administrator.", "0007");
            }

            return sessionState;
        }

        //
        //summery
        //      flushes a session on main UI closing or after users click on sign out.
        public static void flushSession()
        {
            try
            {
                //clear session objects
                sessionState = SessionState.SESSION_ISNOTSET;
                user = null;
                userInterface = UserInterface.NOTSET;
            } 
            catch (Exception ex)
            {
                //log
                //exit
                Application.Exit();
            }
        }

        public static void setMainUserInterface()
        {
            switch (user.role)
            {
                case "ADMIN":
                    userInterface = UserInterface.ADMIN;
                    userInterfaceName = "AdminLobby";
                    break;
                case "PRMGR":
                    userInterface = UserInterface.PRODUCTIONMANAGER;
                    userInterfaceName = "ProductionLobby";
                    break;
                case "GLMGR":
                    userInterface = UserInterface.GENERALMANAGER;
                    userInterfaceName = "MgmtLobby";
                    break;
                case "HRMGR":
                    userInterface = UserInterface.HRMANAGER;
                    userInterfaceName = "HRLobby";
                    break;
                case "FGOPR":
                    userInterface = UserInterface.FGOPERATOR;
                    userInterfaceName = "ManufactLobby";
                    break;
                case "STKPR":
                    userInterface = UserInterface.STOREKEEPER;
                    userInterfaceName = "StoreLobby";
                    break;
                case "SHMGR":
                    userInterface = UserInterface.SHIPPINGMANAGER;
                    userInterfaceName = "ShipLobby";
                    break;
                case "ENGNR":
                    userInterface = UserInterface.ENGINEER;
                    userInterfaceName = "MaintenanceLobby";
                    break;
                default:
                    userInterface = UserInterface.NOTSET;
                    userInterfaceName = null;
                    break;
            }
        }


        /*
        //methods for userdata binding
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public UserAccount _user
        {
            get
            {
                return user;
            }
            set
            {
                if (value != user)
                {
                    _user = value;
                }
            }
        }

        public string _username
        {
            get
            {
                return username;
            }
            set
            {
                if (value != username)
                {
                    _username = value;
                    NotifyPropertyChanged("username");
                }
            }
        }
        */
    }
}
