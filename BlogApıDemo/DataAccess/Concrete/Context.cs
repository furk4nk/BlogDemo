using BlogApıDemo.Entities.concrete;
using Microsoft.EntityFrameworkCore;

namespace BlogApıDemo.DataAccess.Concrete
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}   
