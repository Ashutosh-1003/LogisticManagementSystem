using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LogisticManagementSystem.Models
{
    public class LoginModelManager
    {
        public LoginModel UserAuth(LoginModel oLoginModel)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("CompanyEmployeeAuth", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserEmail", SqlDbType.VarChar, 40).Value = oLoginModel.UserEmail;
                    cmd.Parameters.Add("@UserPassword", SqlDbType.VarChar, 40).Value = oLoginModel.Password;
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr["EmployeeName"] != DBNull.Value && dr["Role"] != DBNull.Value)
                            {
                                oLoginModel.UserName = Convert.ToString(dr["EmployeeName"]);
                                oLoginModel.UserEmail = Convert.ToString(dr["Emoloyeemailid"]);
                                oLoginModel.Role = Convert.ToString(dr["Role"]);
                                oLoginModel.Worklocation = Convert.ToString(dr["Worklocation"]);
                                oLoginModel.IsValid = 1;
                            }
                            else
                            {
                                oLoginModel.IsValid = 0;
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
                return oLoginModel;

            }
        }
    }
}