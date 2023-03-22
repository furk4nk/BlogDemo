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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public Task<Contact> TGetByIdAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<A> TGetByIdAsync<A>(int ID) where A : class
        {
            throw new NotImplementedException();
        }

        public Task<int> TGetCountAsync(Expression<Func<Contact, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<int> TGetCountAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<A>> TGetListAsync<A>() where A : class
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> TGetListAsync(Expression<Func<Contact, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<A>> TGetListAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync(Contact t)
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync<A>(A model) where A : class
        {
            throw new NotImplementedException();
        }

        public Task TInsertRangeAsync(List<Contact> t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Contact t)
        {
            _contactDal.Delete(t);
        }

        public void TDeleteRange(List<Contact> t)
        {
            throw new NotImplementedException();
        }

        public Contact TGetById(int ID)
        {
            return _contactDal.GetById(ID);
        }

        public int TGetCount(Expression<Func<Contact, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Contact> TGetList()
        {
            return _contactDal.GetList();
        }

		public List<Contact> TGetList(Expression<Func<Contact, bool>> filter)
		{
			return _contactDal.GetList(filter);
		}

		public void TInsert(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void TInsertRange(List<Contact> t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Contact t)
        {
            _contactDal.Update(t);
        }

        public void TUpdateRange(List<Contact> t)
        {
            throw new NotImplementedException();
        }
    }
}
