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
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
        public EfAdminDal(Context c) : base(c)
        {
        }

        public override bool Insert(Admin t)
        {
            int ctrl = 0;
            if (t != null)
            {
                var result = BCrypt.Net.BCrypt.HashPassword(t.Password);
                t.Password = result;
                return Insert<Admin>(t);
            }
            return CtrlValue(ctrl);
        }
        public override bool Update(Admin t)
        {
            int ctrl = 0;
            if (t != null)
            {
                t.Password = BCrypt.Net.BCrypt.HashPassword(t.Password);
                _context.Set<Admin>().Update(t);
                ctrl = _context.SaveChanges();
            }
            return CtrlValue(ctrl);
        }
    }
}