using BlogApıDemo.DataAccess.Abstract;
using BlogApıDemo.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlogApıDemo.DataAccess.GenericRepo
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        protected readonly Context _context;

        public GenericRepo(Context context)
        {
            _context=context;
        }

        public void Delete(TEntity t)
        {
            _context.Set<TEntity>().Remove(t);
            _context.SaveChanges();
        }

        public DbSet<TEntity> GetAll() => _context.Set<TEntity>();

        public TEntity GetByID(int ID) => _context.Set<TEntity>().Find(ID);

        public void Insert(TEntity t)
        {
            _context.Set<TEntity>().Add(t);
            _context.SaveChanges();
        }

        public void Update(TEntity t)
        {
            _context.Set<TEntity>().Update(t);
            _context.SaveChanges();
        }
    }
}
