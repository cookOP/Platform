using GGPlatform.Infrastructure.Data;
using GGPlatoform.Domain.Entity.User;
using GGPlatoform.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGPlatform.Infrastructure.Repository
{
    public class AuthorityManagementRepository : RepositoryBase<Users>, IAuthorityManagement
    {
        public AuthorityManagementRepository(GGPatlformContext context) : base(context)
        {
        }
    }
}
