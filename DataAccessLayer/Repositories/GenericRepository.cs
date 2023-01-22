﻿using DataAccessLayer.Abstract;
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

		public void Insert(T t)
        {
            using Context c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using Context c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
    }
}
