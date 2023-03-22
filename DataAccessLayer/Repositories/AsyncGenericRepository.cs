using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AsyncGenericRepository<T> : IAsyncGenericDal<T> where T :class
    {
        private readonly Context _context;
        public AsyncGenericRepository(Context context)
        {
            _context=context;
        }

        public async Task<T> GetByIdAsync(int ID)
        {
            return await GetByIdAsync<T>(ID);
        }

		public async Task<A> GetByIdAsync<A>(int ID) where A : class  => await _context.Set<A>().FindAsync(ID);
		

		public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter)
        {
            return await GetCountAsync<T>(filter);
        }

        public async Task<int> GetCountAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            if(filter == null)
                return await _context.Set<A>().AsNoTracking().CountAsync();
            return await _context.Set<A>().AsNoTracking().Where(filter).CountAsync();
        }

        public Task<List<T>> GetListAsync() => GetListAsync<T>();
        

        public Task<List<A>> GetListAsync<A>() where A : class
        {
            return _context.Set<A>().AsNoTracking().ToListAsync();
        }

        public Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter)
        {
            return GetListAsync<T>(filter);
        }

        public Task<List<A>> GetListAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            return _context.Set<A>().AsNoTracking().Where(filter).ToListAsync();
        }

        public async Task InsertAsync(T t)
        {
            await InsertAsync<T>(t);
        }

        public async Task InsertAsync<A>(A model) where A : class
        {
            await _context.Set<A>().AddAsync(model);
        }

        public async Task InsertRangeAsync(List<T> t)
        {
            await _context.Set<T>().AddRangeAsync(t);
        }
    }
}
