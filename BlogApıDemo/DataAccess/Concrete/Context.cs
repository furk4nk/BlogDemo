using BlogApıDemo.Entities.concrete;
using Microsoft.EntityFrameworkCore;

namespace BlogApıDemo.DataAccess.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=FN-515AN_FURKAN;database=DbBlogApi;Integrated Security=True;"); // ana projeyle haberlşecek
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Blog> Blogs { get; set; }
    }
}   
