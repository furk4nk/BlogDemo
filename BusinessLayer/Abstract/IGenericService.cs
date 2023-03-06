using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        List<T> TGetList();
        void TDelete(T t);
        void TInsert(T t);
        void TUpdate(T t);
        T TGetById(int ID);
        int TGetCount(Expression<Func<T,bool>> filter = null);
        List<T> TGetList(Expression<Func<T,bool>>filter);

    }
}
