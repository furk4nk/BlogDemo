using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class InvalidWriterException : Exception
    {
        public InvalidWriterException() { }
        public InvalidWriterException(string userName) : base(string.Format("Yazar Bulunamadı Username : '{0}'  HATA KODU:A001",userName)) { }
    }
}
