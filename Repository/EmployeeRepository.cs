using EmployeeManagement.BAL.Common;
using EmployeeManagement.Interfaces.EmployeeInterfaces;
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
    public class EmployeeRepository:IEmployeeRepository
    {
        String _connectionString;
        IConfiguration _config;
        public EmployeeRepository(IConfiguration config)
        {
            _config = config;
            _connectionString = "server=(localdb)\\SRAIAssignmentEmployeeDB;database=EmployeeManagement;Trusted_Connection=true";
        }

        public List<EmployeeDetailsResponse> GetEmployeeDetails(string username)
        {
            List<EmployeeDetailsResponse> response;
            DataTable resultTbl = new DataTable();
            SqlConnection myConnection = new SqlConnection(_connectionString);

            try
            {
                EmployeeDetailsResponse employeeDetailsResponse = new EmployeeDetailsResponse();

                using (SqlCommand sqlCmd = new SqlCommand("", myConnection))
                {
                    myConnection.Open();
                    SqlDataAdapter DAdapter = new SqlDataAdapter();
                    sqlCmd.CommandText = StoreProcedureNames.SELECT_EmployeeDetails;
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@UserName", username).ToString();
                    DAdapter.SelectCommand = sqlCmd;
                    DAdapter.Fill(resultTbl);
                    response = DataTableToListConverter.ConvertDataTable<EmployeeDetailsResponse>(resultTbl);
                    if (response != null && response.Count > 0)
                    {
                        return response;
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
        public List<EmployeeWorkDetailsResponse> GetEmployeeWorkDetails(int EmpId)
        {
            DataTable resultTbl = new DataTable();
            SqlConnection myConnection = new SqlConnection(_connectionString);
            List<EmployeeWorkDetailsResponse> response;
            try
            {
                EmployeeWorkDetailsResponse employeeWorkDetailsResponse = new EmployeeWorkDetailsResponse();

                using (SqlCommand sqlCmd = new SqlCommand("", myConnection))
                {
                    myConnection.Open();
                    SqlDataAdapter DAdapter = new SqlDataAdapter();
                    sqlCmd.CommandText = StoreProcedureNames.SELECT_EmployeeTimesheet;
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@EmpId", EmpId).ToString();
                    DAdapter.SelectCommand = sqlCmd;
                    DAdapter.Fill(resultTbl);
                    response = DataTableToListConverter.ConvertDataTable<EmployeeWorkDetailsResponse>(resultTbl);
                    if (response != null && response.Count > 0)
                    {
                        return response;
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
