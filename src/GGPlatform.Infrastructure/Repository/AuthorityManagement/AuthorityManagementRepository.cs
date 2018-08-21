using GGPlatform.Infrastructure.Data;
using GGPlatform.Infrastructure.Repository;
using GGPlatoform.Domain.Entity;
using GGPlatoform.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGPlatform.Infrastructure
{
    public class AuthorityManagementRepository : RepositoryBase<Menu>, IAuthorityManagementRepository
    {
        public AuthorityManagementRepository(GGPatlformContext context) : base(context)
        {
        }
    }
}
