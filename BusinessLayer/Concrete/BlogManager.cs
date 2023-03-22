using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
		public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

		public List<Blog> TGetBlogInListAll()
		{
            return _blogDal.GetBlogInListAll();
		}

		public Blog TGetById(int ID)
        {
            return _blogDal.GetById(ID);
        }

        public List<Blog> TGetList()
        {
            return _blogDal.GetList();
        }

		public List<Blog> TGetList(Expression<Func<Blog, bool>> filter)
		{
			return _blogDal.GetList(filter);
		}

		public List<Blog> TGetBlogListByWriter(int id)
		{
            return _blogDal.GetList(x=>x.WriterID==id);
		}

		public void TInsert(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

		public List<Blog> TGetLastBlogs(int count)
		{
            return _blogDal.GetLastBlogs(count);
		}

        public List<Blog> TGetLastBlogsWithCategoryAndWriter(int count)
        {
            return _blogDal.GetLastBlogsWithCategoryAndWriter(count);
        }

        public int TWriterBlogCount(int id)
        {
            return _blogDal.WriterBlogCount(id);
        }

        public List<Blog> TGetRecentBlogListByWriter(int id, int count)
        {
            return _blogDal.GetRecentBlogListByWriter(id, count);
        }

        public List<Blog> TGetBlogListByWriterWithCategory(int id)
        {
            return _blogDal.GetBlogListByWriterWithCategory(id);
        }

        public List<Blog> TGetBlogListByTrue()
        {
            return _blogDal.GetBlogListByTrue(); 
        }

        public int TGetCount(Expression<Func<Blog, bool>> filter = null )
        {
            return _blogDal.GetCount(filter);
        }

        public void TDeleteRange(List<Blog> t)
        {
            throw new NotImplementedException();
        }

        public void TInsertRange(List<Blog> t)
        {
            throw new NotImplementedException();
        }

        public void TUpdateRange(List<Blog> t)
        {
            throw new NotImplementedException();
        }

        public Task<List<Blog>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<A>> TGetListAsync<A>() where A : class
        {
            throw new NotImplementedException();
        }

        public Task<List<Blog>> TGetListAsync(Expression<Func<Blog, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<A>> TGetListAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync(Blog t)
        {
            throw new NotImplementedException();
        }

        public Task TInsertRangeAsync(List<Blog> t)
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync<A>(A model) where A : class
        {
            throw new NotImplementedException();
        }

        public Task<Blog> TGetByIdAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<A> TGetByIdAsync<A>(int ID) where A : class
        {
            throw new NotImplementedException();
        }

        public Task<int> TGetCountAsync(Expression<Func<Blog, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<int> TGetCountAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            throw new NotImplementedException();
        }
    }
}
