using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LogisticManagementSystem.Models
{
    public class EmployeeLoginModelManager
    {

        public EmloyeeLoginModel EmployeeAuthentication(EmloyeeLoginModel oEmloyeeLoginModel)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("EmployeeAuth", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Employeeid", SqlDbType.VarChar, 40).Value = oEmloyeeLoginModel.UserEmail;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar, 40).Value = oEmloyeeLoginModel.Password;
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr["EmployeeName"] != DBNull.Value && dr["Role"] != DBNull.Value)
                            {
                                oEmloyeeLoginModel.UserName = Convert.ToString(dr["EmployeeName"]);
                                oEmloyeeLoginModel.Role = Convert.ToString(dr["role"]);
                                oEmloyeeLoginModel.WorkLocation = Convert.ToString(dr["WorkLocation"]);
                                oEmloyeeLoginModel.IsValid = 1;
                            }
                            else
                            {
                                oEmloyeeLoginModel.IsValid = 0;
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
                return oEmloyeeLoginModel;

            }
        }
    }
}