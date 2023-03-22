using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWorkDal : IUnitOfWorkDal
    {
        private readonly Context _context;
        public UnitOfWorkDal(Context context)
        {
            _context=context;
            AboutDal = new EfAboutDal(_context);
            adminDal = new EfAdminDal(_context);
            BlogDal = new EfBlogDal(_context);
            categoryDal = new EfCategoryDal(_context);
            commentDal = new EfCommentDal(_context);
            contactDal = new EfContactDal(_context);
            message2Dal =new EfMessage2Dal(_context);
            newsLetterDal = new EfNewsLetterDal(_context);
            notificationDal = new EfNotificationDal(_context);
            writerDal = new EfWriterDal(_context);
        }

        public IAboutDal AboutDal { get; private set; }
        public IAdminDal adminDal { get; private set; }
        public IBlogDal BlogDal { get; private set; }
        public ICategoryDal categoryDal { get; private set; }
        public ICommentDal commentDal { get; private set; }
        public IContactDal contactDal { get; private set; }
        public IMessage2Dal message2Dal { get; private set; }
        public INewsLetterDal newsLetterDal { get; private set; }
        public INotificationDal notificationDal { get; private set; }
        public IWriterDal writerDal { get; private set; }


        private bool _disposedValue = false; // To detect redundant calls  
        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            if (disposing)
            {
                //dispose managed state (managed objects).  
                _context.Dispose();
            }

            // free unmanaged resources (unmanaged objects) and override a finalizer below.  
            // set large fields to null.  
            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
			GC.SuppressFinalize(this);
		}

        public bool SaveChange()
        {
            bool returnValue = true;
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    returnValue = false;
                    dbContextTransaction.Rollback();
                }
            }                
            return returnValue;
        }
    }
}
