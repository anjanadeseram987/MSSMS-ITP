using MSSMS.Models;
using MSSMS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.DBHandler
{
    public class LobbyDBHandler:DBHandler
    {
        //Admin Lobby
        public LobbyData getAdminLobbyData()
        {
            LobbyData adminLobbyData = new LobbyData();
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `emp_count` FROM `employee`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                adminLobbyData.employeeCount = mySqlDataReader.GetInt32("emp_count");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `ua_count` FROM `user_credentials`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                adminLobbyData.userAccountCount = mySqlDataReader.GetInt32("ua_count");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `nauth_ua_count` FROM `user_credentials` WHERE `authorization_status` = 'NAUTH';";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                adminLobbyData.unauthorizedUACount = mySqlDataReader.GetInt32("nauth_ua_count");
                                break;
                            }
                        }
                    }

                    return adminLobbyData;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to fetch Employees " + ex.Message, "ERRORCODE");
                }
            }
        }

        //HR Lobby
        public LobbyData getHRLobbyData()
        {
            LobbyData hrLobbyData = new LobbyData();
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `emp_count` FROM `employee`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                hrLobbyData.employeeCount = mySqlDataReader.GetInt32("emp_count");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `dept_count` FROM `department`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                hrLobbyData.deptCount = mySqlDataReader.GetInt32("dept_count");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `desig_count` FROM `designation`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                hrLobbyData.desigCount = mySqlDataReader.GetInt32("desig_count");
                                break;
                            }
                        }
                    }

                    return hrLobbyData;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to fetch Employees " + ex.Message, "ERRORCODE");
                }
            }
        }

        //Engineer Lobby
        public LobbyData getEngineerLobbyData()
        {
            LobbyData engLobbyData = new LobbyData();
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `machine_count` FROM `machine`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                engLobbyData.machineCount = mySqlDataReader.GetInt32("machine_count");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `issue_count` FROM `issue` WHERE MONTH(`issue_submitted_date`) = MONTH(CURRENT_DATE())AND YEAR(`issue_submitted_date`) = YEAR(CURRENT_DATE());";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                engLobbyData.issueCount = mySqlDataReader.GetInt32("issue_count");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `issue_fixes_count` FROM `issue` WHERE `issue_status` = 'Resolved' AND (MONTH(`issue_submitted_date`) = MONTH(CURRENT_DATE())AND YEAR(`issue_submitted_date`) = YEAR(CURRENT_DATE()));";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                engLobbyData.issueFixesCount = mySqlDataReader.GetInt32("issue_fixes_count");
                                break;
                            }
                        }
                    }

                    return engLobbyData;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to fetch Employees " + ex.Message, "ERRORCODE");
                }
            }
        }

        //General Management Lobby
        public LobbyData getMgmtLobbyData()
        {
            LobbyData mgmtLobbyData = new LobbyData();
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `pending_na_productionplans` FROM `productionplan` WHERE `productionplan_status`='Pending' AND `productionplan_approved_by`=null;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                mgmtLobbyData.pendingProductionPlansNA = mySqlDataReader.GetInt32("pending_na_productionplans");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `pending_na_shippingschedules` FROM `shippingschedule` WHERE `ss_status`='Pending' AND `ss_approved_by`=null;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                mgmtLobbyData.pendingShippingSchedulesNA = mySqlDataReader.GetInt32("pending_na_shippingschedules");
                                break;
                            }
                        }
                    }

                    return mgmtLobbyData;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to fetch Employees " + ex.Message, "ERRORCODE");
                }
            }
        }

        //Production Manager Lobby
        public LobbyData getProductionLobbyData()
        {
            LobbyData productionLobbyData = new LobbyData();
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `ongoing_orders_count` FROM `order` WHERE `order_status` = 'Pending';";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                productionLobbyData.ordersInProgressCount = mySqlDataReader.GetInt32("ongoing_orders_count");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `completed_orders_duringmonth_count` FROM `order` WHERE `order_status`='Completed';";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                productionLobbyData.completedOrdersCount = mySqlDataReader.GetInt32("completed_orders_duringmonth_count");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `completed_mc_duringmonth_count` FROM `finishedgoods` WHERE MONTH(`fg_added_date`) = MONTH(CURRENT_DATE()) AND YEAR(`fg_added_date`) = YEAR(CURRENT_DATE());";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                productionLobbyData.completedMCDuringMonthCount = mySqlDataReader.GetInt32("completed_mc_duringmonth_count");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `received_orders_duringmonth_count` FROM `order` WHERE MONTH(`order_placement_date`) = MONTH(CURRENT_DATE()) AND YEAR(`order_placement_date`) = YEAR(CURRENT_DATE());";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                productionLobbyData.receivedOrdersDuringMonth = mySqlDataReader.GetInt32("received_orders_duringmonth_count");
                                break;
                            }
                        }
                    }

                    return productionLobbyData;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to fetch Employees " + ex.Message, "ERRORCODE");
                }
            }
        }

        //FG Operator Lobby
        public LobbyData getManufactLobbyData()
        {
            LobbyData manufactLobbyData = new LobbyData();
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `ongoing_orders_count` FROM `order` WHERE `order_status` = 'Pending';";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                manufactLobbyData.ordersInProgressCount = mySqlDataReader.GetInt32("ongoing_orders_count");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `completed_orders_count` FROM `order` WHERE `order_status`='Completed';";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                manufactLobbyData.completedOrdersCount = mySqlDataReader.GetInt32("completed_orders_count");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `completed_mc_duringmonth_count` FROM `finishedgoods` WHERE MONTH(`fg_added_date`) = MONTH(CURRENT_DATE()) AND YEAR(`fg_added_date`) = YEAR(CURRENT_DATE());";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                manufactLobbyData.completedMCDuringMonthCount = mySqlDataReader.GetInt32("completed_mc_duringmonth_count");
                                break;
                            }
                        }
                    }

                    return manufactLobbyData;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to fetch Employees " + ex.Message, "ERRORCODE");
                }
            }
        }

        //Store Lobby
        public LobbyData getStoreLobbyData()
        {
            LobbyData shippingLobbyData = new LobbyData();
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `nearly_exp_mc_countmonth` FROM `storedgoods` sg LEFT JOIN `finishedgoods` fg ON (fg.fg_orderitem_no = sg.sg_orderitem_no AND fg.fg_mc_no = sg.sg_mc_no) WHERE MONTH(fg.`fg_exp_date`) = MONTH(CURRENT_DATE()) AND YEAR(`fg_exp_date`) = YEAR(CURRENT_DATE()) AND fg.fg_exp_date > CURRENT_DATE();";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                shippingLobbyData.nearlyExpiredMCDuringMonthCount = mySqlDataReader.GetInt32("nearly_exp_mc_countmonth");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `stored_mc_countmonth` FROM `storedgoods` WHERE MONTH(`sg_stored_date`) = MONTH(CURRENT_DATE()) AND YEAR(`sg_stored_date`) = YEAR(CURRENT_DATE());";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                shippingLobbyData.storedMCDuringMonthCount = mySqlDataReader.GetInt32("stored_mc_countmonth");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `exp_mc_countmonth` FROM `storedgoods` sg LEFT JOIN `finishedgoods` fg ON (fg.fg_orderitem_no = sg.sg_orderitem_no AND fg.fg_mc_no = sg.sg_mc_no) WHERE MONTH(fg.`fg_exp_date`) = MONTH(CURRENT_DATE()) AND YEAR(`fg_exp_date`) = YEAR(CURRENT_DATE()) AND fg.fg_exp_date < CURRENT_DATE();";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                shippingLobbyData.expiredMCDuringMonthCount = mySqlDataReader.GetInt32("exp_mc_countmonth");
                                break;
                            }
                        }
                    }

                    return shippingLobbyData;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to fetch Employees " + ex.Message, "ERRORCODE");
                }
            }
        }

        //Shipping Lobby
        public LobbyData getShippingLobbyData()
        {
            LobbyData productionLobbyData = new LobbyData();
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `pending_ss_count` FROM `shippingschedule` WHERE `ss_status` = 'Pending' AND `ss_approved_by` is null;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                productionLobbyData.pendingSchedulesCount = mySqlDataReader.GetInt32("pending_ss_count");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `approved_ss_count` FROM `shippingschedule` WHERE `ss_status`='Pending' AND `ss_approved_by` is not null;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                productionLobbyData.approvedSchedulesCount = mySqlDataReader.GetInt32("approved_ss_count");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `completed_mc_duringmonth_count` FROM `finishedgoods` WHERE MONTH(`fg_added_date`) = MONTH(CURRENT_DATE()) AND YEAR(`fg_added_date`) = YEAR(CURRENT_DATE());";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                productionLobbyData.completedMCDuringMonthCount = mySqlDataReader.GetInt32("completed_mc_duringmonth_count");
                                break;
                            }
                        }
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT COUNT(*) AS `received_orders_duringmonth_count` FROM `order` WHERE MONTH(`order_placement_date`) = MONTH(CURRENT_DATE()) AND YEAR(`order_placement_date`) = YEAR(CURRENT_DATE());";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                productionLobbyData.receivedOrdersDuringMonth = mySqlDataReader.GetInt32("received_orders_duringmonth_count");
                                break;
                            }
                        }
                    }

                    return productionLobbyData;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to fetch Employees " + ex.Message, "ERRORCODE");
                }
            }
        }
    }
}
