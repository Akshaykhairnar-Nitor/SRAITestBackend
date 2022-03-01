using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using EmployeeManagement.Models;
using EmployeeManagement.BAL.Common;

using Newtonsoft.Json.Linq;
using EmployeeManagement.Models.ResponseModels;

namespace EmployeeManagement.Manager
{
    public class LoginManager
    {
        public JObject requestModel = null;

        public LoginResponseModel ValidateUser(LoginModel request)
        {
            SqlConnection myConnection = new SqlConnection("server=(localdb)\\SRAIAssignmentEmployeeDB;database=EmployeeManagement;Trusted_Connection=true");
            DataTable  resultTbl = new DataTable();
            List<LoginResponseModel> response;
            try
            {
               LoginResponseModel loginResponseModel = new LoginResponseModel();

                using (SqlCommand sqlCmd = new SqlCommand("", myConnection))
                {
                    myConnection.Open();
                    SqlDataAdapter DAdapter = new SqlDataAdapter();
                    sqlCmd.CommandText = StoreProcedureNames.SELECT_UserLogin; 
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@UserName", request.UserName).ToString();
                    sqlCmd.Parameters.AddWithValue("@Password", request.Password).ToString();
                    DAdapter.SelectCommand = sqlCmd;
                    DAdapter.Fill(resultTbl);
                    response = DataTableToListConverter.ConvertDataTable<LoginResponseModel>(resultTbl);
                    //Result = (resultTbl > 0) ? true : false;
                }
            }
            catch (Exception ex)
            {
                myConnection.Close();
                return null;
            }
            finally
            {
                myConnection.Close();
            }

            if (response != null && response.Count > 0)
            {
                return response.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}
