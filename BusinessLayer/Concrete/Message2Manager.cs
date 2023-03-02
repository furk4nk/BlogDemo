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
            throw new NotImplementedException();
        }

        public Message2 TGetByIdSendMessageWithWriter(int id)
        {
            return _messageDal.GetByIdSendMessageWithWriter(id);
        }

        public int TGetID(string mail)
        {
            return _messageDal.GetID(mail);
        }
    }
}
