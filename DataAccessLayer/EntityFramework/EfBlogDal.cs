using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfBlogDal : GenericRepository<Blog>, IBlogDal
	{
		Context c = new Context();
        public int? BlogCount => c.Set<Blog>().Count();

        public List<Blog> GetBlogInListAll()
		{
			using (Context c = new Context())
			{
				return c.blogs.Include(x => x.category).ToList();
			}
		}
		public List<Blog> GetLastBlogs(int count=1)
		{
			using (Context c = new Context())
			{
				return c.Set<Blog>().OrderByDescending(x => x.BlogCreateDate).Take(count).ToList();
			}
		}

        public List<Blog> GetLastBlogsWithCategoryAndWriter(int count)
        {
			using (Context c = new Context())
			{
				return c.Set<Blog>().OrderByDescending(x => x.BlogCreateDate)
					.Take(count)
					.Include(x => x.category)
					.Include(x => x.writer).ToList();
			}
        }

        public int WriterBlogCount(int id)
        {
			using (Context c = new Context())
			{
				return c.Set<Blog>().Where(x => x.WriterID == id).Count();
			}
        }
		public List<Blog> GetRecentBlogListByWriter(int id,int count)
		{
			using (Context c = new Context())
			{
				return c.Set<Blog>().Where(x => x.WriterID==id)
					.OrderByDescending(x => x.BlogCreateDate)
					.Take(count).ToList();
			}	
		}
    }
}
