using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using EmployeeManagement.Models;
using EmployeeManagement.BAL.Common;

using Newtonsoft.Json.Linq;
using EmployeeManagement.Models.ResponseModels;
using EmployeeManagement.Interfaces;

namespace EmployeeManagement.Manager
{
    public class LoginManager: ILoginManager
    {
        public ILoginRepository _loginRepository { get; set; }
        public LoginManager(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public LoginResponseModel ValidateUser(LoginModel request)
        {
            return _loginRepository.ValidateUser(request);
        }
    }
}
