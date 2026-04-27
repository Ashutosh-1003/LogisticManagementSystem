using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace LogisticManagementSystem.Models
{
   public class AdminModelManager
    {
        public List<ShipmentModel> ShipmentDetailsfillAdminForm(ShipmentModel oShipmentModel)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("AdminVeriFication", cn))
                {
                    try
                    {
                        List<ShipmentModel> ListOfShipmentDetails = new List<ShipmentModel>();
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while(dr.Read())
                        {
                            ListOfShipmentDetails.Add(new ShipmentModel
                            {
                                ShipmentId = Convert.ToInt32(dr["Shipmentid"]),
                                CompanyName= (dr["companyname"]).ToString(),
                                ContactPersonName= (dr["ContactPersonName"]).ToString(),
                                CompanyState= (dr["companystate"]).ToString(),
                                CompanyCity=(dr["CompanyCity"]).ToString(),
                                CompanyStreetAdd=(dr["CompanyStreetAdd"]).ToString(),
                                CompanyPinId=(dr["CompanyPinid"]).ToString(),
                                ContactNumber=(dr["ContactNumber"]).ToString(),
                                CompanyEmail=(dr["CompanyEmail"]).ToString(),
                                CompanyType=(dr["ctypename"]).ToString(),
                                GoodsWeight=(dr["GoodsWeight"]).ToString(),
                                PickUpDate=(dr["PickupDate"]).ToString(),
                                PickUpState=(dr["pickupstate"]).ToString(),
                                PickUpCity= (dr["PickupCity"]).ToString(),
                                PickUpStreetAdd=(dr["PickupStreetadd"]).ToString(),
                                PickUpPin= (dr["PickupPinid"]).ToString(),
                                DestinationState=(dr["Destinationstate"]).ToString(),
                                DestinationCity=(dr["DestinationCity"]).ToString(),
                                DestinationStreetAdd= (dr["DestinationStreetAdd"]).ToString(),
                                DestinationPin=(dr["Destinationpinid"]).ToString(),

                            });
                            
                            

                        }
                        dr.Close();
                        return ListOfShipmentDetails;
                        
                    }catch(SqlException ex)
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
         public ShipmentModel DriverNames(ShipmentModel oShipmentModel)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("driverdetails", cn))
                {
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while(dr.Read())
                        {
                            oShipmentModel.ListofDriver.Add(Convert.ToString(dr["Drivername"]));
                        }
                        dr.Close();
                        return oShipmentModel;

                        
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
        public ShipmentModel DriverInfo(string driverName)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            ShipmentModel oShipmentModel = new ShipmentModel();
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("driverinfo", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@drivername", driverName);
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while(dr.Read())
                        {
                            oShipmentModel.DriverNumber = Convert.ToString(dr["PhoneNumber"]);
                            oShipmentModel.DriverEmail= Convert.ToString(dr["driveremail"]);
                        }
                        dr.Close();
                        return oShipmentModel;
                    } 
                      catch(SqlException ex)
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
         public  void UpdateShipmentDetails (ShipmentModel oShipmentModel)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateShipmentDeatails",cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Shipmentid", oShipmentModel.ShipmentId);
                    cmd.Parameters.AddWithValue("@DropDate", (oShipmentModel.DropDate==null)?(object)DBNull.Value:oShipmentModel.DropDate);
                    cmd.Parameters.AddWithValue("@Drivername", (oShipmentModel.DriverName == null) ? (object)DBNull.Value : oShipmentModel.DriverName);
                    cmd.Parameters.AddWithValue("@DriverEmail", (oShipmentModel.DriverEmail == null) ? (object)DBNull.Value : oShipmentModel.DriverEmail);
                    cmd.Parameters.AddWithValue("@DriverNumber", (oShipmentModel.DriverNumber == null) ? (object)DBNull.Value : oShipmentModel.DriverNumber);
                    cmd.Parameters.AddWithValue("@ApproveStatus", oShipmentModel.ApprovedStatus);
                     if (oShipmentModel.ApprovedStatus=="Approve")
                    {
                        cmd.Parameters.AddWithValue("@ShipmentActive", "True");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ShipmentActive", "False");

                    }
                     try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();

                    } catch(SqlException ex)

                    {
                        throw ex;
                    }
                     finally
                    {
                        if (cn.State== System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
        }

    }
}

 