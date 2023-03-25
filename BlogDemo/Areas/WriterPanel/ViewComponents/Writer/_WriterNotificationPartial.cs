using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Areas.WriterPanel.ViewComponents.Writer
{
    public class _WriterNotificationPartial : ViewComponent
    {
        private readonly INotificationService _notificationService;

        public _WriterNotificationPartial(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _notificationService.TGetListNotificationByTrueAndCount(4);
            return View(values);
        }
    }
}
