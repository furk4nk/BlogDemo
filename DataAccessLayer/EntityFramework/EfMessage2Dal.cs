using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessage2Dal : GenericRepository<Message2>, IMessage2Dal
    {
        public Message2 GetByIdSendMessageWithWriter(int ID)
        {
            using (Context c = new Context())
            {
                return c.Set<Message2>().Where(x => x.ID==ID).Include(y => y.ReceiverUser).FirstOrDefault();
            }
        }

        public Message2 GetByIdWithWriter(int ID)
        {
            using (Context c = new Context())
            {
                return c.Set<Message2>().Where(x => x.ID==ID).Include(y => y.SenderUser).FirstOrDefault();
            }
        }

        public int GetID(string mail)
        {
            using (Context c = new Context())
            {
                return c.Set<Message2>().Where(x => x.ReceiverUser.WriterMail == mail).Select(x => x.ID).FirstOrDefault();
            }
        }

        public List<Message2> GetListMessageByWriter(int id = 1)
        {
            using (Context c = new Context())
            {
                return c.Set<Message2>().Where(x => x.ReceiverID==id).Include(y => y.SenderUser).ToList();
            }
        }

        public List<Message2> GetListSendMessageByWriter(int id)
        {
            using (Context c = new Context())
            {
                return c.Set<Message2>().Where(x => x.SenderID==id).Include(y => y.ReceiverUser).ToList();
            }
        }
    }
}
