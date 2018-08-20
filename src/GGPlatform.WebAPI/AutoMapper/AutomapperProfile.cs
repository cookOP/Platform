using AutoMapper;
using GGPlatform.WebAPI.ModelDto;
using GGPlatoform.Domain.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GGPlatform.WebAPI.AutoMapper
{
    public class AutomapperProfile : Profile/// , IProfile
    {
        public AutomapperProfile()
        {
            CreateMap<Users, UserDto>();
            CreateMap<UserDto, Users>();
        }
    }
}
