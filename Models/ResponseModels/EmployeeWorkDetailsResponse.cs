using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.ResponseModels
{
    public class EmployeeWorkDetailsResponse
    {
        public int EMPTimesheetId { get; set; }
        public DateTime Date { get; set; }
        public string ProjectName { get; set; }
        public string TaskDetails { get; set; }
        public string Time { get; set; }
  
    }
}
