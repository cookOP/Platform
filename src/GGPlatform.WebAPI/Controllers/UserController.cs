using System;
using System.Collections.Generic;
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
        public IActionResult AddUser([FromBody]Users users)
        {
            if (string.IsNullOrEmpty(users.UserName)) return Ok("用户名不能为空!");
            if (string.IsNullOrEmpty(users.Password)) return Ok("密码不能为空!");           
            users.LastUpdateTime = DateTime.Now;
            users.CreateTime = DateTime.Now;
            _userService.Insert(users);
            var reusltData = new ResultData
            {
                State = Enum.Status.Succeed.ToString(),
                Data = null
            };
            return Ok(reusltData);
        }

        [HttpGet]
        [Route("GetAllUser")]
        // [Authorize]        
        public IActionResult GetAllUser()
        {
            var reusltData = new ResultData
            {
                State = Enum.Status.Succeed.ToString(),
                Data = _userService.GetAllList()
            };
            return Ok(reusltData);
        }


    }
}