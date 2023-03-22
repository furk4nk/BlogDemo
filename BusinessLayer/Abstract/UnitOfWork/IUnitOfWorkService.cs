using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.UnitOfWork
{
    public interface IUnitOfWorkService
    {
        IAboutService AboutService { get; }
        IAdminService adminService { get; }
        IBlogService BlogService { get; }
        ICategoryService categoryService { get; }
        ICommentService commentService { get; }
        IContactService contactService { get; }
        IMessage2Service message2Service { get; }
        INewsLetterService newsLetterService { get; }
        INotificationService notificationService { get; }
        IWriterService writerService { get; }        
        bool TSaveChange();
    }
}
        