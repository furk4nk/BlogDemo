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
		/// <summary>
		/// HASH algoritması ile şifreyi Hash ile gönderen metot
		/// </summary>
		/// <param name="writer">kullanıcı bilgileri</param>
		/// eklenecek kullanıcının verileri
		/// <param name="passord">kullanıcının hash ile gitmesi gereken verisi</param>
		/// eklenecek kullanıcının şifrelenmesi gereken kullanıcı şifresi
		public void Insert(Writer writer , string passord)
		{
			writer.WriterPassword = BCrypt.Net.BCrypt.HashPassword(passord);
			using (Context c = new Context())
			{
				c.Add(writer);
				c.SaveChanges();
			};
		}
	}
}
