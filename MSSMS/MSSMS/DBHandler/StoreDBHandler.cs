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
    public class StoreDBHandler:DBHandler
    {
        //add MC to storage
        public Boolean addMCToStorage(StoredGood storedGood)
        {
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "INSERT INTO `storedgoods`(`sg_orderitem_no`, `sg_mc_no`, `sg_stored_by`, `sg_stored_date`, `sg_issued_by`, `sg_issued_date`, `sg_remarks`) VALUES (@orderItemNo, @mcNo, @storedBy, @storedDate, @issuedBy, @issuedDate, @remarks);";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = storedGood.sg_orderitem_no;
                        mySqlCommand.Parameters.Add("@mcNo", MySqlDbType.VarChar).Value = storedGood.sg_mc_no;
                        mySqlCommand.Parameters.Add("@storedBy", MySqlDbType.VarChar).Value = storedGood.sg_stored_by;
                        mySqlCommand.Parameters.Add("@storedDate", MySqlDbType.DateTime).Value = storedGood.sg_stored_date;
                        mySqlCommand.Parameters.Add("@issuedBy", MySqlDbType.VarChar).Value = storedGood.sg_issued_by;
                        mySqlCommand.Parameters.Add("@issuedDate", MySqlDbType.DateTime).Value = storedGood.sg_issued_date;
                        mySqlCommand.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = storedGood.sg_remarks;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    //change fg status to "In Storage"
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `finishedgoods` SET `fg_status`=@status, `fg_location_id`=@locationId  WHERE `fg_orderitem_no`=@orderItemNo AND `fg_mc_no`=@mcNo;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = storedGood.sg_orderitem_no;
                        mySqlCommand.Parameters.Add("@mcNo", MySqlDbType.VarChar).Value = storedGood.sg_mc_no;
                        mySqlCommand.Parameters.Add("@locationId", MySqlDbType.VarChar).Value = storedGood.sg_location_id;
                        mySqlCommand.Parameters.Add("@status", MySqlDbType.VarChar).Value = storedGood.sg_status;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }
                    connection.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw new MSSMUIException("Failed to add Master Carton to the Storage. " + e.Message, "ERRORCODE");
                }
            }
        }

        //update stored MC
        public Boolean updateStoredMasterCarton(StoredGood storedGood)
        {
            using (connection)
            {
                try
                {
                    connection.Open();
                    //change fg status to "In Storage"
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `finishedgoods` SET `fg_location_id`=@locationId  WHERE `fg_orderitem_no`=@orderItemNo AND `fg_mc_no`=@mcNo;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = storedGood.sg_orderitem_no;
                        mySqlCommand.Parameters.Add("@mcNo", MySqlDbType.VarChar).Value = storedGood.sg_mc_no;
                        mySqlCommand.Parameters.Add("@locationId", MySqlDbType.VarChar).Value = storedGood.sg_location_id;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }
                    connection.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw new MSSMUIException("Failed to update Master Carton Details. " + e.Message, "ERRORCODE");
                }
            }
        }

        //delete stored MC
        public Boolean deleteMasterCartonFromStorage(int mcNo, String orderItemNo, StoredGood storedGood)
        {
            using (connection)
            {
                try
                {
                    connection.Open();

                    //deleting the selected MC
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "DELETE FROM `storedgoods` WHERE `sg_orderitem_no`=@orderItemNo AND `sg_mc_no`=@mcNo;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = orderItemNo;
                        mySqlCommand.Parameters.Add("@mcNo", MySqlDbType.Int32).Value = mcNo;
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }

                    //updating the finished goods table status back to "Completed"
                    using (MySqlCommand mySqlCommand = new MySqlCommand())
                    {
                        mySqlCommand.CommandText = "UPDATE `finishedgoods` SET `fg_status`=@newStatus, `fg_remarks`=@newRemarks WHERE `fg_orderitem_no`=@orderItemNo AND `fg_mc_no`=@mcNo;";
                        mySqlCommand.CommandType = CommandType.Text;
                        mySqlCommand.Connection = connection;

                        mySqlCommand.Parameters.Add("@orderItemNo", MySqlDbType.VarChar).Value = orderItemNo;
                        mySqlCommand.Parameters.Add("@mcNo", MySqlDbType.Int32).Value = mcNo;
                        mySqlCommand.Parameters.Add("@newStatus", MySqlDbType.VarChar).Value = "Completed";
                        mySqlCommand.Parameters.Add("@newRemarks", MySqlDbType.VarChar).Value = storedGood.finishedGood.fg_remarks + "\n [Log: This MC has been deleted from the storage by " + SessionManager.user.employeeId + " on " + DateTime.Now + ".";
                        mySqlCommand.Prepare();

                        mySqlCommand.ExecuteNonQuery();
                    }
                    connection.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw new MSSMUIException("Failed to delete the selected Master Carton from Storage" + e.Message, "ERRORCODE");
                }
            }
        }

        //get all stored MCs
        public List<StoredGood> getAllStoredMasterCartons()
        {
            List<StoredGood> storedGoods = new List<StoredGood>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `storedgoods` stg LEFT JOIN `finishedgoods` fg ON (stg.sg_orderitem_no = fg.fg_orderitem_no AND stg.sg_mc_no=fg.fg_mc_no) LEFT JOIN `location` ln ON ln.location_id = fg.fg_location_id LEFT JOIN `orderitem` oi ON fg.fg_orderitem_no = oi.orderitem_no LEFT JOIN `order` o ON o.order_no=oi.order_no LEFT JOIN `orderitemcontents` oic ON oi.barcode = oic.barcode LEFT JOIN `brand` b ON b.brand_id = oic.brand_id LEFT JOIN `buyer` byr ON byr.buyer_id = b.buyer_id LEFT JOIN `teaproduct` tp ON tp.teaproduct_id = oic.teaproduct_id LEFT JOIN `teabagmaterial` tbm ON tbm.teabagmaterial_id=oic.teabagmaterial_id LEFT JOIN `contractschedule` cs ON cs.contract_no=oi.contract_no LEFT JOIN `shippingschedule` ss ON ss.ss_schedule_id=cs.schedule_id LEFT JOIN `shippingdetails` sd ON sd.shipping_address_id = oi.address_id LEFT JOIN (SELECT `fg_orderitem_no`, COUNT(*) AS `fg_orderitem_mc_count` FROM `finishedgoods` GROUP BY `fg_orderitem_no`) fgc ON fgc.fg_orderitem_no = oi.orderitem_no ORDER BY fg.fg_added_date DESC;";
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
                                String shippingschedule_id = mySqlDataReader.IsDBNull(71) ? "N/A" : mySqlDataReader.GetString("ss_schedule_id");
                                DateTime shipping_date = mySqlDataReader.IsDBNull(72) ? DateTime.MinValue : mySqlDataReader.GetDateTime("ss_shipping_date");
                                DateTime loading_date = mySqlDataReader.IsDBNull(73) ? DateTime.MinValue : mySqlDataReader.GetDateTime("ss_loading_date");

                                ShippingSchedule shippingSchedule = new ShippingSchedule(shippingschedule_id, shipping_date, loading_date);

                                //location
                                String location_id = mySqlDataReader.GetString("location_id");
                                String location_name = mySqlDataReader.GetString("location_name");
                                String location_desc = mySqlDataReader.IsDBNull(21) ? "N/A" : mySqlDataReader.GetString("location_description");

                                Location location = new Location(location_id, location_name, location_desc);

                                //order item
                                String orderitem_no = mySqlDataReader.GetString("orderitem_no");
                                String contract_no = mySqlDataReader.IsDBNull(20) ? "N/A" : mySqlDataReader.GetString("contract_no");
                                String order_placed_by = mySqlDataReader.GetString("productionmanager_id");
                                DateTime orderitem_placement_date = mySqlDataReader.GetDateTime("orderitem_placement_date");
                                String productionplan_id = mySqlDataReader.IsDBNull(26) ? "N/A" : mySqlDataReader.GetString("productionplan_id");
                                int mc_quantity = mySqlDataReader.GetInt32("mc_quantity");
                                int mc_end = mySqlDataReader.GetInt32("mc_end");
                                int mc_start = mySqlDataReader.GetInt32("mc_start");
                                String orderitem_status = mySqlDataReader.GetString("orderitem_status");
                                DateTime orderitem_production_startdate = mySqlDataReader.IsDBNull(31) ? DateTime.MinValue : mySqlDataReader.GetDateTime("orderitem_production_startdate");
                                DateTime orderitem_production_enddate = mySqlDataReader.IsDBNull(32) ? DateTime.MinValue : mySqlDataReader.GetDateTime("orderitem_production_enddate");
                                int orderitem_mc_count = mySqlDataReader.IsDBNull(87) ? 0 : mySqlDataReader.GetInt32("fg_orderitem_mc_count");

                                OrderItem orderItem = new OrderItem(buyer, brand, teaProduct, orderItemContent, shippingDetail, order, orderitem_no, contract_no, order_placed_by, orderitem_placement_date, productionplan_id, mc_quantity, mc_start, mc_end, orderitem_status, orderitem_production_startdate, orderitem_production_enddate);
                                orderItem.shippingSchedule = shippingSchedule;
                                orderItem.teabagMaterial = teabagMaterial;
                                orderItem.mc_count = orderitem_mc_count;
                                orderItem.location = location;

                                //finished good
                                String fg_ln_id = mySqlDataReader.GetString("fg_location_id");
                                String fg_added_by = mySqlDataReader.GetString("fg_added_by");
                                DateTime fg_added_date = mySqlDataReader.GetDateTime("fg_added_date");
                                Decimal fg_mc_weight = mySqlDataReader.GetDecimal("fg_mc_weight");
                                DateTime fg_exp_date = mySqlDataReader.GetDateTime("fg_exp_date");
                                String fg_status = mySqlDataReader.GetString("fg_status");
                                String fg_remarks = mySqlDataReader.IsDBNull(15) ? "N/A" : mySqlDataReader.GetString("fg_remarks");

                                FinishedGood finishedGood = new FinishedGood("", "", fg_ln_id, fg_added_by, fg_added_date, fg_mc_weight, fg_exp_date, fg_status, fg_remarks);
                                finishedGood.orderItem = orderItem;

                                //stored good
                                String sg_orderitem_no = mySqlDataReader.GetString("sg_orderitem_no");
                                String sg_mc_no = mySqlDataReader.GetString("sg_mc_no");
                                String sg_ln_id = fg_ln_id;
                                String sg_status = fg_status;
                                String sg_stored_by = mySqlDataReader.GetString("sg_stored_by");
                                DateTime sg_stored_date = mySqlDataReader.GetDateTime("sg_stored_date");
                                String sg_issued_by = mySqlDataReader.IsDBNull(4) ? "N/A" : mySqlDataReader.GetString("sg_issued_by");
                                DateTime sg_issued_date = mySqlDataReader.IsDBNull(5) ? DateTime.MinValue : mySqlDataReader.GetDateTime("sg_issued_date");
                                String sg_remarks = mySqlDataReader.IsDBNull(6) ? "N/A" : mySqlDataReader.GetString("fg_remarks");

                                StoredGood storedGood = new StoredGood(sg_orderitem_no, sg_mc_no, sg_ln_id, sg_stored_by, sg_stored_date, sg_issued_by,sg_issued_date, sg_status, sg_remarks);
                                storedGood.finishedGood = finishedGood;

                                storedGoods.Add(storedGood);
                            }

                            return storedGoods;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to fetch Stored Master Carton Details. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //get all completed MCs
        public List<FinishedGood> getAllCompletedMasterCartons()
        {
            List<FinishedGood> finishedGoods = new List<FinishedGood>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `finishedgoods` fg LEFT JOIN `location` ln ON ln.location_id = fg.fg_location_id LEFT JOIN `orderitem` oi ON fg.fg_orderitem_no = oi.orderitem_no LEFT JOIN `order` o ON o.order_no=oi.order_no LEFT JOIN `orderitemcontents` oic ON oi.barcode = oic.barcode LEFT JOIN `brand` b ON b.brand_id = oic.brand_id LEFT JOIN `buyer` byr ON byr.buyer_id = b.buyer_id LEFT JOIN `teaproduct` tp ON tp.teaproduct_id = oic.teaproduct_id LEFT JOIN `teabagmaterial` tbm ON tbm.teabagmaterial_id=oic.teabagmaterial_id LEFT JOIN `contractschedule` cs ON cs.contract_no=oi.contract_no LEFT JOIN `shippingschedule` ss ON ss.ss_schedule_id=cs.schedule_id LEFT JOIN `shippingdetails` sd ON sd.shipping_address_id = oi.address_id LEFT JOIN (SELECT `fg_orderitem_no`, COUNT(*) AS `fg_orderitem_mc_count` FROM `finishedgoods` GROUP BY `fg_orderitem_no`) fgc ON fgc.fg_orderitem_no = oi.orderitem_no WHERE fg.fg_status='Completed' ORDER BY fg.fg_added_date DESC;";
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
