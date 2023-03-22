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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Task<Category> TGetByIdAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<A> TGetByIdAsync<A>(int ID) where A : class
        {
            throw new NotImplementedException();
        }

        public Task<int> TGetCountAsync(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<int> TGetCountAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<A>> TGetListAsync<A>() where A : class
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> TGetListAsync(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<A>> TGetListAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync(Category t)
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync<A>(A model) where A : class
        {
            throw new NotImplementedException();
        }

        public Task TInsertRangeAsync(List<Category> t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void TDeleteRange(List<Category> t)
        {
            throw new NotImplementedException();
        }

        public Category TGetById(int ID)
        {
            return _categoryDal.GetById(ID);
        }

        public int TGetCount(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetCount(filter);
        }

        public List<Category> TGetList()
        {
            return _categoryDal.GetList();
        }

		public List<Category> TGetList(Expression<Func<Category, bool>> filter)
		{
			return _categoryDal.GetList(filter);
		}

		public void TInsert(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TInsertRange(List<Category> t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }

        public void TUpdateRange(List<Category> t)
        {
            throw new NotImplementedException();
        }
    }
}
