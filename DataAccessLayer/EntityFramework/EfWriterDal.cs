using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfWriterDal : GenericRepository<Writer>, IWriterDal
	{
		public void Insert(Writer writer, string password)
		{
			writer.WriterPassword = BCrypt.Net.BCrypt.HashPassword(password);
			using (Context c = new Context())
			{
				c.Add(writer);
				c.SaveChanges();
			};
		}
	}
}
