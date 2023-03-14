using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace BlogDemo.Areas.WriterPanel.ViewComponents.Dashboard
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
            int id = int.Parse(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);
            EntityLayer.Concrete.Writer author = _writerService.TGetById(id);
            var values = _blogService.TGetRecentBlogListByWriter(id: author.WriterID, 4);
            return View(values);
        }
    }
}
