using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWorkDal : IDisposable
    {
        IAboutDal AboutDal { get; }
        IAdminDal adminDal { get; }
        IBlogDal BlogDal { get; }
        ICategoryDal categoryDal { get; }
        ICommentDal commentDal { get; }
        IContactDal contactDal { get; }
        IMessage2Dal message2Dal { get; }
        INewsLetterDal newsLetterDal { get; }
        INotificationDal notificationDal { get; }
        IWriterDal writerDal { get; }
        bool SaveChange();
    }
}
