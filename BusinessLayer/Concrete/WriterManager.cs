using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class WriterManager : IWriterService
	{
		private readonly IWriterDal _writerDal;
        #region Async
        public WriterManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

        public Task<Writer> TGetByIdAsync(int ID)
        {
            return TGetByIdAsync<Writer>(ID);   
        }

        public Task<A> TGetByIdAsync<A>(int ID) where A : class
        {
            return _writerDal.GetByIdAsync<A>(ID);
        }
        public Task<int> TGetCountAsync(Expression<Func<Writer, bool>> filter)
        {
            return TGetCountAsync<Writer>(filter);
        }

        public Task<int> TGetCountAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            return _writerDal.GetCountAsync<A>(filter);
        }
        public Task<List<Writer>> TGetListAsync()
        {
            return TGetListAsync<Writer>();
        }

        public Task<List<A>> TGetListAsync<A>() where A : class
        {
            return _writerDal.GetListAsync<A>();
        }

        public Task<List<Writer>> TGetListAsync(Expression<Func<Writer, bool>> filter)
        {
            return TGetListAsync<Writer>(filter);
        }

        public Task<List<A>> TGetListAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            return _writerDal.GetListAsync<A>(filter);
        }
        public Task TInsertAsync(Writer t)
        {
             return TInsertAsync<Writer>(t);
        }

        public Task TInsertAsync<A>(A model) where A : class
        {
            return _writerDal.InsertAsync<A>(model);
        }
        public Task TInsertRangeAsync(List<Writer> t)
        {
            return _writerDal.InsertRangeAsync(t);
        }
        #endregion

        #region Sync
        public bool IsWriterControl(string mail)
        {
            return _writerDal.IsWriterControl(mail);
        }

        public void TDelete(Writer t)
		{
			_writerDal.Delete(t);
		}

        public void TDeleteRange(List<Writer> t)
        {
            _writerDal.DeleteRange(t);
        }

        public Writer TGetById(int ID)
		{
			return _writerDal.GetById(ID);
		}

        public int TGetCount(Expression<Func<Writer, bool>> filter)
        {
            return _writerDal.GetCount(filter);	
        }

        public List<Writer> TGetList()
		{
			return _writerDal.GetList();
		}

		public List<Writer> TGetList(Expression<Func<Writer, bool>> filter)
		{
			return _writerDal.GetList(filter);
		}

        public void TInsert(Writer t)
		{
			_writerDal.Insert(t);
		}

        public void TInsertRange(List<Writer> t)
        {
            _writerDal.InsertRange(t);
        }

        public void TUpdate(Writer t)
		{
			_writerDal.Update(t);
		}

        public void TUpdateRange(List<Writer> t)
        {
            _writerDal.UpdateRange(t);
        }
        #endregion
    }
}
