using GGPlatform.Application.IService;
using GGPlatoform.Domain.Entity.User;
using GGPlatoform.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GGPlatform.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUser _user;
        public UserService(IUser user)
        {
            _user = user;
        }
        public IQueryable<Users> Table => _user.Table;

        public void Delete(Users model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Users> GetAll()
        {
            return _user.GetAll();
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
            _user.Insert(model);
        }

        public void Update(Users model)
        {
            throw new NotImplementedException();
        }
    }
}
