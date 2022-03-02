using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.ResponseModels
{
    public class EmployeeDetailsResponse
    {

        public int EMPId { get; set; }
        public string EmpName { get; set; }
        public string EmpContact { get; set; }
        public string EmpEmail { get; set; }
        public string EmpAddress { get; set; }
        public string Desiganation { get; set; }
        public int EmpProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime Project_StartDate { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectManager { get; set; }
    }
}
