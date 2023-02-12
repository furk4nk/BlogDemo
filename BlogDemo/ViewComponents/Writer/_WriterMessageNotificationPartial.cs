using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Writer
{
    public class _WriterMessageNotificationPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
