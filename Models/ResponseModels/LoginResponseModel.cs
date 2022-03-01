using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.ResponseModels
{
    public class LoginResponseModel
    {
        //public bool Successful { get; set; }
        public string Mobile { get; set; }

        public string UserName { get; set; }

        public int UserId { get; set; }
        //public string Token { get; set; }
    }
}
