using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using Context c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int ID)
        {
            using Context c = new Context();
            return c.Set<T>().Find(ID);
        }

        public int GetCount(Expression<Func<T, bool>> filter = null)
        {
            using Context c = new Context();
            if (filter ==null)
            {
                return c.Set<T>().Count();
            }
            return c.Set<T>().Count(filter);

        }

        public List<T> GetList()
        {
            using Context c = new Context();
            return c.Set<T>().ToList();
        }

		public List<T> GetList(Expression<Func<T, bool>> filter)
		{
			using Context c = new Context();
            return c.Set<T>().Where(filter).ToList();
		}

		public virtual void Insert(T t)
        {
            using Context c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public virtual void Update(T t)
        {
            using Context c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
    }
}
