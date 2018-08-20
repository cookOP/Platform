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
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GGPlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ILog log;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public HomeController(IUserService userService, IConfiguration configuration)
        {
            log = LogManager.GetLogger(Startup.repository.Name, typeof(HomeController));
            _userService = userService;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] Users usersModel)
        {
            ResultData resultData = new ResultData();
            try
            {
               
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
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Issuer"],
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    var obj = new
                    {
                        access_token = tokenString
                        ,
                        state = Enum.Status.Succeed.ToString()
                    };
                    log.Info("登陆成功,用户名：" + usersModel.UserName);
                    return Ok(obj); ;
                }
            }
            catch (Exception ex)
            {
                log.Error("登陆异常信息："+ex);
                resultData.State = Enum.Status.Fail.ToString();
                resultData.Msg = "异常！";
                return Ok(resultData);
                
            }
           
        }
    }
}