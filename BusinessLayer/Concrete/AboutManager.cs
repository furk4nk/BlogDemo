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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _AboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _AboutDal = aboutDal;
        }

        #region Async
        public Task<About> TGetByIdAsync(int ID)
        {
            return TGetByIdAsync<About>(ID);
        }

        public Task<A> TGetByIdAsync<A>(int ID) where A : class
        {
            return _AboutDal.GetByIdAsync<A>(ID);
        }

        public Task<int> TGetCountAsync(Expression<Func<About, bool>> filter)
        {
            return TGetCountAsync<About>(filter);
        }

        public Task<int> TGetCountAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            return _AboutDal.GetCountAsync<A>(filter);
        }

        public Task<List<About>> TGetListAsync()
        {
            return TGetListAsync<About>();
        }

        public Task<List<A>> TGetListAsync<A>() where A : class
        {
            return _AboutDal.GetListAsync<A>();
        }

        public Task<List<About>> TGetListAsync(Expression<Func<About, bool>> filter)
        {
            return TGetListAsync<About>(filter);
        }

        public Task<List<A>> TGetListAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            return _AboutDal.GetListAsync<A>(filter);
        }

        public Task TInsertAsync(About t)
        {
            return TInsertAsync<About>(t);
        }

        public Task TInsertAsync<A>(A model) where A : class
        {
            return _AboutDal.InsertAsync<A>(model);
        }

        public Task TInsertRangeAsync(List<About> t)
        {
            return _AboutDal.InsertRangeAsync(t);
        }
        #endregion

        #region Sync
        public void TDelete(About t)
        {
            _AboutDal.Delete(t);
        }

        public void TDeleteRange(List<About> t)
        {
            _AboutDal.DeleteRange(t);
        }

        public About TGetById(int ID)
        {
            return _AboutDal.GetById(ID);
        }

        public int TGetCount(Expression<Func<About, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<About> TGetList()
        {
            return _AboutDal.GetList();
        }

		public List<About> TGetList(Expression<Func<About, bool>> filter)
		{
			return _AboutDal.GetList(filter);
		}

		public void TInsert(About t)
        {
            _AboutDal.Insert(t);
        }

        public void TInsertRange(List<About> t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About t)
        {
            _AboutDal.Update(t);
        }

        public void TUpdateRange(List<About> t)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
