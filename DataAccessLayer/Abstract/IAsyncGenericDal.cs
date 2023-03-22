using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAsyncGenericDal<T> where T : class
    {
        Task<List<T>> GetListAsync();
        Task<List<A>> GetListAsync<A>() where A : class;
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter);
        Task<List<A>> GetListAsync<A>(Expression<Func<A, bool>> filter) where A : class;
        Task InsertAsync(T t);
        Task InsertRangeAsync(List<T> t);
        Task InsertAsync<A>(A model) where A : class;
        Task<T> GetByIdAsync(int ID);
        Task<A> GetByIdAsync<A>(int ID) where A : class;
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter);
        Task<int> GetCountAsync<A>(Expression<Func<A, bool>> filter) where A : class;
    }
}
    