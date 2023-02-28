using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message2 : BaseEntity
    {
        public int? SenderID { get; set; }
        public int? ReceiverID { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
        public Writer SenderUser { get; set; }
        public Writer ReceiverUser { get; set; }
    }
}
