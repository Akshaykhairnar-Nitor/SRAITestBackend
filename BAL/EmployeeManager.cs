using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using EmployeeManagement.Models;
using EmployeeManagement.BAL.Common;

using Newtonsoft.Json.Linq;
using EmployeeManagement.Models.ResponseModels;


namespace EmployeeManagement.BAL
{

    public class EmployeeManager
    {
        SqlConnection myConnection = new SqlConnection("server=(localdb)\\SRAIAssignmentEmployeeDB;database=EmployeeManagement;Trusted_Connection=true");
        DataTable resultTbl = new DataTable();
        
        public List<EmployeeDetailsResponse> GetEmployeeDetails(int UserId){
            List<EmployeeDetailsResponse> response;
            try
            {
                EmployeeDetailsResponse employeeDetailsResponse = new EmployeeDetailsResponse();

                using (SqlCommand sqlCmd = new SqlCommand("", myConnection))
                {
                    myConnection.Open();
                    SqlDataAdapter DAdapter = new SqlDataAdapter();
                    sqlCmd.CommandText = StoreProcedureNames.SELECT_EmployeeDetails;
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@UserId", UserId).ToString();
                    DAdapter.SelectCommand = sqlCmd;
                    DAdapter.Fill(resultTbl);
                    response = DataTableToListConverter.ConvertDataTable<EmployeeDetailsResponse>(resultTbl);
                    if(response != null && response.Count > 0)
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
