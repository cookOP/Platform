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
            _user.Delete(model);
        }

        public IQueryable<Users> GetAll()
        {
            return _user.GetAll();
        }

        public List<Users> GetAllList()
        {
            return _user.GetAllList();
        }

        public List<Users> GetAllList(Expression<Func<Users, bool>> predicate)
        {
            return _user.GetAllList(predicate);
        }

        public async Task<List<Users>> GetAllListAsync()
        {
            return await _user.GetAllListAsync();
        }

        public Users GetById(object id)
        {
            return _user.GetById(id);
        }

        public void Insert(Users model)
        {
            _user.Insert(model);
        }

        public void Update(Users model)
        {
            _user.Update(model);
        }
    }
}
