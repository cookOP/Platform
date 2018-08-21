 using GGPlatform.Infrastructure.Data;
using GGPlatoform.Domain.Entity.User;
using GGPlatoform.Domain.Interface;

namespace GGPlatform.Infrastructure.Repository
{
    public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        public UserRepository(GGPatlformContext context) : base(context)
        {
        }
    }
}
