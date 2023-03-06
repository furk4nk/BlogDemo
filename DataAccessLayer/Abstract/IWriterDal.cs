using BCrypt.Net;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IWriterDal : IGenericDal<Writer>
    {
        /// <summary>
        /// Yazar mailine göre kullanıcı kontrolü 
        /// </summary>
        /// <param name="mail">yazar E-mail </param>
        /// <returns>eğer yazar sistemde kayıtlıysa false dönder</returns>
        bool IsWriterControl(string mail);
    }
}
