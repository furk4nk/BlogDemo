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
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        T GetById(int ID);
        int GetCount(Expression<Func<T, bool>> filter);
        List<T> GetList(Expression<Func<T,bool>> filter);
    }
}
