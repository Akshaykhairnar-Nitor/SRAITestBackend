using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.BAL.Common
{
    public class StoreProcedureNames
    {
        #region Login
        public const string SELECT_UserLogin = "[dbo].[User_UserLogin_Select]";
        public const string SELECT_EmployeeDetails = "[dbo].[Get_UserDetails]";
        public const string SELECT_EmployeeTimesheet = "[dbo].[Get_EmployeeWorkDetails]";


        #endregion
    }
}
