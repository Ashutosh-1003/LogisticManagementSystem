using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LogisticManagementSystem.Models
{
    public class ShipmentDetailsManager
    {
        public ShipmentModel FillRequestForm(ShipmentModel oShipmentDetails)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("fillcustomberfrom", cn))
                {
                    try
                    {
                        cn.Open();

                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oShipmentDetails.ListofState.Add(Convert.ToString(dr["statename"]));
                        }
                        dr.NextResult();
                        /*  while(dr.Read())
                           {
                               ocustomberfrom.listofcity.Add(Convert.ToString(dr["cityname"]));
                           }*/
                        dr.NextResult();
                        while (dr.Read())
                        {
                            oShipmentDetails.ListofComtype.Add(Convert.ToString(dr["ctypename"]));
                        }
                        dr.Close();

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
            return oShipmentDetails;

        }
        public ShipmentModel SelectCity(string StateName)
        {

            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            ShipmentModel oshipmentModel = new ShipmentModel();
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("selectcity", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@statename", StateName);
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oshipmentModel.ListofCity.Add(Convert.ToString(dr["cityname"]));
                        }
                        dr.Close();

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
                    return oshipmentModel;
                }
            }
        }
        public void InsertCustomberRequest(ShipmentModel oshipmentDetails)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("fillshipmentdetails", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@companyname", oshipmentDetails.CompanyName);
                    cmd.Parameters.AddWithValue("@contactpersonname", oshipmentDetails.ContactPersonName);
                    cmd.Parameters.AddWithValue("@companystate", oshipmentDetails.CompanyState);
                    cmd.Parameters.AddWithValue("@companycity", oshipmentDetails.CompanyCity);
                    cmd.Parameters.AddWithValue("@companystreetadd", oshipmentDetails.CompanyStreetAdd);
                    cmd.Parameters.AddWithValue("@companypin", oshipmentDetails.CompanyPinId);
                    cmd.Parameters.AddWithValue("@Contactno", oshipmentDetails.ContactNumber);
                    cmd.Parameters.AddWithValue("@companyemail", oshipmentDetails.CompanyEmail);
                    cmd.Parameters.AddWithValue("@companytype", oshipmentDetails.CompanyType);
                    cmd.Parameters.AddWithValue("@goodsweight", oshipmentDetails.GoodsWeight);
                    cmd.Parameters.AddWithValue("@pickupdate", oshipmentDetails.PickUpDate);
                    cmd.Parameters.AddWithValue("@pickupstate", oshipmentDetails.PickUpState);
                    cmd.Parameters.AddWithValue("@pickupcity", oshipmentDetails.PickUpCity);
                    cmd.Parameters.AddWithValue("@pickupstreet", oshipmentDetails.PickUpStreetAdd);
                    cmd.Parameters.AddWithValue("@pickuppin", oshipmentDetails.PickUpPin);
                    cmd.Parameters.AddWithValue("@dropupstate", oshipmentDetails.DestinationState);
                    cmd.Parameters.AddWithValue("@dropupcity", oshipmentDetails.DestinationCity);
                    cmd.Parameters.AddWithValue("@dropupstreet", oshipmentDetails.DestinationStreetAdd);
                    cmd.Parameters.AddWithValue("@droppinid", oshipmentDetails.DestinationPin);

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
        public ShipmentModel ShipmentId(ShipmentModel oShipmentDetails)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("getshipmentid ", cn))
                {
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oShipmentDetails.ShipmentId = Convert.ToInt32(dr["shipmentid"]);
                        }
                        dr.Close();

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
            return oShipmentDetails;


        }
    }
}