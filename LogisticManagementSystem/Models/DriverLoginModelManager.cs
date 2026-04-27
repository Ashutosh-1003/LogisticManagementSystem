using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LogisticManagementSystem.Models
{
    public class DriverLoginModelManager
    {
        public DriverLoginModel DriverAuth(DriverLoginModel oDriverLoginModel)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("DriverAuth", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DriverEmail", SqlDbType.VarChar, 40).Value = oDriverLoginModel.UserEmail;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar, 40).Value = oDriverLoginModel.Password;
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr["Drivername"] != DBNull.Value && dr["Role"] != DBNull.Value)
                            {
                                oDriverLoginModel.UserName = Convert.ToString(dr["Drivername"]);
                                oDriverLoginModel.Role = Convert.ToString(dr["Role"]);
                                oDriverLoginModel.UserEmail = Convert.ToString(dr["DriverEmail"]);
                                oDriverLoginModel.IsValid = 1;
                            }
                            else
                            {
                                oDriverLoginModel.IsValid = 0;
                            }
                        }
                        dr.Close();


                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
                return oDriverLoginModel;

            }
        }
    }
}