using EmployeeManagement.BAL;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeManagement.Controllers
{
    [Route("api/")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class HomeController : ControllerBase
    {
        
        [HttpGet]
        [Route("GetUserDetails/UserId")]
        public IActionResult GetUserDetails(int UserId)
        {
            EmployeeManager employeeManager = new EmployeeManager();
            var EmpDetails = employeeManager.GetEmployeeDetails(UserId);
            return Ok(EmpDetails);
        }

        [HttpGet]
        [Route("GetEmployeeWorkDetails/EmpId")]
        public IActionResult GetEmployeeWorkDetails(int EmpId)
        {
            EmployeeManager employeeManager = new EmployeeManager();
            var EmpWorkDetails = employeeManager.GetEmployeeWorkDetails(EmpId);
            return Ok(EmpWorkDetails);
        }

    }
}
