using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Writer
{
    public class _WriterNotificationPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
