using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
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

        public EfBlogDal(Context c) : base(c)
        {
        }

        [NonAction]
        public List<Blog> GetBlogInListAll()
        {
            return _context.blogs.Include(x => x.category).ToList();
        }
        [NonAction]
        public List<Blog> GetLastBlogs(int count = 1)
        {
            return _context.Set<Blog>().Where(y => y.BlogStatus==true).OrderByDescending(x => x.BlogCreateDate).Take(count).ToList();
        }
        [NonAction]
        public List<Blog> GetLastBlogsWithCategoryAndWriter(int count)
        {
            return _context.Set<Blog>().Where(y => y.BlogStatus == true).OrderByDescending(x => x.BlogCreateDate)
                .Take(count)
                .Include(x => x.category)
                .Include(x => x.writer).ToList();
        }
        [NonAction]
        public int WriterBlogCount(int id)
        {
            return _context.Set<Blog>().Where(x => x.WriterID == id).Count();
        }
        [NonAction]
        public List<Blog> GetRecentBlogListByWriter(int id, int count)
        {
            return _context.Set<Blog>().Where(x => x.WriterID==id)
                .OrderByDescending(x => x.BlogCreateDate)
                .Take(count).ToList();
        }
        [NonAction]
        public List<Blog> GetBlogListByWriterWithCategory(int id)
        {
            return _context.Set<Blog>().Where(x => x.WriterID == id).Include(y => y.category).ToList();
        }
        [NonAction]
        public List<Blog> GetBlogListByTrue()
        {
            return _context.Set<Blog>().Where(x => x.BlogStatus == true).Include(y => y.category).ToList();
        }
    }
}
