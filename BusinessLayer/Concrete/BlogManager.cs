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
	}
}
