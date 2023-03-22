using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAsyncGenericService<T> where T : class 
    {
        Task<List<T>> TGetListAsync();
        Task<List<A>> TGetListAsync<A>() where A : class;
        Task<List<T>> TGetListAsync(Expression<Func<T, bool>> filter);
        Task<List<A>> TGetListAsync<A>(Expression<Func<A, bool>> filter) where A : class;
        Task TInsertAsync(T t);
        Task TInsertRangeAsync(List<T> t);
        Task TInsertAsync<A>(A model) where A : class;
        Task<T> TGetByIdAsync(int ID);
        Task<A> TGetByIdAsync<A>(int ID) where A : class;
        Task<int> TGetCountAsync(Expression<Func<T, bool>> filter);
        Task<int> TGetCountAsync<A>(Expression<Func<A, bool>> filter) where A : class;
    }
}
