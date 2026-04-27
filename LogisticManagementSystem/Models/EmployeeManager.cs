using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LogisticManagementSystem.Models
{
    public class EmployeeManager
    {
         
        public List<ShipmentModel>  ArrivalsDetails(string DropUpState)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            List<ShipmentModel> oListshipmentModels = new List<ShipmentModel>();
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("ArrivalsDetails", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DropupState", DropUpState);
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while(dr.Read())
                        {
                            ShipmentModel oShipmentModel = new ShipmentModel();
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
                            oListshipmentModels.Add(oShipmentModel);
                        }
                        dr.Close();
                        return oListshipmentModels;

                    
                    } catch(SqlException ex)
                    {
                        throw ex;
                    }
                     finally
                    {
                        if (cn.State==System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
        }
        public List<ShipmentModel> ShippedItemsDetails(string PickUpState)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            List<ShipmentModel> oListshipmentModels = new List<ShipmentModel>();
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("ShippedItemsDetails", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Pickupstate", PickUpState);
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            ShipmentModel oShipmentModel = new ShipmentModel();
                            oShipmentModel.ShipmentId = Convert.ToInt32(dr["Shipmentid"]);
                            oShipmentModel.CompanyName = Convert.ToString(dr["companyname"]);
                            oShipmentModel.ContactPersonName = Convert.ToString(dr["contactpersonname"]);
                            oShipmentModel.CompanyState = Convert.ToString(dr["companystate"]);
                            oShipmentModel.CompanyCity = Convert.ToString(dr["companycity"]);
                            oShipmentModel.CompanyStreetAdd = Convert.ToString(dr["companystreetadd"]);
                            oShipmentModel.CompanyPinId = Convert.ToString(dr["companypinid"]);
                            oShipmentModel.ContactNumber = Convert.ToString(dr["contactnumber"]);
                            oShipmentModel.CompanyEmail = Convert.ToString(dr["CompanyEmail"]);
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
                            oListshipmentModels.Add(oShipmentModel);
                        }
                        dr.Close();
                        return oListshipmentModels;


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

