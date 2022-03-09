using EmployeeManagement.BAL;
using EmployeeManagement.Interfaces.EmployeeInterfaces;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeManagement.Controllers
{
    [Authorize]
    [Route("api/")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class HomeController : ControllerBase
    {
        public IEmployeeManager _employeeManager { get; set; }

        public HomeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet]
        [Route("GetUserDetails/UserName")]
        public IActionResult GetUserDetails(string username)
        {
            var EmpDetails = _employeeManager.GetEmployeeDetails(username);
            return Ok(EmpDetails);
        }

        [HttpGet]
        [Route("GetEmployeeWorkDetails/EmpId")]
        public IActionResult GetEmployeeWorkDetails(int EmpId)
        {
            var EmpWorkDetails = _employeeManager.GetEmployeeWorkDetails(EmpId);
            return Ok(EmpWorkDetails);
        }

    }
}
