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
		public List<Blog> GetBlogInListAll()
		{
			using (Context c = new Context())
			{
				return c.blogs.Include(x => x.category).ToList();
			}

		}
	}
}
