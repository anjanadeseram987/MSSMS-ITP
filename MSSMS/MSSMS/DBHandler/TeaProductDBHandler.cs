using MSSMS.Models;
using MSSMS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace MSSMS.DBHandler
{
    public class TeaProductDBHandler:DBHandler
    {
        //add teaproduct
        public bool addTeaProduct(TeaProduct teaProduct)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "INSERT INTO `teaproduct`(`teaproduct_name`, `teaproduct_flavor`, `teaproduct_serial_no`, `teaproduct_description`, `teaproduct_availability`) VALUES (@name, @flavor, @serial, @desc, @availability);";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = teaProduct.teaProductName;
                    mySqlCommand.Parameters.Add("@flavor", MySqlDbType.VarChar).Value = teaProduct.teaProductflavor;
                    mySqlCommand.Parameters.Add("@serial", MySqlDbType.VarChar).Value = teaProduct.teaProductserialNo;
                    mySqlCommand.Parameters.Add("@desc", MySqlDbType.VarChar).Value = string.IsNullOrEmpty(teaProduct.teaProductdescription) || string.IsNullOrWhiteSpace(teaProduct.teaProductdescription) ? "N/A" : teaProduct.teaProductdescription;
                    mySqlCommand.Parameters.Add("@availability", MySqlDbType.VarChar).Value = teaProduct.teaProductavailability;
                    mySqlCommand.Prepare();

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to add the Tea Product" + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //update teaproduct
        public bool updateTeaProduct(TeaProduct teaProduct)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `teaproduct` SET `teaproduct_name`=@teaProductName,`teaproduct_flavor`=@teaProductFlavor, `teaproduct_serial_no`=@teaProductSerial, `teaproduct_description`=@teaProductDesc, `teaproduct_availability`=@teaProductStatus WHERE `teaproduct_id`=@teaProductId;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@teaProductName", MySqlDbType.VarChar).Value = teaProduct.teaProductName;
                    mySqlCommand.Parameters.Add("@teaProductFlavor", MySqlDbType.VarChar).Value = teaProduct.teaProductflavor;
                    mySqlCommand.Parameters.Add("@teaProductSerial", MySqlDbType.VarChar).Value = teaProduct.teaProductserialNo;
                    mySqlCommand.Parameters.Add("@teaProductDesc", MySqlDbType.VarChar).Value = string.IsNullOrEmpty(teaProduct.teaProductdescription) || string.IsNullOrWhiteSpace(teaProduct.teaProductdescription) ? "N/A" : teaProduct.teaProductdescription;
                    mySqlCommand.Parameters.Add("@teaProductStatus", MySqlDbType.VarChar).Value = teaProduct.teaProductavailability;
                    mySqlCommand.Parameters.Add("@teaProductId", MySqlDbType.VarChar).Value = teaProduct.teaProductId;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to update the Tea Product " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //delete teaproduct
        public bool deleteTeaProduct(string teaProductId)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "DELETE FROM `teaproduct` WHERE `teaproduct_id`=@teaproductId";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@teaproductId", MySqlDbType.VarChar).Value = teaProductId;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to delete the Tea Product", "ERRORCODE");
                    }
                }
            }
        }

        //get all teaproduct
        public List<TeaProduct> getAllTeaProducts()
        {
            List<TeaProduct> teaProducts = new List<TeaProduct>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `teaproduct`";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String teaproduct_id = mySqlDataReader.GetString("teaproduct_id");
                                String teaproduct_serial = mySqlDataReader.GetString("teaproduct_serial_no");
                                String teaproduct_name = mySqlDataReader.GetString("teaproduct_name");
                                String teaproduct_flavor = mySqlDataReader.GetString("teaproduct_flavor");
                                String teaproduct_description = mySqlDataReader.GetString("teaproduct_description");
                                String teaproduct_availability = mySqlDataReader.GetString("teaproduct_availability");

                                TeaProduct teaProduct = new TeaProduct(teaproduct_id,teaproduct_name,teaproduct_flavor, teaproduct_serial, teaproduct_description, teaproduct_availability);
                                teaProducts.Add(teaProduct);
                            }

                            return teaProducts;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to fetch Tea Products " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }


        //add teabag material
        public bool addTeabagMaterial(TeabagMaterial teabagMaterial)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "INSERT INTO `teabagmaterial`(`teabag_name`, `teabag_type`, `teabag_serial_no`, `teabag_description`, `teabag_availability`) VALUES (@name, @type, @serial, @desc, @availability);";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = teabagMaterial.materialName;
                    mySqlCommand.Parameters.Add("@type", MySqlDbType.VarChar).Value = string.IsNullOrEmpty(teabagMaterial.teabagType) || string.IsNullOrWhiteSpace(teabagMaterial.teabagType) ? "N/A" : teabagMaterial.teabagType;
                    mySqlCommand.Parameters.Add("@serial", MySqlDbType.VarChar).Value = teabagMaterial.materialSerialNo;
                    mySqlCommand.Parameters.Add("@desc", MySqlDbType.VarChar).Value = string.IsNullOrEmpty(teabagMaterial.materialDescription) || string.IsNullOrWhiteSpace(teabagMaterial.materialDescription) ? "N/A" : teabagMaterial.materialDescription;
                    mySqlCommand.Parameters.Add("@availability", MySqlDbType.VarChar).Value = teabagMaterial.materialAvailability;
                    mySqlCommand.Prepare();

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to add the Teabag Material" + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //update teabag material
        public bool updateTeabagMaterial(TeabagMaterial teabagMaterial)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "UPDATE `teabagmaterial` SET `teabag_name`=@name,`teabag_type`=@type,`teabag_serial_no`=@serial,`teabag_description`=@desc,`teabag_availability`=@availabitlity WHERE `teabagmaterial_id`=@id;";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = teabagMaterial.materialName;
                    mySqlCommand.Parameters.Add("@type", MySqlDbType.VarChar).Value = string.IsNullOrEmpty(teabagMaterial.teabagType) || string.IsNullOrWhiteSpace(teabagMaterial.teabagType) ? "N/A" : teabagMaterial.teabagType;
                    mySqlCommand.Parameters.Add("@serial", MySqlDbType.VarChar).Value = teabagMaterial.materialSerialNo;
                    mySqlCommand.Parameters.Add("@desc", MySqlDbType.VarChar).Value = string.IsNullOrEmpty(teabagMaterial.materialDescription) || string.IsNullOrWhiteSpace(teabagMaterial.materialDescription) ? "N/A" : teabagMaterial.materialDescription;
                    mySqlCommand.Parameters.Add("@availabitlity", MySqlDbType.VarChar).Value = teabagMaterial.materialAvailability;
                    mySqlCommand.Parameters.Add("@id", MySqlDbType.VarChar).Value = teabagMaterial.materialId;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to update the Teabag Material " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //delete teabag material
        public bool deleteTeabagMaterial(string teabagMaterialId)
        {
            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "DELETE FROM `teabagmaterial` WHERE `teabagmaterial_id`=@materialId";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    mySqlCommand.Parameters.Add("@materialId", MySqlDbType.VarChar).Value = teabagMaterialId;

                    try
                    {
                        mySqlCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new MSSMUIException("Failed to delete the Teabag Material", "ERRORCODE");
                    }
                }
            }
        }

        //get all teabag material
        public List<TeabagMaterial> getAllTeabagMaterials()
        {
            List<TeabagMaterial> teabagMaterials = new List<TeabagMaterial>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `teabagmaterial`";
                    mySqlCommand.CommandType = CommandType.Text;
                    mySqlCommand.Connection = connection;

                    try
                    {
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                String teabagmaterial_id = mySqlDataReader.GetString("teabagmaterial_id");
                                String teabagmaterial_serial = mySqlDataReader.GetString("teabag_serial_no");
                                String teabagmaterial_name = mySqlDataReader.GetString("teabag_name");
                                String teabagmaterial_type = mySqlDataReader.GetString("teabag_type");
                                String teabagmaterial_description = mySqlDataReader.GetString("teabag_description");
                                String teabagmaterial_availability = mySqlDataReader.GetString("teabag_availability");

                                TeabagMaterial teabagMaterial = new TeabagMaterial(teabagmaterial_id, teabagmaterial_name, teabagmaterial_type, teabagmaterial_serial, teabagmaterial_description, teabagmaterial_availability);
                                teabagMaterials.Add(teabagMaterial);
                            }

                            return teabagMaterials;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("Failed to fetch Teabag Materials " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //search queries
        //search everywhere in teaproduct
        public List<TeaProduct> searchTebproducts(string keyword)
        {
            List<TeaProduct> teaProducts = new List<TeaProduct>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `teaproduct` WHERE `teaproduct_serial_no` LIKE @keyword OR `teaproduct_name` LIKE @keyword OR `teaproduct_description` LIKE @keyword OR `teaproduct_flavor` LIKE @keyword OR `teaproduct_availability` LIKE @keyword;";
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
                                String teaproduct_id = mySqlDataReader.GetString("teaproduct_id");
                                String teaproduct_serial = mySqlDataReader.GetString("teaproduct_serial_no");
                                String teaproduct_name = mySqlDataReader.GetString("teaproduct_name");
                                String teaproduct_flavor = mySqlDataReader.GetString("teaproduct_flavor");
                                String teaproduct_description = mySqlDataReader.GetString("teaproduct_description");
                                String teaproduct_availability = mySqlDataReader.GetString("teaproduct_availability");

                                TeaProduct teaProduct = new TeaProduct(teaproduct_id, teaproduct_name, teaproduct_flavor, teaproduct_serial, teaproduct_description, teaproduct_availability);
                                teaProducts.Add(teaProduct);
                            }

                            return teaProducts;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //search in teaproduct by column
        public List<TeaProduct> searchTebproductsUsingColumn(string column, string keyword)
        {
            List<TeaProduct> teaProducts = new List<TeaProduct>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `teaproduct` WHERE `" + column + "` LIKE @keyword;";
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
                                String teaproduct_id = mySqlDataReader.GetString("teaproduct_id");
                                String teaproduct_serial = mySqlDataReader.GetString("teaproduct_serial_no");
                                String teaproduct_name = mySqlDataReader.GetString("teaproduct_name");
                                String teaproduct_flavor = mySqlDataReader.GetString("teaproduct_flavor");
                                String teaproduct_description = mySqlDataReader.GetString("teaproduct_description");
                                String teaproduct_availability = mySqlDataReader.GetString("teaproduct_availability");

                                TeaProduct teaProduct = new TeaProduct(teaproduct_id, teaproduct_name, teaproduct_flavor, teaproduct_serial, teaproduct_description, teaproduct_availability);
                                teaProducts.Add(teaProduct);
                            }

                            return teaProducts;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //SEARCH QUERIES
        //search everywhere in teabagmaterial
        public List<TeabagMaterial> searchTebagMaterials( string keyword)
        {
            List<TeabagMaterial> teabagMaterials = new List<TeabagMaterial>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `teabagmaterial` WHERE `teabag_serial_no` LIKE @keyword OR `teabag_name` LIKE @keyword OR `teabag_description` LIKE @keyword OR `teabag_type` LIKE @keyword OR `teabag_availability` LIKE @keyword;";
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
                                String teabagmaterial_id = mySqlDataReader.GetString("teabagmaterial_id");
                                String teabagmaterial_serial = mySqlDataReader.GetString("teabag_serial_no");
                                String teabagmaterial_name = mySqlDataReader.GetString("teabag_name");
                                String teabagmaterial_type = mySqlDataReader.GetString("teabag_type");
                                String teabagmaterial_description = mySqlDataReader.GetString("teabag_description");
                                String teabagmaterial_availability = mySqlDataReader.GetString("teabag_availability");

                                TeabagMaterial teabagMaterial = new TeabagMaterial(teabagmaterial_id, teabagmaterial_name, teabagmaterial_type, teabagmaterial_serial, teabagmaterial_description, teabagmaterial_availability);
                                teabagMaterials.Add(teabagMaterial);
                            }

                            return teabagMaterials;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MSSMUIException("No result. " + ex.Message, "ERRORCODE");
                    }
                }
            }
        }

        //search in teabagmaterial by column
        public List<TeabagMaterial> searchTebagMaterialsUsingColumn(string column, string keyword)
        {
            List<TeabagMaterial> teabagMaterials = new List<TeabagMaterial>();

            using (connection)
            {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    mySqlCommand.CommandText = "SELECT * FROM `teabagmaterial` WHERE `" + column + "` LIKE @keyword;";
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
                                String teabagmaterial_id = mySqlDataReader.GetString("teabagmaterial_id");
                                String teabagmaterial_serial = mySqlDataReader.GetString("teabag_serial_no");
                                String teabagmaterial_name = mySqlDataReader.GetString("teabag_name");
                                String teabagmaterial_type = mySqlDataReader.GetString("teabag_type");
                                String teabagmaterial_description = mySqlDataReader.GetString("teabag_description");
                                String teabagmaterial_availability = mySqlDataReader.GetString("teabag_availability");

                                TeabagMaterial teabagMaterial = new TeabagMaterial(teabagmaterial_id, teabagmaterial_name, teabagmaterial_type, teabagmaterial_serial, teabagmaterial_description, teabagmaterial_availability);
                                teabagMaterials.Add(teabagMaterial);
                            }

                            return teabagMaterials;
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
