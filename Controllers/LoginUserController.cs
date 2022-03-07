using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeeManagement.Manager;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using EmployeeManagement.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class LoginUserController : ControllerBase
    {
        public ILoginManager _loginManager { get; set; }

        public LoginUserController(ILoginManager loginManager)
        {
            _loginManager = loginManager;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }
            else
            {
                var loginDetails =  _loginManager.ValidateUser(user);
                if (loginDetails != null )
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisismySecretKey"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "https://localhost:5001/",
                        audience: "https://localhost:5001/",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new { Status="OK",
                                    Token = tokenString ,
                                    UserName= loginDetails.UserName, 
                                    UserId= loginDetails.UserId,
                                    EmpId = loginDetails.EmpId
                    });
                }
                else
                {
                    // return Unauthorized();
                    return Ok(new { Status = "Failed"});
                }
            }

        }
    }
}
