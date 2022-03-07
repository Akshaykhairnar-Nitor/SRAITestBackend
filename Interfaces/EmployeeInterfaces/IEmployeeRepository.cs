using EmployeeManagement.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Interfaces.EmployeeInterfaces
{
  public  interface IEmployeeRepository
    {
        List<EmployeeDetailsResponse> GetEmployeeDetails(int UserId);

        List<EmployeeWorkDetailsResponse> GetEmployeeWorkDetails(int EmpId);

    }
}
