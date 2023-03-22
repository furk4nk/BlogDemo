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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal=messageDal;
        }
        #region Async
        public Task<Message> TGetByIdAsync(int ID)
        {
            return TGetByIdAsync<Message>(ID);
        }

        public Task<A> TGetByIdAsync<A>(int ID) where A : class
        {
           return _messageDal.GetByIdAsync<A>(ID);
        }

        public Task<int> TGetCountAsync(Expression<Func<Message, bool>> filter)
        {
           return TGetCountAsync<Message>(filter);
        }

        public Task<int> TGetCountAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            return _messageDal.GetCountAsync<A>(filter);    
        }

        public Task<List<Message>> TGetListAsync()
        {
            return TGetListAsync<Message>();
        }

        public Task<List<A>> TGetListAsync<A>() where A : class
        {
            return  _messageDal.GetListAsync<A>();   
        }

        public Task<List<Message>> TGetListAsync(Expression<Func<Message, bool>> filter)
        {
            return TGetListAsync<Message>(filter);
        }

        public Task<List<A>> TGetListAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            return _messageDal.GetListAsync<A>(filter);
        }

        public Task TInsertAsync(Message t)
        {
            return TInsertAsync<Message>(t);
        }

        public Task TInsertAsync<A>(A model) where A : class
        {
            return _messageDal.InsertAsync<A>(model);
        }

        public Task TInsertRangeAsync(List<Message> t)
        {
            return _messageDal.InsertRangeAsync(t);
        }
        #endregion

        #region Sync
        public void TDelete(Message t)
        {
            _messageDal.Delete(t);
        }

        public void TDeleteRange(List<Message> t)
        {
            _messageDal.DeleteRange(t);
        }

        public Message TGetById(int ID)
        {
            return _messageDal.GetById(ID);
        }

        public int TGetCount(Expression<Func<Message, bool>> filter)
        {
            return _messageDal.GetCount(filter);
        }

        public List<Message> TGetList()
        {
            return _messageDal.GetList();
        }

        public List<Message> TGetList(Expression<Func<Message, bool>> filter)
        {
            return _messageDal.GetList(filter);
        }

        public void TInsert(Message t)
        {
            _messageDal.Insert(t);
        }

        public void TInsertRange(List<Message> t)
        {
            _messageDal.InsertRange(t);
        }

        public void TUpdate(Message t)
        {
            _messageDal.Update(t);
        }

        public void TUpdateRange(List<Message> t)
        {
            _messageDal.UpdateRange(t);
        }
        #endregion
    }
}
