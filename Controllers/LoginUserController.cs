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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class LoginUserController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            LoginManager loginManager = new LoginManager();
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }
            else
            {
               var loginDetails =  loginManager.ValidateUser(user);
                if (loginDetails != null )
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        //issuer: "http://localhost:5000",
                        //audience: "http://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new { Status="OK",
                                    Token = tokenString ,
                                    UserName= loginDetails.UserName, 
                                    UserId= loginDetails.UserId });
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
