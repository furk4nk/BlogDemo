using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetList();
        List<A> GetList<A>() where A : class;
        List<T> GetList(Expression<Func<T, bool>> filter);
        List<A> GetList<A>(Expression<Func<A,bool>> filter) where A : class;
        bool Insert(T t);
        bool Insert<A>(A model) where A : class;
        bool Update(T t);
        bool Update<A>(A model) where A : class;
        bool Delete(T t);
        bool Delete<A>(A model)where A : class;
        T GetById(int ID);
        A GetById<A>(int ID) where A : class;
        int GetCount(Expression<Func<T, bool>> filter);
        int GetCount<A>(Expression<Func<A, bool>> filter) where A : class;

    }
}
