using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlogApıDemo.DataAccess.Abstract
{
    public interface IGenericRepo<TEntity> where TEntity : class
    {
        DbSet<TEntity> GetAll();
        void Insert(TEntity t);
        void Delete(TEntity t);
        void Update(TEntity t);
        TEntity GetByID(int ID);

    }
}
