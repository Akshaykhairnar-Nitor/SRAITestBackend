using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeDetails
    {
        public int? EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpContact { get; set; }
        public string EmpEmail { get; set; }
        public string EmpAddress { get; set; }
    }
}
