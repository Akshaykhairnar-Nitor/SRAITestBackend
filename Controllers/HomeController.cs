using EmployeeManagement.BAL;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    [Route("api/")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class HomeController : ControllerBase
    {
        // GET: api/<HomeController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<HomeController>/5
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
