using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
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
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        protected readonly Context _context;

        public GenericRepository(Context c)
        {
            this._context=c;
        }

        [NonAction]
        public bool Delete(T t)
        {
            return Delete<T>(t);
        }
        [NonAction]
        public bool Delete<A>(A model) where A : class
        {
            _context.Set<A>().Remove(model);
            int ctrl = _context.SaveChanges();
            return CtrlValue(ctrl);
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
                return _context.Set<A>().Count();
            return _context.Set<A>().Count(filter);
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
            return _context.Set<A>().ToList();
        }
        [NonAction]
        public List<A> GetList<A>(Expression<Func<A, bool>> filter) where A : class
        {
            return _context.Set<A>().Where(filter).ToList();
        }
        [NonAction]
        public virtual bool Insert(T t)
        {
            return Insert<T>(t);
        }
        [NonAction]
        public bool Insert<A>(A model) where A : class
        {
            int ctrl = 0; 
            if (model is not null)
            {
                _context.Set<A>().Add(model);
                ctrl = _context.SaveChanges();
                return CtrlValue(ctrl);
            }
            else
            {
                throw new Exception("Kullanıcı Eklenemedi Kullanıcı Boş");
            }
            
        }
        [NonAction]
        public virtual bool Update(T t)
        {
            return Update<T>(t);
        }
        [NonAction]
        public bool Update<A>(A model) where A : class
        {
            if (model is not null)
            {
                _context.Set<A>().Update(model);
                int ctrl = _context.SaveChanges();
                return CtrlValue(ctrl);
            }
            else
            {
                throw new Exception("Kullanıcı Güncellenemedi : Kullanıcı Boş");
            }

        }
        protected bool CtrlValue(int ctrl = 0)
        { 
            if (ctrl is 0)
                return false;
            return true;
        }
    }
}
