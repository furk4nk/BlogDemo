using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Areas.WriterPanel.ViewComponents.Dashboard
{
    public class _DashboardBlogList : ViewComponent
    {
        private readonly IBlogService _blogService;

        public _DashboardBlogList(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _blogService.TGetLastBlogsWithCategoryAndWriter(6);
            return View(result);
        }
    }
}
