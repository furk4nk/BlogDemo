using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> : IAsyncGenericService<T> where T : class
    {
        List<T> TGetList();
        void TDelete(T t);
        void TInsert(T t);
        void TUpdate(T t);
        T TGetById(int ID);
        int TGetCount(Expression<Func<T,bool>> filter = null);
        List<T> TGetList(Expression<Func<T,bool>>filter);
        void TDeleteRange(List<T> t);
        void TInsertRange(List<T> t);
        void TUpdateRange(List<T> t);

    }
}
