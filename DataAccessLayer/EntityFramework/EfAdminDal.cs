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
    public class EfAdminDal : GenericRepository<Admin> , IAdminDal
    {
        public override void Insert(Admin t)
        {
            if (t != null)
            {
               var result = BCrypt.Net.BCrypt.HashPassword(t.Password);
                using (Context c = new Context())
                {
                    t.Password = result;
                    c.Set<Admin>().Add(t);
                    c.SaveChanges();
                }

            }
            else
            {
                throw new Exception("Entity Boş olamaz -Admin");
            }
        }
        public override void Update(Admin t)
        {
            if (t != null)
            {
                t.Password = BCrypt.Net.BCrypt.HashPassword(t.Password);
                using (Context c = new Context())
                {
                    c.Set<Admin>().Update(t);
                    c.SaveChanges();
                }
            }
        }
    }
}
