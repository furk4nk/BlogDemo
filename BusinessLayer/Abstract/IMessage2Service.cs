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
        /// <summary>
        /// YazarID'ye Göre Mesaj listesini gönderir
        /// </summary>
        /// <param name="id">YazarID</param>
        /// <returns>Mesaj Listesi </returns>
        List<Message2> TGetListMessagesByWriter(int id);
        /// <summary>
        /// Durumu True Olan Mesaj Listesi
        /// </summary>
        /// <param name="id">YazarID</param>
        /// <param name="Count">Liste Uzunluğu</param>
        /// <returns>Durumu Ture Olan mesaj Listesi</returns>
        List<Message2> TGetListMessagesByWriter(int id,int Count);
        List<Message2> TGetListSendMessagesByWriter(int id);
        Message2 TGetByIdWithWriter(int id);
        Message2 TGetByIdSendMessageWithWriter(int id);
        int TGetID(string mail);
    }
}
