using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Areas.Admin.ViewComponents.Widgets
{
    public class _WidgetRow1 : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
