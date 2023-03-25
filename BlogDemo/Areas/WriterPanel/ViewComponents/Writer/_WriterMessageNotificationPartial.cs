using BusinessLayer.Abstract;
using BusinessLayer.Abstract.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace BlogDemo.Areas.WriterPanel.ViewComponents.Writer
{
    public class _WriterMessageNotificationPartial : ViewComponent
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public _WriterMessageNotificationPartial(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService= unitOfWorkService;
        }

        public IViewComponentResult Invoke()
        {
            int AspID = int.Parse(s:((ClaimsIdentity)User.Identity).FindFirst(type:ClaimTypes.NameIdentifier).Value);
            int WriterID = _unitOfWorkService.writerService.TGetList(filter:x => x.appUserID == AspID).FirstOrDefault().WriterID;
            var values = _unitOfWorkService.message2Service.TGetListMessagesByWriter(id:WriterID,4);
            return View(values);
        }

    }
}
