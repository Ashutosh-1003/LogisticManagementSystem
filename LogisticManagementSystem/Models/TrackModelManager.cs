using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LogisticManagementSystem.Models
{
    public class TrackModelManager
    {
        public TrackModel ShipmentLocationDetails(TrackModel oTrackModel)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("TrackShipmentInfo", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Shimentid", oTrackModel.ShipmentId);
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {

                            oTrackModel.ApprovedStatus = Convert.ToString(dr["ApprovedStatus"]);
                            oTrackModel.Currentlocation = Convert.ToString(dr["ProductCurrentLocation"]);


                        }
                        dr.Close();
                        return oTrackModel;


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