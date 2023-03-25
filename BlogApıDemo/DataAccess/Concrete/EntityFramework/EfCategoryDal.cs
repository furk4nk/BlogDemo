using BlogApıDemo.DataAccess.Abstract;
using BlogApıDemo.DataAccess.GenericRepo;
using BlogApıDemo.Entities.concrete;

namespace BlogApıDemo.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : GenericRepo<Category>, ICategoryDal
    {
        public EfCategoryDal(Context context) : base(context) { }
    }
}
