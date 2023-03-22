using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : AsyncGenericRepository<T> , IGenericDal<T> where T : class
    {
        protected readonly Context _context;

        public GenericRepository(Context context) : base(context)
        {
            this._context=context;
        }
        #region sync
        [NonAction]
        public void Delete(T t)
        {
            Delete<T>(t);
        }
        [NonAction]
        public void Delete<A>(A model) where A : class
        {
            _context.Set<A>().Remove(model);
        }
        [NonAction]
        public void DeleteRange(List<T> t)
        {
            _context.Set<T>().RemoveRange(t);
        }

        [NonAction]
        public T GetById(int ID)
        {
            return GetById<T>(ID);
        }
        [NonAction]
        public A GetById<A>(int ID) where A : class
        {
            return _context.Set<A>().Find(ID);
        }
        [NonAction]
        public int GetCount(Expression<Func<T, bool>> filter = null)
        {
            return GetCount<T>(filter);
        }
        [NonAction]
        public int GetCount<A>(Expression<Func<A, bool>> filter) where A : class
        {
            if (filter == null)
                return _context.Set<A>().AsNoTracking().Count();
            return _context.Set<A>().AsNoTracking().Count(filter);
        }
        [NonAction]
        public List<T> GetList()
        {
            return GetList<T>();
        }
        [NonAction]
        public List<T> GetList(Expression<Func<T, bool>> filter)
        {
            return GetList<T>(filter);
        }
        [NonAction]
        public List<A> GetList<A>() where A : class
        {
            return _context.Set<A>().AsNoTracking().ToList();
        }
        [NonAction]
        public List<A> GetList<A>(Expression<Func<A, bool>> filter) where A : class
        {
            return _context.Set<A>().AsNoTracking().Where(filter).ToList();
        }
        [NonAction]

        public virtual void Insert(T t)
        {
            Insert<T>(t);
        }
        [NonAction]
        public void Insert<A>(A model) where A : class
        {
            if (model is not null)
            {
                _context.Set<A>().Add(model);
            }
            else
            {
                throw new Exception("Kullanıcı Eklenemedi Kullanıcı Boş");
            }
            
        }
        [NonAction]
        public void InsertRange(List<T> t)
        {
            _context.Set<T>().AddRange(t);
        }

        [NonAction]
        public virtual void Update(T t)
        {
            Update<T>(t);
        }
        [NonAction]
        public void Update<A>(A model) where A : class
        {
            if (model is not null)
            {
                _context.Set<A>().Update(model);
            }
            else
            {
                throw new Exception("Kullanıcı Güncellenemedi : Kullanıcı Boş");
            }

        }
        [NonAction]
        public void UpdateRange(List<T> t)
        {
            _context.Set<T>().UpdateRange(t);
        }
        #endregion
    }
}
