using MSSMS.Models;
using MSSMS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MSSMS.DBHandler
{
    public class ShippingDBHandler:DBHandler
    {
        //add shipping schedule
        public String addShippingSchedule(ShippingSchedule shippingSchedule)
        {
            String scheduleId = null;
            String contractNo = null;

            using (connection)
            {
                try
                {
                    connection.Open();

                    //inserting plan
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `shippingschedule`(`ss_shipping_date`, `ss_loading_date`, `ss_destination`, `ss_address`, `ss_added_by`, `ss_added_date`, `ss_approved_by`, `ss_approved_date`, `ss_status`, `ss_remarks`) VALUES (@shippingDate, @loadingDate, @destination, @address, @addedBy, @addedDate, @approvedBy, @approvedDate, @status, @remarks);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@shippingDate", MySqlDbType.DateTime).Value = shippingSchedule.shipping_date;
                        mySqlCommand.Parameters.Add("@loadingDate", MySqlDbType.DateTime).Value = shippingSchedule.loading_date;
                        mySqlCommand.Parameters.Add("@destination", MySqlDbType.VarChar).Value = shippingSchedule.destination;
                        mySqlCommand.Parameters.Add("@address", MySqlDbType.VarChar).Value = shippingSchedule.address;
                        mySqlCommand.Parameters.Add("@addedBy", MySqlDbType.VarChar).Value = shippingSchedule.added_by;
                        mySqlCommand.Parameters.Add("@addedDate", MySqlDbType.DateTime).Value = shippingSchedule.added_date;
                        mySqlCommand.Parameters.Add("@approvedBy", MySqlDbType.VarChar).Value = shippingSchedule.approved_by;
                        mySqlCommand.Parameters.Add("@approvedDate", MySqlDbType.DateTime).Value = shippingSchedule.approved_date;
                        mySqlCommand.Parameters.Add("@status", MySqlDbType.VarChar).Value = shippingSchedule.status;
                        mySqlCommand.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = shippingSchedule.remarks;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    //reading last insert plan id
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `shippingschedule` WHERE `ss_loading_date`=@loadingDate AND `ss_added_by`=@addedBy AND `ss_added_date`=@addedDate;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@loadingDate", MySqlDbType.VarChar).Value = shippingSchedule.loading_date.ToString("yyyy-MM-dd HH:mm:ss");
                        mySqlCommand.Parameters.Add("@addedBy", MySqlDbType.VarChar).Value = shippingSchedule.added_by;
                        mySqlCommand.Parameters.Add("@addedDate", MySqlDbType.VarChar).Value = shippingSchedule.added_date.ToString("yyyy-MM-dd HH:mm:ss");
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                scheduleId = mySqlDataReader.GetString("ss_schedule_id");
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(scheduleId))
                    {
                        throw new MSSMUIException("Could not create the Schedule.");
                    }
                    else
                    {

                        //place new contract for the newly inserted schedule that helps
                        //it to be assigned to order items
                        using (MySqlCommand mySqlCommand = new MySqlCommand())
                        {
                            mySqlCommand.CommandText = "INSERT INTO `contract`(`contract_placement_date`, `contract_status`) VALUES (@placementDate, @status);";
                            mySqlCommand.CommandType = CommandType.Text;
                            mySqlCommand.Connection = connection;

                            mySqlCommand.Parameters.Add("@placementDate", MySqlDbType.DateTime).Value = shippingSchedule.added_date;
                            mySqlCommand.Parameters.Add("@status", MySqlDbType.VarChar).Value = shippingSchedule.status;
                            mySqlCommand.Prepare();

                            mySqlCommand.ExecuteNonQuery();
                        }

                        //retreiving the contract id that has been just placed 
                        using (MySqlCommand mySqlCommand = new MySqlCommand())
                        {
                            mySqlCommand.CommandText = "SELECT * FROM `contract` WHERE `contract_placement_date`=@placementDate AND `contract_status`=@status;";
                            mySqlCommand.CommandType = CommandType.Text;
                            mySqlCommand.Connection = connection;

                            mySqlCommand.Parameters.Add("@placementDate", MySqlDbType.VarChar).Value = shippingSchedule.added_date.ToString("yyyy/MM/dd HH:mm:ss"); ;
                            mySqlCommand.Parameters.Add("@status", MySqlDbType.VarChar).Value = shippingSchedule.status;
                            mySqlCommand.Prepare();

                            using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                            {
                                while (mySqlDataReader.Read())
                                {
                                    contractNo = mySqlDataReader.GetString("contract_no");
                                }
                            }
                        }

                        if (string.IsNullOrEmpty(contractNo))
                        {
                            throw new MSSMUIException("Could not place the contract.");
                        }
                        else
                        {

                            //bind schedule and contract together
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "INSERT INTO `contractschedule`(`contract_no`, `schedule_id`) VALUES (@contractNo, @scheduleId);";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@contractNo", MySqlDbType.VarChar).Value = contractNo;
                                mySqlCommand.Parameters.Add("@scheduleId", MySqlDbType.VarChar).Value = scheduleId;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }

                            connection.Close();
                            return scheduleId;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to Add the Shipping Schedule. " + ex.Message, "ERRORCODE");
                }
            }
        }

        //update shipping schedule
        public Boolean updateShippingSchedule(ShippingSchedule shippingSchedule)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `shippingschedule` SET `ss_loading_date`=@loadingDate, `ss_destination`=@destination, `ss_address`=@address, `ss_added_by`=@addedBy, `ss_added_date`=@addedDate, `ss_status`=@status, `ss_remarks`=@remarks WHERE `ss_schedule_id`= @scheduleId;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@scheduleId", MySqlDbType.VarChar).Value = shippingSchedule.shippingschedule_id;
                    mySqlCommand.Parameters.Add("@loadingDate", MySqlDbType.DateTime).Value = shippingSchedule.loading_date;
                    mySqlCommand.Parameters.Add("@destination", MySqlDbType.VarChar).Value = shippingSchedule.destination;
                    mySqlCommand.Parameters.Add("@address", MySqlDbType.VarChar).Value = shippingSchedule.address;
                    mySqlCommand.Parameters.Add("@addedBy", MySqlDbType.VarChar).Value = shippingSchedule.added_by;
                    mySqlCommand.Parameters.Add("@addedDate", MySqlDbType.DateTime).Value = shippingSchedule.added_date;
                    mySqlCommand.Parameters.Add("@status", MySqlDbType.VarChar).Value = shippingSchedule.status;
                    mySqlCommand.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = shippingSchedule.remarks;
                    mySqlCommand.Prepare();

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to update the Shipping Schedule Details " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //delete shipping schedule
        public Boolean deleteShippingSchedule(String scheduleId, String contractNo)
        {
            using (connection)
            {
                try
                {
                    connection.Open();

                    //setting order item contract back to null before deleting the schedule
                    //in orer to detach the schedule from the order item
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `orderitem` SET `contract_no`=null WHERE `contract_no`=@contractNo;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@contractNo", MySqlDbType.VarChar).Value = contractNo;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    //deleting the contract from contractschedule and contract tables associated with the schedule
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "DELETE FROM  `contractschedule` WHERE `contract_no`=@contractNo;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@contractNo", MySqlDbType.VarChar).Value = contractNo;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "DELETE FROM  `contract` WHERE `contract_no`=@contractNo;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@contractNo", MySqlDbType.VarChar).Value = contractNo;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    //deleting the schedule
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "DELETE FROM `shippingschedule` WHERE `ss_schedule_id`= @scheduleId";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@scheduleId", MySqlDbType.VarChar).Value = scheduleId;

                        mySqlCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
                catch (Exception)
                {
                    throw new MSSMUIException("Failed to delete the Shipping Schedule", "ERRORCODE");
                }
            }
        }

        //get all shipping schedules
        public List<ShippingSchedule> getShippingSchedules()
        {
            List<ShippingSchedule> shippingSchedules = new List<ShippingSchedule>();

            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `shippingschedule` ss LEFT JOIN `contractschedule` cs ON cs.schedule_id = ss.ss_schedule_id LEFT JOIN (SELECT `contract_no`, COUNT(*) AS `oi_count` FROM `orderitem` GROUP BY `contract_no`) cc ON cc.contract_no = cs.contract_no LEFT JOIN (SELECT  `contract_no`, SUM(`mc_quantity`) AS `total_mc_count` FROM `orderitem` GROUP BY `contract_no`) oi ON oi.contract_no = cc.contract_no ORDER BY ss.`ss_loading_date`;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String schedule_id = mySqlDataReader.GetString("ss_schedule_id");
                                DateTime loading_date = mySqlDataReader.GetDateTime("ss_loading_date");
                                String destination = mySqlDataReader.GetString("ss_destination");
                                String address = mySqlDataReader.GetString("ss_address");
                                String added_by = mySqlDataReader.GetString("ss_added_by");
                                DateTime added_date = mySqlDataReader.GetDateTime("ss_added_date");
                                String approved_by = mySqlDataReader.IsDBNull(7) ? "N/A" : mySqlDataReader.GetString("ss_approved_by");
                                DateTime approved_date = mySqlDataReader.IsDBNull(8) ? DateTime.MinValue : mySqlDataReader.GetDateTime("ss_approved_date");
                                String status = mySqlDataReader.IsDBNull(6) ? "N/A" : mySqlDataReader.GetString("ss_status");
                                String remarks = mySqlDataReader.IsDBNull(10) ? "N/A" : mySqlDataReader.GetString("ss_remarks");
                                String contract_no = mySqlDataReader.IsDBNull(11) ? "N/A" : mySqlDataReader.GetString("contract_no");
                                int oi_count = mySqlDataReader.IsDBNull(14) ? 0 : mySqlDataReader.GetInt32("oi_count");
                                int total_mc_count = mySqlDataReader.IsDBNull(16) ? 0 : mySqlDataReader.GetInt32("total_mc_count");

                                ShippingSchedule shippingSchedule = new ShippingSchedule(schedule_id, loading_date, DateTime.MinValue, destination, address, added_by, added_date, approved_by, approved_date, remarks, status);
                                shippingSchedule.oi_per_ss_count = oi_count;
                                shippingSchedule.contract_no = contract_no;
                                shippingSchedule.total_mc_count = total_mc_count;
                                shippingSchedules.Add(shippingSchedule);
                            }
                        }
                    }
                    return shippingSchedules;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to fetch Production Plans " + ex.Message, "ERRORCODE");
                }
            }
        }

        //add order item to schedule
        public Boolean addOrderItemToSchedule(String scheduleId, String orderItemNo)
        {
            String contractNo = null;
            using (connection)
            {
                try
                {
                    connection.Open();

                    //retreiving contract no assigned to the schedule
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT `contract_no` FROM `contractschedule` WHERE `schedule_id`=@scheduleId;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@scheduleId", MySqlDbType.VarChar).Value = scheduleId;
                        mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = orderItemNo;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                contractNo = mySqlDataReader.GetString("contract_no");
                            }
                        }
                    }

                    if (contractNo == null)
                    {
                        throw new MSSMUIException("Failed to obtain the contract number for the given schedule.");
                    }
                    else
                    {
                        //updating production plan id in order item
                        using (MySqlCommand mySqlCommand = new MySqlCommand())
                        {
                            mySqlCommand.CommandText = "UPDATE `orderitem` SET `contract_no`=@contractNo WHERE `orderitem_no`=@orderItemNo;";
                            mySqlCommand.CommandType = CommandType.Text;
                            mySqlCommand.Connection = connection;

                            mySqlCommand.Parameters.Add("@contractNo", MySqlDbType.VarChar).Value = contractNo;
                            mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = orderItemNo;
                            mySqlCommand.Prepare();

                            mySqlCommand.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to Add Order Item to the Shipping Schedule. " + ex.Message, "ERRORCODE");
                }
            }
        }

        //remove order item from schedule
        public Boolean removeOrderItemFromSchedule(String orderItemNo)
        {
            using (connection)
            {
                try
                {
                    connection.Open();

                    //removing production plan id from order item
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `orderitem` SET `contract_no`=null WHERE `orderitem_no`=@orderItemNo;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = orderItemNo;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new MSSMUIException("Failed to Remove Order Item from the Shipping Schedule. " + ex.Message, "ERRORCODE");
                }
            }
        }

        //modify approval status of the schedules
        public Boolean modifyApprovalState(DateTime approvedDate, String approvedBy, String scheduleId)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `shippingschedule` SET `ss_approved_by`=@approvedBy, `ss_approved_date`=@approvedDate WHERE `ss_schedule_id`=@scheduleId;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@approvedBy", MySqlDbType.VarChar).Value = approvedBy;
                    mySqlCommand.Parameters.Add("@approvedDate", MySqlDbType.DateTime).Value = approvedDate;
                    mySqlCommand.Parameters.Add("@scheduleId", MySqlDbType.VarChar).Value = scheduleId;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception e)
                    {
                        throw new MSSMUIException("Failed to modify approval status." + e.Message, "ERRORCODE");
                    }
                }
            }
        }

        //update shipping schedule status
        public Boolean changeScheduleStatus(String scheduleStatus, String scheduleId)
        {
            using (connection)
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `shippingschedule` SET `ss_status`=@scheduleStatus WHERE `ss_schedule_id`=@scheduleId;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@scheduleStatus", MySqlDbType.VarChar).Value = scheduleStatus;
                        mySqlCommand.Parameters.Add("@scheduleId", MySqlDbType.VarChar).Value = scheduleId;

                        mySqlCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
                catch (Exception)
                {
                    throw new MSSMUIException("Failed to change Schedule Status", "ERRORCODE");
                }
            }
        }

        //get order items by shipping schedule id
        public List<OrderItem> getOrderItems (String scheuleId)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `orderitem` oi LEFT JOIN `order` o ON oi.order_no = o.order_no LEFT JOIN `contractschedule` cs ON cs.contract_no= oi.contract_no LEFT JOIN `shippingschedule` ss ON ss.ss_schedule_id = cs.schedule_id LEFT JOIN `shippingdetails` sd ON sd.shipping_address_id = oi.address_id LEFT JOIN `orderitemcontents` oic ON oic.barcode = oi.barcode LEFT JOIN `brand` br ON oic.brand_id = br.brand_id LEFT JOIN `buyer` byr ON byr.buyer_id = br.buyer_id LEFT JOIN `teaproduct` tp ON tp.teaproduct_id = oic.teaproduct_id LEFT JOIN (SELECT `fg_orderitem_no`, COUNT(*) AS `fg_count` FROM `finishedgoods` GROUP BY `fg_orderitem_no`) fgc ON fgc.fg_orderitem_no = oi.orderitem_no LEFT JOIN (SELECT `fg_orderitem_no`, `fg_status`, COUNT(*) AS `sg_count` FROM `finishedgoods` WHERE `fg_status` = 'In Storage' GROUP BY `fg_orderitem_no`, `fg_status`) sgc ON sgc.fg_orderitem_no = oi.orderitem_no LEFT JOIN (SELECT `fg_orderitem_no`, `fg_status`, COUNT(*) AS `lg_count` FROM `finishedgoods` WHERE `fg_status` = 'Loaded' GROUP BY `fg_orderitem_no`, `fg_status`) lgc ON lgc.fg_orderitem_no = oi.orderitem_no WHERE (ss.ss_schedule_id is null OR  ss.ss_schedule_id = @scheduleId);";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@scheduleId", MySqlDbType.VarChar).Value = scheuleId;

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                //buyer
                                String buyerId = mySqlDataReader.GetString("buyer_id");
                                String buyerName = mySqlDataReader.GetString("buyer_name");

                                Buyer buyer = new Buyer(buyerId, buyerName, "", "");

                                //brand
                                String brandId = mySqlDataReader.GetString("brand_id");
                                String brandName = mySqlDataReader.GetString("brand_name");

                                Brand brand = new Brand("", "", brandId, brandName, "");

                                //tea product
                                String teaproductId = mySqlDataReader.GetString("teaproduct_id");
                                String teaproductSerialNo = mySqlDataReader.GetString("teaproduct_serial_no");
                                String teaproductName = mySqlDataReader.GetString("teaproduct_name");
                                String teaproductFlavor = mySqlDataReader.GetString("teaproduct_flavor");

                                TeaProduct teaProduct = new TeaProduct(teaproductId, teaproductName, teaproductFlavor, teaproductSerialNo, "", "");

                                //orderitemcontents
                                String barcode = mySqlDataReader.GetString("barcode");
                                int icQuantity = mySqlDataReader.GetInt32("ic_qantity");
                                int tbQuantity = mySqlDataReader.GetInt32("teabag_quantity");
                                Decimal tbWeight = mySqlDataReader.GetDecimal("teabag_weight");
                                Decimal mcMinWeight = mySqlDataReader.GetDecimal("mc_min_weight");
                                Decimal mcMaxWeight = mySqlDataReader.GetDecimal("mc_max_weight");

                                OrderItemContent orderItemContent = new OrderItemContent("", "", "", "", barcode, teaProduct, null, icQuantity, tbQuantity, tbWeight, mcMinWeight, mcMaxWeight, "", -1);

                                //shipping details
                                String shipping_address_id = mySqlDataReader.GetString("shipping_address_id");
                                String shipping_location = mySqlDataReader.GetString("shipping_location");
                                String shipping_address = mySqlDataReader.GetString("shipping_address");

                                ShippingDetails shippingDetail = new ShippingDetails(shipping_address_id, shipping_location, shipping_address, "");

                                //Shipping Schedule
                                String schedule_id = mySqlDataReader.IsDBNull(21) ? "N/A" : mySqlDataReader.GetString("ss_schedule_id");
                                DateTime loading_date = mySqlDataReader.IsDBNull(23) ? DateTime.MinValue : mySqlDataReader.GetDateTime("ss_loading_date");

                                ShippingSchedule shippingSchedule = new ShippingSchedule(schedule_id, loading_date, DateTime.MinValue);

                                //order
                                String order_no = mySqlDataReader.GetString("order_no");
                                DateTime order_placement_date = mySqlDataReader.GetDateTime("order_placement_date");
                                String order_status = mySqlDataReader.GetString("order_status");

                                Order order = new Order(order_no, null, order_placement_date, order_status);

                                //orderitem stats
                                int finished_mc_quantity = mySqlDataReader.IsDBNull(62) ? 0 : mySqlDataReader.GetInt32("fg_count");
                                int stored_mc_quantity = mySqlDataReader.IsDBNull(65) ? 0 : mySqlDataReader.GetInt32("sg_count");
                                int loaded_mc_quantity = mySqlDataReader.IsDBNull(68) ? 0 : mySqlDataReader.GetInt32("lg_count");

                                //orderitem
                                String orderitem_no = mySqlDataReader.GetString("orderitem_no");
                                String contract_no = mySqlDataReader.IsDBNull(1) ? "N/A" : mySqlDataReader.GetString("contract_no");
                                String order_placed_by = mySqlDataReader.GetString("productionmanager_id");
                                DateTime orderitem_placement_date = mySqlDataReader.GetDateTime("orderitem_placement_date");
                                String productionplan_id = mySqlDataReader.IsDBNull(7) ? "N/A" : mySqlDataReader.GetString("productionplan_id");
                                int mc_quantity = mySqlDataReader.GetInt32("mc_quantity");
                                int mc_end = mySqlDataReader.GetInt32("mc_end");
                                int mc_start = mySqlDataReader.GetInt32("mc_start");
                                String orderitem_status = mySqlDataReader.GetString("orderitem_status");
                                DateTime orderitem_production_startdate = mySqlDataReader.IsDBNull(12) ? DateTime.MinValue : mySqlDataReader.GetDateTime("orderitem_production_startdate");
                                DateTime orderitem_production_enddate = mySqlDataReader.IsDBNull(13) ? DateTime.MinValue : mySqlDataReader.GetDateTime("orderitem_production_enddate");

                                OrderItem orderItem = new OrderItem(buyer, brand, teaProduct, orderItemContent, shippingDetail, order, orderitem_no, contract_no, order_placed_by, orderitem_placement_date, productionplan_id, mc_quantity, mc_start, mc_end, orderitem_status, orderitem_production_startdate, orderitem_production_enddate);
                                orderItem.shippingSchedule = shippingSchedule;
                                orderItem.mc_count = finished_mc_quantity;
                                orderItem.stored_mc_count = stored_mc_quantity;
                                orderItem.loaded_mc_count = loaded_mc_quantity;

                                orderItems.Add(orderItem);
                            }

                            return orderItems;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to fetch Order Items. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //get shipping contracts
        public List<Contract> getAllContracts()
        {
            List<Contract> contracts = new List<Contract>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `contract`";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String contract_no = mySqlDataReader.GetString("contract_no");
                                DateTime contract_placement_date = mySqlDataReader.GetDateTime("contract_placement_date");
                                String contract_status = mySqlDataReader.GetString("contract_status");

                                Contract contract = new Contract(contract_no, contract_placement_date, contract_status);
                                contracts.Add(contract);
                            }

                            return contracts;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Utilities.MSSMUIException("Failed to fetch Contracts " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }
    }
}
