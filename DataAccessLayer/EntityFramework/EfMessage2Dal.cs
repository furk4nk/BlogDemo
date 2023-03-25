using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessage2Dal : GenericRepository<Message2>, IMessage2Dal
    {

        public EfMessage2Dal(Context c) : base(c)
        {
        }

        public Message2 GetByIdSendMessageWithWriter(int ID)
        {
            return _context.Set<Message2>().Where(x => x.ID==ID).Include(y => y.ReceiverUser).FirstOrDefault();
        }

        public Message2 GetByIdWithWriter(int ID)
        {
            return _context.Set<Message2>().Where(x => x.ID==ID).Include(y => y.SenderUser).FirstOrDefault();
        }

        public int GetID(string mail)
        {
            return _context.Set<Message2>().Where(x => x.ReceiverUser.WriterMail == mail).Select(y => y.ID).FirstOrDefault();
        }

        public List<Message2> GetListMessageByWriter(int id)
        {
            return _context.Set<Message2>().Where(x => x.ReceiverID==id).Include(y => y.SenderUser).ToList();
        }

        public List<Message2> GetListMessageByWriter(int id, int count)
        {
            return _context.Set<Message2>()
                .Where(x => x.ReceiverID == id)
                .Where(y => y.MessageStatus == true)
                .Include(c => c.SenderUser)
                .Take(count).ToList();
        }

        public List<Message2> GetListSendMessageByWriter(int id)
        {
            return _context.Set<Message2>().Where(x => x.SenderID == id).Include(y => y.ReceiverUser).ToList();
        }
    }
}
