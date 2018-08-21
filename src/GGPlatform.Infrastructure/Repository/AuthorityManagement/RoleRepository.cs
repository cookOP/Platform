using GGPlatform.Infrastructure.Data;
using GGPlatoform.Domain.Entity;
using GGPlatoform.Domain.Interface;

namespace GGPlatform.Infrastructure.Repository
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(GGPatlformContext context) : base(context)
        {
        }
    }
}
