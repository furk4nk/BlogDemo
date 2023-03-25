using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        private readonly IMessage2Dal _messageDal;

        public Message2Manager(IMessage2Dal messageDal)
        {
            _messageDal=messageDal;
        }
        #region Async
        public Task<List<Message2>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<A>> TGetListAsync<A>() where A : class
        {
            throw new NotImplementedException();
        }

        public Task<List<Message2>> TGetListAsync(Expression<Func<Message2, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<A>> TGetListAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync(Message2 t)
        {
            throw new NotImplementedException();
        }

        public Task TInsertRangeAsync(List<Message2> t)
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync<A>(A model) where A : class
        {
            throw new NotImplementedException();
        }

        public Task<Message2> TGetByIdAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<A> TGetByIdAsync<A>(int ID) where A : class
        {
            throw new NotImplementedException();
        }

        public Task<int> TGetCountAsync(Expression<Func<Message2, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<int> TGetCountAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Sync
        public void TDelete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public List<Message2> TGetListSendMessagesByWriter(int id)
        {
            return _messageDal.GetListSendMessageByWriter(id);
        }

        public Message2 TGetById(int ID)
        {
            return _messageDal.GetById(ID);
        }

        public Message2 TGetByIdWithWriter(int id)
        {
            return _messageDal.GetByIdWithWriter(id);
        }

        public List<Message2> TGetList()
        {
            return _messageDal.GetList();
        }

        public List<Message2> TGetList(Expression<Func<Message2, bool>> filter)
        {
            return _messageDal.GetList(filter);
        }

        public List<Message2> TGetListMessagesByWriter(int id)
        {
            return _messageDal.GetListMessageByWriter(id);
        }

        public void TInsert(Message2 t)
        {
            _messageDal.Insert(t);
        }

        public void TUpdate(Message2 t)
        {
            _messageDal.Update(t);
        }

        public Message2 TGetByIdSendMessageWithWriter(int id)
        {
            return _messageDal.GetByIdSendMessageWithWriter(id);
        }

        public int TGetID(string mail)
        {
            return _messageDal.GetID(mail);
        }

        public int TGetCount(Expression<Func<Message2, bool>> filter =null)
        {
            return _messageDal.GetCount(filter);
        }

        public void TDeleteRange(List<Message2> t)
        {
            throw new NotImplementedException();
        }

        public void TInsertRange(List<Message2> t)
        {
            throw new NotImplementedException();
        }

        public void TUpdateRange(List<Message2> t)
        {
            throw new NotImplementedException();
        }

        public List<Message2> TGetListMessagesByWriter(int id, int Count)
        {
            return _messageDal.GetListMessageByWriter(id:id,count:Count);
        }
        #endregion
    }
}
