using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessage2Service : IGenericService<Message2>
    {
        List<Message2> TGetListMessagesByWriter(int id);
        List<Message2> TGetListSendMessagesByWriter(int id);
        Message2 TGetByIdWithWriter(int id);
        Message2 TGetByIdSendMessageWithWriter(int id);
        int TGetID(string mail);
    }
}
