using System;
using System.Linq;
using AutoMapper;
using GGPlatform.Application.IService;
using GGPlatform.WebAPI.Model;
using GGPlatform.WebAPI.ModelDto;
using GGPlatoform.Domain.Entity.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GGPlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UserController(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [Route("AddUser")]
        [Authorize]
        public IActionResult AddUser([FromBody]Users users) {
            if (string.IsNullOrEmpty(users.UserName)) return Ok("用户名不能为空!");
            if (string.IsNullOrEmpty(users.Password)) return Ok("密码不能为空!");
            //users.ID = Guid.NewGuid();
            users.LastUpdateTime = DateTime.Now;
            users.CreateTime = DateTime.Now;
            _userService.Insert(users);
            ReusltData reusltData = new ReusltData();          
            reusltData.State = Enum.Status.Succeed.ToString();
            reusltData.Data =null;
            return Ok(reusltData);
        }

        [HttpGet]
        [Route("GetAllUser")] 
        [Authorize]        
        public IActionResult GetAllUser()
        {
            ReusltData reusltData = new ReusltData();
            reusltData.State = Enum.Status.Succeed.ToString();           
            reusltData.Data = Mapper.Map<UserDto>(_userService.GetAll());
            return Ok(reusltData);
        }
       
        
    }
}