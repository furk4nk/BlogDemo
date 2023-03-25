using BlogApıDemo.DataAccess.Abstract;
using BlogApıDemo.DataAccess.GenericRepo;
using BlogApıDemo.Entities.concrete;

namespace BlogApıDemo.DataAccess.Concrete.EntityFramework
{
    public class EfBlogDal : GenericRepo<Blog> , IBlogDal
    {
        public EfBlogDal(Context context) :base(context)
        {
        }
    }
}
