using BusinessLayer.Abstract;
using BusinessLayer.Abstract.UnitOfWork;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;

namespace BusinessLayer.Concrete.UnitOfWork
{
    public class UnitOfWorkManager : IUnitOfWorkService 
    {
        private readonly Context _context;
        private readonly IUnitOfWorkDal _work;    
        public UnitOfWorkManager(Context context,IUnitOfWorkDal unitOfWorkDal)
        {
            _context = context;
            AboutService = new AboutManager(new EfAboutDal(_context));
            adminService = new AdminManager(new EfAdminDal(_context));
            BlogService = new BlogManager(new EfBlogDal(_context));
            categoryService = new CategoryManager(new EfCategoryDal(_context));
            commentService = new CommentManager(new EfCommentDal(_context));
            contactService = new ContactManager(new EfContactDal(_context));
            message2Service = new Message2Manager(new EfMessage2Dal(_context));
            newsLetterService = new NewsLetterManager(new EfNewsLetterDal(_context));
            notificationService = new NotificationManager(new EfNotificationDal(_context));
            writerService = new WriterManager(new EfWriterDal(_context));
            _work = unitOfWorkDal;
        }

        public IAboutService AboutService { get; private set; }
        public IAdminService adminService { get; private set; }
        public IBlogService BlogService { get; private set; }
        public ICategoryService categoryService { get; private set; }
        public ICommentService commentService { get; private set; }
        public IContactService contactService { get; private set; }
        public IMessage2Service message2Service { get; private set; }
        public INewsLetterService newsLetterService { get; private set; }
        public INotificationService notificationService { get; private set; }
        public IWriterService writerService { get; private set; }
           
        public bool TSaveChange()
        {
           return _work.SaveChange();           
        }
    }
}
