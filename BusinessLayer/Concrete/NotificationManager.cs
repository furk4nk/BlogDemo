using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal=notificationDal;
        }

        public Task<Notification> TGetByIdAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<A> TGetByIdAsync<A>(int ID) where A : class
        {
            throw new NotImplementedException();
        }

        public Task<int> TGetCountAsync(Expression<Func<Notification, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<int> TGetCountAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            throw new NotImplementedException();
        }

        public Task<List<Notification>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<A>> TGetListAsync<A>() where A : class
        {
            throw new NotImplementedException();
        }

        public Task<List<Notification>> TGetListAsync(Expression<Func<Notification, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<A>> TGetListAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync(Notification t)
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync<A>(A model) where A : class
        {
            throw new NotImplementedException();
        }

        public Task TInsertRangeAsync(List<Notification> t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Notification t)
        {
            throw new NotImplementedException();
        }

        public void TDeleteRange(List<Notification> t)
        {
            throw new NotImplementedException();
        }

        public Notification TGetById(int ID)
        {
            throw new NotImplementedException();
        }

        public int TGetCount(Expression<Func<Notification, bool>> filter)
        {
            return _notificationDal.GetCount(filter);
        }

        public List<Notification> TGetList()
        {
            return _notificationDal.GetList();
        }

        public List<Notification> TGetList(Expression<Func<Notification, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Notification t)
        {
            throw new NotImplementedException();
        }

        public void TInsertRange(List<Notification> t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Notification t)
        {
            throw new NotImplementedException();
        }

        public void TUpdateRange(List<Notification> t)
        {
            throw new NotImplementedException();
        }
    }
}
