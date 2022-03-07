using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using EmployeeManagement.Models;
using EmployeeManagement.BAL.Common;

using Newtonsoft.Json.Linq;
using EmployeeManagement.Models.ResponseModels;
using EmployeeManagement.Interfaces.EmployeeInterfaces;

namespace EmployeeManagement.BAL
{

    public class EmployeeManager :IEmployeeManager
    {
        public IEmployeeRepository _employeeRepository { get; set; }
        public EmployeeManager(IEmployeeRepository loginRepository)
        {
            _employeeRepository = loginRepository;
        }

        public List<EmployeeDetailsResponse> GetEmployeeDetails(int UserId)
        {
            return _employeeRepository.GetEmployeeDetails(UserId);
        }

        public List<EmployeeWorkDetailsResponse> GetEmployeeWorkDetails(int EmpId)
        {
            return _employeeRepository.GetEmployeeWorkDetails(EmpId);

        }
    }
}
