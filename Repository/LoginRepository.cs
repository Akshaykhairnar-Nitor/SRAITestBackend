using EmployeeManagement.BAL.Common;
using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using EmployeeManagement.Models.ResponseModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class LoginRepository: ILoginRepository
    {
        String  _connectionString;
        IConfiguration _config;
        public LoginRepository(IConfiguration config)
        {
            _config = config;
            _connectionString ="server=(localdb)\\SRAIAssignmentEmployeeDB;database=EmployeeManagement;Trusted_Connection=true";
        }

        public LoginResponseModel ValidateUser(LoginModel request)
        {
            DataTable resultTbl = new DataTable();
            List<LoginResponseModel> response;
            SqlConnection myConnection = new SqlConnection(_connectionString);

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
            catch (Exception ex)
            {
                myConnection.Close();
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }
    }
}
