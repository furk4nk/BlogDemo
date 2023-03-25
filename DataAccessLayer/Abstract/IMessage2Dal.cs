using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal : IGenericDal<Message2>
    {
        List<Message2> GetListMessageByWriter(int id);
        List<Message2> GetListMessageByWriter(int id, int count);
        List<Message2> GetListSendMessageByWriter(int id);
        Message2 GetByIdWithWriter(int ID);
        Message2 GetByIdSendMessageWithWriter(int ID);
        int GetID(string mail);
    }
}