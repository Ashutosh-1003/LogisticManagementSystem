using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LogisticManagementSystem.Models
{
    public class EnquiryModelManager
    {
        public EnquiryModel FillState(EnquiryModel oEnquiryModel)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("selectstate", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oEnquiryModel.StateName.Add(Convert.ToString(dr["statename"]));
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
                return oEnquiryModel;

            }

        }
        public void InsertEnquiryDetail(EnquiryModel oEnquiryModel)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("insertenquirydetails", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@firstname", oEnquiryModel.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", oEnquiryModel.LastName);
                    cmd.Parameters.AddWithValue("@jobtitle", oEnquiryModel.JobTitle);
                    cmd.Parameters.AddWithValue("@companyname", oEnquiryModel.Company);
                    cmd.Parameters.AddWithValue("@state", oEnquiryModel.State);
                    cmd.Parameters.AddWithValue("@email", oEnquiryModel.Email);
                    cmd.Parameters.AddWithValue("@phone ", oEnquiryModel.Phone);
                    cmd.Parameters.AddWithValue("@message", (oEnquiryModel.Message==null)?(object)DBNull.Value:oEnquiryModel.Message);
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