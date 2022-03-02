using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.BAL.Common
{
    public class StoreProcedureNames
    {
        #region Authentication 
        public const string SELECT_UserLogin = "[dbo].[User_UserLogin_Select]";
        #endregion

        #region Employee Details
        public const string SELECT_EmployeeDetails = "[dbo].[Get_UserDetails]";
        public const string SELECT_EmployeeTimesheet = "[dbo].[Get_EmployeeWorkDetails]";
        #endregion
    }
}
