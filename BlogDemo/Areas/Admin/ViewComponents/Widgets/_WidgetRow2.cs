using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Areas.Admin.ViewComponents.Widgets
{
    public class _WidgetRow2 : ViewComponent
    {
        private readonly IAboutService _aboutService;
        private readonly IBlogService _blogService;

        public _WidgetRow2(IAboutService aboutService, IBlogService blogService)
        {
            _aboutService=aboutService;
            _blogService=blogService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.about= _aboutService.TGetById(1);
            ViewBag.recentlyblog = _blogService.TGetLastBlogs(1);
            return View();
        }
    }
}
