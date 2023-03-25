using BusinessLayer.Abstract.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Areas.WriterPanel.Controllers
{
    [Area("WriterPanel")]
    public class NotificationController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public NotificationController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService=unitOfWorkService;
        }

        public IActionResult Index()
        {
            var messages = _unitOfWorkService.notificationService.TGetList();
            return View(messages);
        }
        public IActionResult NotificationDetails(int id)
        {
            var messages = _unitOfWorkService.notificationService.TGetById(id);
            messages.NotificationStatus = false;
            _unitOfWorkService.notificationService.TUpdate(messages);
            _unitOfWorkService.TSaveChange();
            return View(messages);
        }
    }
}
