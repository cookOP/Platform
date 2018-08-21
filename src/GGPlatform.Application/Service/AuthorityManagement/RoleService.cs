using GGPlatform.Application.IService;
using GGPlatoform.Domain.Entity;
using GGPlatoform.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GGPlatform.Application.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleService;
        public RoleService(IRoleRepository roleService)
        {
            _roleService = roleService;
        }
        public IQueryable<Role> Table => _roleService.Table;

        public void Delete(Role model)
        {
            _roleService.Delete(model);
        }

        public IQueryable<Role> GetAll()
        {
            return _roleService.GetAll();
        }

        public List<Role> GetAllList()
        {
            return _roleService.GetAllList();
        }

        public List<Role> GetAllList(Expression<Func<Role, bool>> predicate)
        {
            return _roleService.GetAllList(predicate);
        }

        public async Task<List<Role>> GetAllListAsync()
        {
            return await _roleService.GetAllListAsync();
        }

        public Role GetById(object id)
        {
            return _roleService.GetById(id);
        }

        public void Insert(Role model)
        {
            _roleService.Insert(model);
        }

        public void Update(Role model)
        {
            _roleService.Update(model);
        }
    }
}
