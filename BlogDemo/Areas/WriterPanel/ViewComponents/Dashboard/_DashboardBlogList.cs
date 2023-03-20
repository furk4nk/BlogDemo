using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            List<Blog> blogs = _blogService.TGetLastBlogsWithCategoryAndWriter(6);
            return View(blogs);
        }
    }
}
