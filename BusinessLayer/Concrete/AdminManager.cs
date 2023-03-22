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
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal=adminDal;
        }
        #region Async
        public Task<Admin> TGetByIdAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<A> TGetByIdAsync<A>(int ID) where A : class
        {
            throw new NotImplementedException();
        }

        public Task<int> TGetCountAsync(Expression<Func<Admin, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<int> TGetCountAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            throw new NotImplementedException();
        }

        public Task<List<Admin>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<A>> TGetListAsync<A>() where A : class
        {
            throw new NotImplementedException();
        }

        public Task<List<Admin>> TGetListAsync(Expression<Func<Admin, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<A>> TGetListAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync(Admin t)
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync<A>(A model) where A : class
        {
            throw new NotImplementedException();
        }

        public Task TInsertRangeAsync(List<Admin> t)
        {
            throw new NotImplementedException();
        }
#endregion
        public void TDelete(Admin t)
        {
            _adminDal.Delete(t);
        }

        public void TDeleteRange(List<Admin> t)
        {
            _adminDal.DeleteRange(t);
        }

        public Admin TGetById(int ID)
        {
            return _adminDal.GetById(ID);
        }

        public int TGetCount(Expression<Func<Admin, bool>> filter = null)
        {
            return _adminDal.GetCount(filter);
        }

        public List<Admin> TGetList()
        {
            return _adminDal.GetList();
        }

        public List<Admin> TGetList(Expression<Func<Admin, bool>> filter)
        {
            return _adminDal.GetList(filter);
        }

        public void TInsert(Admin t)
        {
            _adminDal.Insert(t);
        }

        public void TInsertRange(List<Admin> t)
        {
            _adminDal.InsertRange(t);
        }

        public void TUpdate(Admin t)
        {
            _adminDal.Update(t);
        }

        public void TUpdateRange(List<Admin> t)
        {
            _adminDal.UpdateRange(t);
        }
    }
}
