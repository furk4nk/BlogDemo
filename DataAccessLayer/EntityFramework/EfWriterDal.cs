using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfWriterDal : GenericRepository<Writer>, IWriterDal
    {
        /// <summary>
        /// Gelen Writer İçin Password Proporties ini hash algoritması uygulayan function
        /// </summary>
        /// <param name="writer">Entity</param>
        public override void Insert(Writer writer)
        {
            if (writer !=null )
            {
                writer.WriterPassword = BCrypt.Net.BCrypt.HashPassword(writer.WriterPassword);
                using (Context c = new Context())
                {
                    c.Add(writer);
                    c.SaveChanges();
                };
            }

        }

        public bool IsWriterControl(string mail)
        {
            using (Context c = new Context())
            {
                return c.writers.Select(x => x.WriterMail).Contains(mail);
            }
        }

        /// <summary>
        /// Gelen Yazar için Password properties i Hash Algoritmasına girerek İşlem yapılır
        /// </summary>
        /// <param name="writer">Entity</param>
        public virtual void Update(Writer writer)
        {
            if (writer!=null)
            {
                writer.WriterPassword = BCrypt.Net.BCrypt.HashPassword(writer.WriterPassword);
                using (Context c = new Context())
                {
                    c.Add(writer);
                    c.SaveChanges(true);
                }
            }
        }
    }
}
