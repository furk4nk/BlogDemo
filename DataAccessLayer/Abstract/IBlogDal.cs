using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IBlogDal : IGenericDal<Blog>
	{
		List<Blog> GetBlogInListAll();
		List<Blog> GetLastBlogs(int count);
		List<Blog> GetLastBlogsWithCategoryAndWriter(int count);
		int? BlogCount { get; }
		int WriterBlogCount(int id);
		List<Blog> GetRecentBlogListByWriter(int id,int count);
    }
}
	