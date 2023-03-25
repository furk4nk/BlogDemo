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
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(Context c) : base(c)
        {
        }

        public List<Notification> GetListNotificationByTrueAndCount(int count)
        {
            return _context.Set<Notification>().Where(x => x.NotificationStatus == true).Take(count).ToList();
        }
    }
}
