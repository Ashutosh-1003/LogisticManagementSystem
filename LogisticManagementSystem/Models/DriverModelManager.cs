using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LogisticManagementSystem.Models
{
    public class DriverModelManager
    {
        public ShipmentModel DriverShipmentDetails(string DriverMailid)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            ShipmentModel oShipmentModel = new ShipmentModel();
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("DriverShipmentdetails", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DriverMail", DriverMailid);
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {

                            oShipmentModel.ShipmentId = Convert.ToInt32(dr["Shipmentid"]);
                            oShipmentModel.CompanyName = Convert.ToString(dr["companyname"]);
                            oShipmentModel.ContactPersonName = Convert.ToString(dr["contactpersonname"]);
                            oShipmentModel.CompanyState = Convert.ToString(dr["companystate"]);
                            oShipmentModel.CompanyCity = Convert.ToString(dr["companycity"]);
                            oShipmentModel.CompanyStreetAdd = Convert.ToString(dr["companystreetadd"]);
                            oShipmentModel.CompanyPinId = Convert.ToString(dr["companypinid"]);
                            oShipmentModel.CompanyEmail = Convert.ToString(dr["CompanyEmail"]);
                            oShipmentModel.ContactNumber = Convert.ToString(dr["contactnumber"]);
                            oShipmentModel.CompanyType = Convert.ToString(dr["ctypename"]);
                            oShipmentModel.GoodsWeight = Convert.ToString(dr["goodsweight"]);
                            oShipmentModel.PickUpDate = Convert.ToString(dr["pickupdate"]);
                            oShipmentModel.PickUpState = Convert.ToString(dr["pickupstate"]);
                            oShipmentModel.PickUpCity = Convert.ToString(dr["pickupcity"]);
                            oShipmentModel.PickUpStreetAdd = Convert.ToString(dr["pickupstreetadd"]);
                            oShipmentModel.PickUpPin = Convert.ToString(dr["pickuppinid"]);
                            oShipmentModel.DestinationState = Convert.ToString(dr["destinationstate"]);
                            oShipmentModel.DestinationCity = Convert.ToString(dr["destinationcity"]);
                            oShipmentModel.DestinationStreetAdd = Convert.ToString(dr["destinationstreetadd"]);
                            oShipmentModel.DestinationPin = Convert.ToString(dr["destinationpinid"]);
                            oShipmentModel.DropDate = Convert.ToString(dr["Dropdate"]);
                            oShipmentModel.DriverName = Convert.ToString(dr["DriverName"]);
                            oShipmentModel.DriverEmail = Convert.ToString(dr["DriverEmail"]);
                            oShipmentModel.DriverNumber = Convert.ToString(dr["DriverNumber"]);
                            oShipmentModel.ApprovedStatus = Convert.ToString(dr["ApprovedStatus"]);
                            oShipmentModel.ProductCurrentLocation = Convert.ToString(dr["ProductCurrentLocation"]);

                        }
                        dr.Close();
                        return oShipmentModel;


                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
        }
        public void UpdateShipmentLocation(ShipmentModel oShipmentModel)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateShipmentCurrentLocation", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Shipmentid", oShipmentModel.ShipmentId);
                    cmd.Parameters.AddWithValue("@ShipmentCurrentLocation", oShipmentModel.ProductCurrentLocation);



                    try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();

                    }
                    catch (SqlException ex)

                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }

            }
        }
         public void DeliveryUpdate(ShipmentModel oShipmentModel)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("DeliveryUpdate", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Shipmentid ", oShipmentModel.ShipmentId);
                    cmd.Parameters.AddWithValue("@DeliveryTime", oShipmentModel.DeliveryTime);
                    cmd.Parameters.AddWithValue("@GoodsVerificationStatus", oShipmentModel.GoodsVeifactionStatus);
                    cmd.Parameters.AddWithValue("@DeliveryNotes", oShipmentModel.DeliveryNotes);
                    cmd.Parameters.AddWithValue("@DriverMailid", oShipmentModel.DriverEmail);



                    try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();

                    }
                    catch (SqlException ex)

                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }

                }

            }
        }
    }
}