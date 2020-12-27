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
    public class FinishedGoodsDBHandler:DBHandler
    {
        //add M/C
        public Boolean addMasterCarton(FinishedGood finishedGood)
        {
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `finishedgoods`(`fg_orderitem_no`, `fg_mc_no`, `fg_location_id`, `fg_added_by`, `fg_added_date`, `fg_mc_weight`, `fg_exp_date`, `fg_status`, `fg_remarks`) VALUES (@orderItemNo, @mcNo, @locationId, @addedBy, @addedDate, @mcWeight, @expDate, @status, @remarks);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = finishedGood.fg_orderitem_no;
                        mySqlCommand.Parameters.Add("@mcNo", MySqlDbType.VarChar).Value = finishedGood.fg_mc_no;
                        mySqlCommand.Parameters.Add("@locationId", MySqlDbType.VarChar).Value = finishedGood.fg_location_id;
                        mySqlCommand.Parameters.Add("@addedBy", MySqlDbType.VarChar).Value = finishedGood.fg_added_by;
                        mySqlCommand.Parameters.Add("@addedDate", MySqlDbType.DateTime).Value = finishedGood.fg_added_date;
                        mySqlCommand.Parameters.Add("@mcWeight", MySqlDbType.VarChar).Value = finishedGood.fg_mc_weight;
                        mySqlCommand.Parameters.Add("@expDate", MySqlDbType.DateTime).Value = finishedGood.fg_exp_date;
                        mySqlCommand.Parameters.Add("@status", MySqlDbType.VarChar).Value = finishedGood.fg_status;
                        mySqlCommand.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = finishedGood.fg_remarks;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    //change order item status to completed if mc no = max mc number
                    if (int.Parse(finishedGood.fg_mc_no) == finishedGood.totalMCQuantity)
                    {
                        using (MySqlCommand mySqlCommand = new MySqlCommand())
                        {
                            mySqlCommand.CommandText = "UPDATE `orderitem` SET `orderitem_status`='Completed' WHERE `orderitem_no`=@orderItemNo;";
                            mySqlCommand.CommandType = CommandType.Text;
                            mySqlCommand.Connection = connection;

                            mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = finishedGood.fg_orderitem_no;
                            mySqlCommand.Prepare();

                            mySqlCommand.ExecuteNonQuery();
                        }

                        //check if all orderitems has been completed and set order status to comleted
                        int allOrderItemCountOfSameOrder = 0;
                        int completedOrderItemCountOfSameOrder = 0;

                        using (MySqlCommand mySqlCommand = new MySqlCommand())
                        {
                            mySqlCommand.CommandText = "SELECT * FROM `orderitem` WHERE `order_no`=@orderNo ;";
                            mySqlCommand.CommandType = CommandType.Text;
                            mySqlCommand.Connection = connection;

                            mySqlCommand.Parameters.Add("@orderNo", MySqlDbType.VarChar).Value = finishedGood.orderNo;
                            mySqlCommand.Prepare();

                            using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                            {
                                while (mySqlDataReader.Read())
                                {
                                    String orderitem_no = mySqlDataReader.GetString("orderitem_no");
                                    String orderitem_status = mySqlDataReader.GetString("orderitem_status");

                                    allOrderItemCountOfSameOrder++;

                                    if(orderitem_status == "Completed")
                                    {
                                        completedOrderItemCountOfSameOrder++;
                                    }
                                }
                            }
                        }

                        if (allOrderItemCountOfSameOrder == completedOrderItemCountOfSameOrder)
                        {
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "UPDATE `order` SET `order_status`='Completed' WHERE `order_no`=@orderNo;";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@orderNo", MySqlDbType.VarChar).Value = finishedGood.orderNo;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                        }


                        //check if all orderitems with same production plan id has been completed and set the plan status to completed
                        int allOrderItemCountOfSamePlan = 0;
                        int completedOrderItemCountOfSamePlan = 0;
                        using (MySqlCommand mySqlCommand = new MySqlCommand())
                        {
                            mySqlCommand.CommandText = "SELECT * FROM `orderitem` WHERE `productionplan_id`=@planId;";
                            mySqlCommand.CommandType = CommandType.Text;
                            mySqlCommand.Connection = connection;

                            mySqlCommand.Parameters.Add("@planId", MySqlDbType.VarChar).Value = finishedGood.productionPlanId;
                            mySqlCommand.Prepare();

                            using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                            {
                                while (mySqlDataReader.Read())
                                {
                                    String orderitem_no = mySqlDataReader.GetString("orderitem_no");
                                    String orderitem_status = mySqlDataReader.GetString("orderitem_status");

                                    allOrderItemCountOfSamePlan++;

                                    if (orderitem_status == "Completed")
                                    {
                                        completedOrderItemCountOfSamePlan++;
                                    }
                                }
                            }
                        }

                        if (allOrderItemCountOfSamePlan == completedOrderItemCountOfSamePlan)
                        {
                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "UPDATE `productionplan` SET `productionplan_status`='Completed' WHERE `productionplan_id`=@planId;";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@planId", MySqlDbType.VarChar).Value = finishedGood.productionPlanId;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                        }

                    }
                    connection.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw new MSSMUIException("Failed to add Master Carton Details " + e.Message, "ERRORCODE");
                }
            }
        }

        //update MC
        public Boolean updateMasterCarton(FinishedGood finishedGood)
        {
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `finishedgoods` SET `fg_location_id`=@locationId, `fg_added_by`=@addedBy, `fg_added_date`=@addedDate, `fg_mc_weight`=@mcWeight, `fg_exp_date`=@expDate, `fg_status`=@status, `fg_remarks`=@remarks WHERE `fg_orderitem_no`=@orderItemNo AND `fg_mc_no`=@mcNo;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = finishedGood.fg_orderitem_no;
                        mySqlCommand.Parameters.Add("@mcNo", MySqlDbType.VarChar).Value = finishedGood.fg_mc_no;
                        mySqlCommand.Parameters.Add("@locationId", MySqlDbType.VarChar).Value = finishedGood.fg_location_id;
                        mySqlCommand.Parameters.Add("@addedBy", MySqlDbType.VarChar).Value = finishedGood.fg_added_by;
                        mySqlCommand.Parameters.Add("@addedDate", MySqlDbType.DateTime).Value = finishedGood.fg_added_date;
                        mySqlCommand.Parameters.Add("@mcWeight", MySqlDbType.VarChar).Value = finishedGood.fg_mc_weight;
                        mySqlCommand.Parameters.Add("@expDate", MySqlDbType.DateTime).Value = finishedGood.fg_exp_date;
                        mySqlCommand.Parameters.Add("@status", MySqlDbType.VarChar).Value = finishedGood.fg_status;
                        mySqlCommand.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = finishedGood.fg_remarks;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw new MSSMUIException("Failed to update Master Carton Details " + e.Message, "ERRORCODE");
                }
            }
        }

        //delete MC
        public Boolean deleteMasterCarton(int mcNo, String orderItemNo, FinishedGood finishedGood)
        {
            using (connection)
            {
                try
                {
                    connection.Open();
                    
                    //deleting the selected MC
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "DELETE FROM `finishedgoods` WHERE `fg_orderitem_no`=@orderItemNo AND `fg_mc_no`=@mcNo;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = orderItemNo;
                        mySqlCommand.Parameters.Add("@mcNo", MySqlDbType.Int32).Value = mcNo;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    //it is necessary to re-order MCs if there are more MCs after the deleted MC
                    List<int> mcList = new List<int>();

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT `fg_mc_no` FROM `finishedgoods` WHERE `fg_mc_no` > @mcNo AND `fg_orderitem_no`=@orderItemNo ORDER BY `fg_mc_no` ASC;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@mcNo", MySqlDbType.Int32).Value = mcNo;
                        mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = orderItemNo;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                int fg_mc_no = mySqlDataReader.GetInt32("fg_mc_no");
                                mcList.Add(fg_mc_no);
                            }
                        }
                    }

                    //update the selected mcList in order to re-order the MCs of the selected order item
                    if (mcList.Count > 0)
                    {
                        foreach (int mc in mcList)
                        {
                            int newMCNo = mc - 1;

                            using (MySqlCommand mySqlCommand = new MySqlCommand())
                            {
                                mySqlCommand.CommandText = "UPDATE `finishedgoods` SET `fg_mc_no`=@newMCNo WHERE `fg_orderitem_no`=@orderItemNo AND `fg_mc_no`=@mcNo;";
                                mySqlCommand.CommandType = CommandType.Text;
                                mySqlCommand.Connection = connection;

                                mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = orderItemNo;
                                mySqlCommand.Parameters.Add("@mcNo", MySqlDbType.Int32).Value = mc;
                                mySqlCommand.Parameters.Add("@newMCNo", MySqlDbType.Int32).Value = newMCNo;
                                mySqlCommand.Prepare();

                                mySqlCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    //check if the orderitem was completed before, deleting the MC
                    //if the orderitem was completed, we have to reset the orderitem status 
                    //after checking the production plan status
                    String productionplan_id = null;
                    String productionplan_status = null;
                    DateTime productionplan_end_date = DateTime.MinValue;
                    String orderitem_status = null;
                    DateTime orderitem_production_startdate = DateTime.MinValue;
                    DateTime orderitem_production_enddate = DateTime.MinValue;
                    String order_no = null;
                    String order_status = null;
                    int mc_count = 0;

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT oi.`orderitem_no`, oi.`orderitem_status`, pp.`productionplan_id`, pp.`productionplan_status`, pp.`productionplan_end_date`, oi.`orderitem_production_startdate`, oi.`orderitem_production_enddate`, o.`order_no`, o.`order_status`, fgc.`mc_count` FROM `orderitem` oi LEFT JOIN `productionplan` pp ON oi.productionplan_id = pp.productionplan_id LEFT JOIN `order` o ON o.order_no = oi.order_no LEFT JOIN (SELECT `fg_orderitem_no`, COUNT(*) AS `mc_count` FROM `finishedgoods` GROUP BY `fg_orderitem_no`) fgc ON fgc.fg_orderitem_no = oi.orderitem_no WHERE oi.orderitem_no=@orderItemNo;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = orderItemNo;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                productionplan_id = mySqlDataReader.IsDBNull(2) ? null : mySqlDataReader.GetString("productionplan_id");
                                productionplan_status = mySqlDataReader.IsDBNull(3) ? null : mySqlDataReader.GetString("productionplan_status");
                                productionplan_end_date = mySqlDataReader.IsDBNull(4) ? DateTime.MinValue : mySqlDataReader.GetDateTime("productionplan_end_date");
                                orderitem_production_startdate = mySqlDataReader.IsDBNull(5) ? DateTime.MinValue : mySqlDataReader.GetDateTime("orderitem_production_startdate");
                                orderitem_production_enddate = mySqlDataReader.IsDBNull(6) ? DateTime.MinValue : mySqlDataReader.GetDateTime("orderitem_production_enddate");
                                orderitem_status = mySqlDataReader.GetString("orderitem_status");
                                order_no = mySqlDataReader.GetString("order_no");
                                order_status = mySqlDataReader.GetString("order_status");
                                mc_count = mySqlDataReader.IsDBNull(9) ? 0 : mySqlDataReader.GetInt32("mc_count");
                            }
                        }
                    }

                    //determining order item status
                    String newOrderItemStatus = null;
                    String newPlanId = null;
                    DateTime newStartDate = DateTime.MinValue;
                    DateTime newEndDate = DateTime.MinValue;

                    if(orderitem_status == "Completed")
                    {
                        if (productionplan_status != null)
                        {
                            if (productionplan_status == "Pending")
                            {
                                newOrderItemStatus = "Pending";
                                newPlanId = productionplan_id;
                                newStartDate = orderitem_production_startdate;
                                newEndDate = orderitem_production_enddate;
                            }
                            else if (productionplan_status == "In Production")
                            {
                                newOrderItemStatus = "In Production";
                                newPlanId = productionplan_id;
                                newStartDate = orderitem_production_startdate;
                                newEndDate = orderitem_production_enddate;
                            }
                            else if(productionplan_status == "Completed")
                            {
                                newOrderItemStatus = "Pending";
                                newPlanId = null;
                                newStartDate = DateTime.MinValue;
                                newEndDate = DateTime.MinValue;
                            }
                        }
                        else
                        {
                            newOrderItemStatus = "Pending";
                            newPlanId = null;
                            newStartDate = DateTime.MinValue;
                            newEndDate = DateTime.MinValue;
                        }
                    }
                    else if(orderitem_status == "In Production")
                    {
                        //has a production plan
                        //plan is in production
                        newOrderItemStatus = null;
                    }
                    else if(orderitem_status == "Pending")
                    {
                        if (productionplan_status != null)
                        {
                            //either no plan
                            //or plan is pending
                            //no changes
                        }
                        newOrderItemStatus = null;
                    }

                    //updating order item status
                    if (newOrderItemStatus != null)
                    {
                        using (MySqlCommand mySqlCommand = new MySqlCommand())
                        {
                            mySqlCommand.CommandText = "UPDATE `orderitem` SET `orderitem_status`=@newOrderItemStatus, `productionplan_id`=@newPlanId, `orderitem_production_startdate`=@newStartDate, `orderitem_production_enddate`=@newEndDate WHERE `orderitem_no`=@orderItemNo;";
                            mySqlCommand.CommandType = CommandType.Text;
                            mySqlCommand.Connection = connection;

                            mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = orderItemNo;
                            mySqlCommand.Parameters.Add("@newOrderItemStatus", MySqlDbType.VarChar).Value = newOrderItemStatus;
                            mySqlCommand.Parameters.Add("@newPlanId", MySqlDbType.VarChar).Value = newPlanId;
                            mySqlCommand.Parameters.Add("@newStartDate", MySqlDbType.DateTime).Value = newStartDate;
                            mySqlCommand.Parameters.Add("@newEndDate", MySqlDbType.DateTime).Value = newEndDate;
                            mySqlCommand.Prepare();

                            mySqlCommand.ExecuteNonQuery();
                        }
                    }

                    //check if all orderitems has been completed and set order status to comleted
                    int allOrderItemCountOfSameOrder = 0;
                    int completedOrderItemCountOfSameOrder = 0;
                    int ongoingOrderItemCountOfSameOrder = 0;
                    int pendingOrderItemCountOfSameOrder = 0;

                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "SELECT * FROM `orderitem` WHERE `order_no`=@orderNo;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@orderNo", MySqlDbType.VarChar).Value = finishedGood.orderItem.order.order_no;
                        mySqlCommand.Prepare();

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String oi_no = mySqlDataReader.GetString("orderitem_no");
                                String oi_status = mySqlDataReader.GetString("orderitem_status");

                                allOrderItemCountOfSameOrder++;

                                if (oi_status == "Completed")
                                {
                                    completedOrderItemCountOfSameOrder++;
                                } 
                                else if (oi_status == "Pending")
                                {
                                    pendingOrderItemCountOfSameOrder++;
                                }
                                else if (oi_status == "In Production")
                                {
                                    ongoingOrderItemCountOfSameOrder++;
                                }
                            }
                        }
                    }
                    
                    String newOrderStatus = null;

                    if (allOrderItemCountOfSameOrder == completedOrderItemCountOfSameOrder)
                    {
                        newOrderStatus = "Completed";
                    }
                    else if (ongoingOrderItemCountOfSameOrder > 0 || ongoingOrderItemCountOfSameOrder == allOrderItemCountOfSameOrder || (ongoingOrderItemCountOfSameOrder > 0 && completedOrderItemCountOfSameOrder > 0) || (ongoingOrderItemCountOfSameOrder > 0 && pendingOrderItemCountOfSameOrder > 0) || (completedOrderItemCountOfSameOrder > 0 && pendingOrderItemCountOfSameOrder > 0))
                    {
                        newOrderStatus = "In Production";
                    }
                    else if (pendingOrderItemCountOfSameOrder == allOrderItemCountOfSameOrder)
                    {
                        newOrderStatus = "Pending";
                    }

                    //updating order status
                    if (newOrderStatus != null)
                    {
                        using (MySqlCommand mySqlCommand = new MySqlCommand())
                        {
                            mySqlCommand.CommandText = "UPDATE `order` SET `order_status`=@newStatus WHERE `order_no`=@orderNo;";
                            mySqlCommand.CommandType = CommandType.Text;
                            mySqlCommand.Connection = connection;

                            mySqlCommand.Parameters.Add("@orderNo", MySqlDbType.VarChar).Value = finishedGood.orderItem.order.order_no;
                            mySqlCommand.Parameters.Add("@newStatus", MySqlDbType.VarChar).Value = newOrderStatus;
                            mySqlCommand.Prepare();

                            mySqlCommand.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw new MSSMUIException("Failed to delete the selected Master Carton " + e.Message, "ERRORCODE");
                }
            }
        }

        //get all completed MCs
        public List<FinishedGood> getAllCompletedMasterCartos()
        {
            List<FinishedGood> finishedGoods = new List<FinishedGood>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `finishedgoods` fg LEFT JOIN `location` ln ON ln.location_id = fg.fg_location_id LEFT JOIN `orderitem` oi ON fg.fg_orderitem_no = oi.orderitem_no LEFT JOIN `order` o ON o.order_no=oi.order_no LEFT JOIN `orderitemcontents` oic ON oi.barcode = oic.barcode LEFT JOIN `brand` b ON b.brand_id = oic.brand_id LEFT JOIN `buyer` byr ON byr.buyer_id = b.buyer_id LEFT JOIN `teaproduct` tp ON tp.teaproduct_id = oic.teaproduct_id LEFT JOIN `teabagmaterial` tbm ON tbm.teabagmaterial_id=oic.teabagmaterial_id LEFT JOIN `contractschedule` cs ON cs.contract_no=oi.contract_no LEFT JOIN `shippingschedule` ss ON ss.ss_schedule_id=cs.schedule_id LEFT JOIN `shippingdetails` sd ON sd.shipping_address_id = oi.address_id LEFT JOIN (SELECT `fg_orderitem_no`, COUNT(*) AS `fg_orderitem_mc_count` FROM `finishedgoods` GROUP BY `fg_orderitem_no`) fgc ON fgc.fg_orderitem_no = oi.orderitem_no ORDER BY fg.fg_added_date DESC;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;
                    mySqlCommand.Prepare();

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

                                //teabag material
                                String teabagmaterial_id = mySqlDataReader.GetString("teabagmaterial_id");
                                String teabag_name = mySqlDataReader.GetString("teabag_name");
                                String teabag_type = mySqlDataReader.GetString("teabag_type");
                                String teabag_serialno = mySqlDataReader.GetString("teabag_serial_no");

                                TeabagMaterial teabagMaterial = new TeabagMaterial(teabagmaterial_id, teabag_name, teabag_type, teabag_serialno, "", "");

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


                                //order
                                String order_no = mySqlDataReader.GetString("order_no");
                                DateTime order_placement_date = mySqlDataReader.GetDateTime("order_placement_date");
                                String order_status = mySqlDataReader.GetString("order_status");

                                Order order = new Order(order_no, null, order_placement_date, order_status);

                                //shipping schedule
                                String shippingschedule_id = mySqlDataReader.IsDBNull(64) ? "N/A" : mySqlDataReader.GetString("ss_schedule_id");
                                DateTime shipping_date = mySqlDataReader.IsDBNull(65) ? DateTime.MinValue : mySqlDataReader.GetDateTime("ss_shipping_date");
                                DateTime loading_date = mySqlDataReader.IsDBNull(66) ? DateTime.MinValue : mySqlDataReader.GetDateTime("ss_loading_date");

                                ShippingSchedule shippingSchedule = new ShippingSchedule(shippingschedule_id, shipping_date, loading_date);

                                //location
                                String location_id = mySqlDataReader.GetString("location_id");
                                String location_name = mySqlDataReader.GetString("location_name");
                                String location_desc = mySqlDataReader.IsDBNull(14) ? "N/A" : mySqlDataReader.GetString("location_description");

                                Location location = new Location(location_id, location_name, location_desc);

                                //order item
                                String orderitem_no = mySqlDataReader.GetString("orderitem_no");
                                String contract_no = mySqlDataReader.IsDBNull(13) ? "N/A" : mySqlDataReader.GetString("contract_no");
                                String order_placed_by = mySqlDataReader.GetString("productionmanager_id");
                                DateTime orderitem_placement_date = mySqlDataReader.GetDateTime("orderitem_placement_date");
                                String productionplan_id = mySqlDataReader.IsDBNull(19) ? "N/A" : mySqlDataReader.GetString("productionplan_id");
                                int mc_quantity = mySqlDataReader.GetInt32("mc_quantity");
                                int mc_end = mySqlDataReader.GetInt32("mc_end");
                                int mc_start = mySqlDataReader.GetInt32("mc_start");
                                String orderitem_status = mySqlDataReader.GetString("orderitem_status");
                                DateTime orderitem_production_startdate = mySqlDataReader.IsDBNull(24) ? DateTime.MinValue : mySqlDataReader.GetDateTime("orderitem_production_startdate");
                                DateTime orderitem_production_enddate = mySqlDataReader.IsDBNull(25) ? DateTime.MinValue : mySqlDataReader.GetDateTime("orderitem_production_enddate");
                                int orderitem_mc_count = mySqlDataReader.IsDBNull(80) ? 0 : mySqlDataReader.GetInt32("fg_orderitem_mc_count");

                                OrderItem orderItem = new OrderItem(buyer, brand, teaProduct, orderItemContent, shippingDetail, order, orderitem_no, contract_no, order_placed_by, orderitem_placement_date, productionplan_id, mc_quantity, mc_start, mc_end, orderitem_status, orderitem_production_startdate, orderitem_production_enddate);
                                orderItem.shippingSchedule = shippingSchedule;
                                orderItem.teabagMaterial = teabagMaterial;
                                orderItem.mc_count = orderitem_mc_count;
                                orderItem.location = location;

                                //finished good
                                String fg_oi_no = mySqlDataReader.GetString("fg_orderitem_no");
                                String fg_mc_no = mySqlDataReader.GetString("fg_mc_no");
                                String fg_ln_id = mySqlDataReader.GetString("fg_location_id");
                                String fg_added_by = mySqlDataReader.GetString("fg_added_by");
                                DateTime fg_added_date = mySqlDataReader.GetDateTime("fg_added_date");
                                Decimal fg_mc_weight = mySqlDataReader.GetDecimal("fg_mc_weight");
                                DateTime fg_exp_date = mySqlDataReader.GetDateTime("fg_exp_date");
                                String fg_status = mySqlDataReader.GetString("fg_status");
                                String fg_remarks = mySqlDataReader.IsDBNull(8) ? "N/A" : mySqlDataReader.GetString("fg_remarks");

                                FinishedGood finishedGood = new FinishedGood(fg_oi_no, fg_mc_no, fg_ln_id, fg_added_by, fg_added_date, fg_mc_weight, fg_exp_date, fg_status, fg_remarks);
                                finishedGood.orderItem = orderItem;

                                finishedGoods.Add(finishedGood);
                            }

                            return finishedGoods;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to fetch Master Carton Details. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //get on-going order item details
        public List<OrderItem> getAllOnGoingOrderItems()
        {
            List<OrderItem> onGoingOrderItems = new List<OrderItem>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `orderitem` oi LEFT JOIN `order` o ON o.order_no=oi.order_no LEFT JOIN `orderitemcontents` oic ON oi.barcode = oic.barcode LEFT JOIN `brand` b ON b.brand_id = oic.brand_id LEFT JOIN `buyer` byr ON byr.buyer_id = b.buyer_id LEFT JOIN `teaproduct` tp ON tp.teaproduct_id = oic.teaproduct_id LEFT JOIN `teabagmaterial` tbm ON tbm.teabagmaterial_id=oic.teabagmaterial_id LEFT JOIN `contractschedule` cs ON cs.contract_no=oi.contract_no LEFT JOIN `shippingschedule` ss ON ss.ss_schedule_id=cs.schedule_id LEFT JOIN `shippingdetails` sd ON sd.shipping_address_id = oi.address_id LEFT JOIN (SELECT `fg_orderitem_no`, COUNT(*) AS `fg_orderitem_mc_count` FROM `finishedgoods` GROUP BY `fg_orderitem_no`) fg ON fg.fg_orderitem_no = oi.orderitem_no WHERE oi.orderitem_status='In Production';";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;
                    mySqlCommand.Prepare();

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

                                //teabag material
                                String teabagmaterial_id = mySqlDataReader.GetString("teabagmaterial_id");
                                String teabag_name = mySqlDataReader.GetString("teabag_name");
                                String teabag_type = mySqlDataReader.GetString("teabag_type");
                                String teabag_serialno = mySqlDataReader.GetString("teabag_serial_no");

                                TeabagMaterial teabagMaterial = new TeabagMaterial(teabagmaterial_id,teabag_name, teabag_type, teabag_serialno, "", "");

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


                                //order
                                String order_no = mySqlDataReader.GetString("order_no");
                                DateTime order_placement_date = mySqlDataReader.GetDateTime("order_placement_date");
                                String order_status = mySqlDataReader.GetString("order_status");

                                Order order = new Order(order_no, null, order_placement_date, order_status);

                                //shipping schedule
                                String shippingschedule_id = mySqlDataReader.IsDBNull(52) ? "N/A" : mySqlDataReader.GetString("ss_schedule_id");
                                DateTime shipping_date = mySqlDataReader.IsDBNull(53) ? DateTime.MinValue : mySqlDataReader.GetDateTime("ss_shipping_date");
                                DateTime loading_date = mySqlDataReader.IsDBNull(54) ? DateTime.MinValue : mySqlDataReader.GetDateTime("ss_loading_date");

                                ShippingSchedule shippingSchedule = new ShippingSchedule(shippingschedule_id, shipping_date, loading_date);

                                //order item
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
                                int orderitem_mc_count = mySqlDataReader.IsDBNull(68) ? 0 : mySqlDataReader.GetInt32("fg_orderitem_mc_count");

                                OrderItem orderItem = new OrderItem(buyer, brand, teaProduct, orderItemContent, shippingDetail, order, orderitem_no, contract_no, order_placed_by, orderitem_placement_date, productionplan_id, mc_quantity, mc_start, mc_end, orderitem_status, orderitem_production_startdate, orderitem_production_enddate);
                                orderItem.shippingSchedule = shippingSchedule;
                                orderItem.teabagMaterial = teabagMaterial;
                                orderItem.mc_count = orderitem_mc_count;

                                onGoingOrderItems.Add(orderItem);
                            }

                            return onGoingOrderItems;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to fetch Ongoing Order Items. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //get location-data
        public List<Location> getAllLocations()
        {
            List<Location> locations = new List<Location>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `location`;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;
                    mySqlCommand.Prepare();

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
                        throw new MSSMUIException("Failed to fetch all Locations. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }
    }
}
