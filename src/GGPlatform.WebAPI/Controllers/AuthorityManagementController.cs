﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GGPlatform.Application.IService;
using GGPlatform.Common.SnowflakeToTwitter;
using GGPlatform.WebAPI.Enum;
using GGPlatform.WebAPI.Model;
using GGPlatoform.Domain.Entity;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GGPlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorityManagementController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILog log;
        private readonly IAuthorityManagementService _authorityManagementService;
        public AuthorityManagementController(IAuthorityManagementService authorityManagementService, IMapper mapper)
        {
            _mapper = mapper;
            log = LogManager.GetLogger(Startup.repository.Name, typeof(AuthorityManagementController)); ;
            _authorityManagementService = authorityManagementService;
        }
        [Route("AddMenu")]
        [HttpPost]
       // [Authorize]
        public IActionResult AddMenu([FromBody] Menu  menu) {
            var resultData= new ResultData();
            try
            {
                menu.ID = Snowflake.Instance().GetId();
                menu.CreateTime = DateTime.Now;
                menu.LastUpdateTime = DateTime.Now;
                
                _authorityManagementService.Insert(menu);
                log.Info($"添加信息：，成功");               
                resultData.Data = menu.ID;
            }
            catch (Exception ex)
            {
                resultData.State = Status.Fail.ToString();
                resultData.Msg = "添加菜单失败！";
                log.Error($"添加菜单错误信息：{ex}");
                throw;
            }
            return Ok(resultData);
        }
    }
}