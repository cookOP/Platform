using AutoMapper;
using GGPlatform.Application.ModelDto;
using GGPlatform.WebAPI.ModelDto;
using GGPlatoform.Domain.Entity;
using GGPlatoform.Domain.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GGPlatform.WebAPI.AutoMapper
{
    public class AutomapperProfile : Profile , IProfile
    {
        public AutomapperProfile()
        {
            CreateMap<Users, UserDto>();
            CreateMap<UserDto, Users>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
            CreateMap<Users, UsersDto>();
            CreateMap<UsersDto, Users>();
        }
    }
}
