using AutoMapper;
using GGPlatform.Application.IService;
using GGPlatform.Application.ModelDto;
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
        private readonly IUserRepository _user;
        private readonly IMapper _mapper;
        public UserService(IUserRepository user,IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
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

        public List<UsersDto> GetAllList()
        {
            var result = _mapper.Map<List<UsersDto>> (_user.GetAllList());
            return result;
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
