 using GGPlatform.Infrastructure.Data;
using GGPlatoform.Domain.Entity.User;
using GGPlatoform.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGPlatform.Infrastructure.Repository
{
    public class UserRepository : RepositoryBase<Users>, IUser
    {
        public UserRepository(GGPatlformContext context) : base(context)
        {
        }
    }
}
