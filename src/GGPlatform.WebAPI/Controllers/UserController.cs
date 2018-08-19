using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GGPlatform.Application.IService;
using GGPlatform.WebAPI.Model;
using GGPlatoform.Domain.Entity.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GGPlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody]Users users) {
            if (string.IsNullOrEmpty(users.UserName)) return Ok("用户名不能为空!");
            if (string.IsNullOrEmpty(users.Password)) return Ok("密码不能为空!");
            users.ID = Guid.NewGuid();
            users.LastUpdateTime = DateTime.Now;
            users.CreateTime = DateTime.Now;
            _userService.Insert(users);
            return Ok("成功");
        }
        [HttpGet]
        [Route("GetUserAll")] 
        [Authorize]
        public IActionResult GetUser()
        {
            ReusltData reusltData = new ReusltData();
            reusltData.State = Enum.Status.Succeed.ToString();
            reusltData.Data = _userService.GetAll();
            return Ok(reusltData);
        }
       
        
    }
}