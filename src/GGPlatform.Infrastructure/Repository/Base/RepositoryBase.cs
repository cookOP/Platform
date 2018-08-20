using GGPlatform.Infrastructure.Data;
using GGPlatoform.Domain.Interface;
using Microsoft.EntityFrameworkCore;
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
            _context.Remove(model);
            _context.SaveChanges();
        }

      
        public IQueryable<T> GetAll()
        {
         return _context.Set<T>();
            
        }

        public List<T> GetAllList()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetAllList(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public  async Task<List<T>> GetAllListAsync()
        {
            return await Task.FromResult(_context.Set<T>().ToList());
        }

        public T GetById(object id)
        {
            return _context.Set<T>().SingleOrDefault(a => a.Equals(id));
        }

        public void Insert(T model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void Update(T model)
        {
            _context.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool isDispose)
        {
            if (!isDispose) return;
        }
        ~RepositoryBase()
        {
            Dispose(false);
        }
    }
}
