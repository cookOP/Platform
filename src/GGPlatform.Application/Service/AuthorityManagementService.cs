using GGPlatform.Application.IService;
using GGPlatoform.Domain.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GGPlatform.Application.Service
{
    class AuthorityManagementService : IAuthorityManagementService
    {
        public IQueryable<Users> Table => throw new NotImplementedException();

        public void Delete(Users model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Users> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Users> GetAllList()
        {
            throw new NotImplementedException();
        }

        public List<Users> GetAllList(Expression<Func<Users, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Users>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public Users GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Users model)
        {
            throw new NotImplementedException();
        }

        public void Update(Users model)
        {
            throw new NotImplementedException();
        }
    }
}
