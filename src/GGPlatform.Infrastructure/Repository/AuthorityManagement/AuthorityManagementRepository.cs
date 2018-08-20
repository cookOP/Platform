using GGPlatform.Infrastructure.Data;
using GGPlatoform.Domain.Entity;
using GGPlatoform.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGPlatform.Infrastructure.Repository
{
    public class AuthorityManagementRepository : RepositoryBase<Menu>, IAuthorityManagement
    {
        public AuthorityManagementRepository(GGPatlformContext context) : base(context)
        {
        }
    }
}
