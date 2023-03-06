using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminService _adminService;

        public AdminManager(IAdminService adminService)
        {
            _adminService=adminService;
        }

        public void TDelete(Admin t)
        {
            _adminService.TDelete(t);
        }

        public Admin TGetById(int ID)
        {
            return _adminService.TGetById(ID);
        }

        public int TGetCount(Expression<Func<Admin, bool>> filter = null)
        {
            return _adminService.TGetCount(filter);
        }

        public List<Admin> TGetList()
        {
            return _adminService.TGetList();
        }

        public List<Admin> TGetList(Expression<Func<Admin, bool>> filter)
        {
            return _adminService.TGetList(filter);
        }

        public void TInsert(Admin t)
        {
            _adminService.TInsert(t);
        }

        public void TUpdate(Admin t)
        {
            _adminService.TUpdate(t);
        }
    }
}
