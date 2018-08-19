using GGPlatform.Infrastructure.Data;
using GGPlatoform.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GGPlatform.Infrastructure.Repository
{
    public  class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T:class
    {
        private readonly GGPatlformContext _context;
        public RepositoryBase(GGPatlformContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table
        {
            get
            {
                return _context.Set<T>();
            }
        }

        public void Delete(T model)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool isDispose) {
            if (!isDispose) return;
        }
        ~RepositoryBase() {
            Dispose(false);
        }
        public IQueryable<T> GetAll()
        {
         return _context.Set<T>();
            
        }

        public List<T> GetAllList()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAllList(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
