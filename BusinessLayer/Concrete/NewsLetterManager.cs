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
	public class NewsLetterManager : INewsLetterService
	{
		INewsLetterDal _newsLetterDal;

		public NewsLetterManager(INewsLetterDal newsLetterDal)
		{
			_newsLetterDal = newsLetterDal;
		}
        #region Async
        public Task<NewsLetter> TGetByIdAsync(int ID)
        {
            return TGetByIdAsync<NewsLetter>(ID);
        }

        public Task<A> TGetByIdAsync<A>(int ID) where A : class
        {
            return _newsLetterDal.GetByIdAsync<A>(ID);
        }

        public Task<int> TGetCountAsync(Expression<Func<NewsLetter, bool>> filter)
        {
            return TGetCountAsync<NewsLetter>(filter);
        }

        public Task<int> TGetCountAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            return _newsLetterDal.GetCountAsync<A>(filter);
        }

        public Task<List<NewsLetter>> TGetListAsync()
        {
            return TGetListAsync<NewsLetter>();
        }

        public Task<List<A>> TGetListAsync<A>() where A : class
        {
            return _newsLetterDal.GetListAsync<A>();
        }

        public Task<List<NewsLetter>> TGetListAsync(Expression<Func<NewsLetter, bool>> filter)
        {
            return TGetListAsync<NewsLetter>(filter);
        }

        public Task<List<A>> TGetListAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            return _newsLetterDal.GetListAsync<A>(filter);
        }

        public Task TInsertAsync(NewsLetter t)
        {
            return TInsertAsync<NewsLetter>(t);
        }

        public Task TInsertAsync<A>(A model) where A : class
        {
            return _newsLetterDal.InsertAsync<A>(model);
        }

        public Task TInsertRangeAsync(List<NewsLetter> t)
        {
            return _newsLetterDal.InsertRangeAsync(t);
        }
#endregion
        public void TDelete(NewsLetter t)
		{
			throw new NotImplementedException();
		}

        public void TDeleteRange(List<NewsLetter> t)
        {
            throw new NotImplementedException();
        }

        public NewsLetter TGetById(int ID)
		{
			throw new NotImplementedException();
		}

        public int TGetCount(Expression<Func<NewsLetter, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<NewsLetter> TGetList()
		{
			throw new NotImplementedException();
		}

		public List<NewsLetter> TGetList(Expression<Func<NewsLetter, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public void TInsert(NewsLetter t)
		{
			_newsLetterDal.Insert(t);
		}

        public void TInsertRange(List<NewsLetter> t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(NewsLetter t)
		{
			throw new NotImplementedException();
		}

        public void TUpdateRange(List<NewsLetter> t)
        {
            throw new NotImplementedException();
        }
    }
}
