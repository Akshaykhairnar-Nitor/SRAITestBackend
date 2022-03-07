using EmployeeManagement.Models;
using EmployeeManagement.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Interfaces
{
    public interface ILoginRepository
    {
        LoginResponseModel ValidateUser(LoginModel request);
    }
}
