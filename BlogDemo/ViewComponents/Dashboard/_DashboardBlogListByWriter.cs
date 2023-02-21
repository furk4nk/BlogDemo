using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogDemo.ViewComponents.Dashboard
{
    public class _DashboardBlogListByWriter : ViewComponent
    {
        private readonly IBlogService _blogService;
        private readonly IWriterService _writerService;

        public _DashboardBlogListByWriter(IBlogService blogService, IWriterService writerService)
        {
            _blogService = blogService;
            _writerService = writerService;
        }

        public IViewComponentResult Invoke()
        {
            var author = _writerService.TGetList(x => x.WriterMail == User.Identity.Name).FirstOrDefault();
            var values = _blogService.TGetRecentBlogListByWriter(id: author.WriterID, 4); 
            return View(values);
        }
    }
}
