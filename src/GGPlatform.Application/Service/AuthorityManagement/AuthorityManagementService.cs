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
   public class AuthorityManagementService : IAuthorityManagementService
    {
        private readonly IAuthorityManagementRepository _authorityManagement;
        public AuthorityManagementService(IAuthorityManagementRepository authorityManagement)
        {
            _authorityManagement = authorityManagement;
        }
        public IQueryable<Menu> Table => _authorityManagement.Table;

        public void Delete(Menu model)
        {
            _authorityManagement.Delete(model);
        }

        public IQueryable<Menu> GetAll()
        {
            return _authorityManagement.GetAll();
        }

        public List<Menu> GetAllList()
        {
            return _authorityManagement.GetAllList();
        }

        public List<Menu> GetAllList(Expression<Func<Menu, bool>> predicate)
        {
            return _authorityManagement.GetAllList(predicate);
        }

        public async Task<List<Menu>> GetAllListAsync()
        {
            return await _authorityManagement.GetAllListAsync();
        }

        public Menu GetById(object id)
        {
            return _authorityManagement.GetById(id);
        }

        public void Insert(Menu model)
        {
            _authorityManagement.Insert(model);
        }

        public void Update(Menu model)
        {
            _authorityManagement.Update(model);
        }
    }
}
