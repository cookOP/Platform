using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GGPlatform.Application.IService;
using GGPlatform.WebAPI.Model;
using GGPlatoform.Domain.Entity.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GGPlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HomeController : ControllerBase
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] Users usersModel)
        {
            ReusltData resultData = new ReusltData();
            var result = _userService.GetAll().Where(a => a.UserName == usersModel.UserName && a.Password == usersModel.Password);
            if (result.Count() == 0 || result == null)
            {
                resultData.State = Enum.Status.Fail.ToString();
                resultData.Msg = "账号或者密码错误！";
                return Ok(resultData);
            }
            else
            {
                resultData.State = Enum.Status.Succeed.ToString();
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@123456"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                var obj = new
                {
                    access_token = tokenString
                    ,
                    state = "Succeed"

                };
                return Ok(obj); ;
            }
        }
    }
}