using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogDemo.Areas.WriterPanel.ViewComponents.Writer
{
    public class _WriterMessageNotificationPartial : ViewComponent
    {
        private readonly IMessage2Service _message2Service;

        public _WriterMessageNotificationPartial(IMessage2Service messageService)
        {
            _message2Service = messageService;
        }

        public IViewComponentResult Invoke()
        {
            int id = int.Parse(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);
            var values = _message2Service.TGetListMessagesByWriter(id);
            return View(values);
        }
    }
}
