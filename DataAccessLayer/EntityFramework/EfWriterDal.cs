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
        public void Insert(Writer writer, string passord)
        {
            if (writer !=null && passord !=null)
            {
                writer.WriterPassword = BCrypt.Net.BCrypt.HashPassword(passord);
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

        public void Update(Writer writer, string newPassword)
        {
            if (writer!=null && newPassword !=null)
            {
                writer.WriterPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                using (Context c = new Context())
                {
                    c.Add(writer);
                    c.SaveChanges(true);
                }
            }
        }
    }
}
