using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Writer
{
    public class _WriterMessageNotificationPartial : ViewComponent
    {
        private readonly IMessageService _messageService;

        public _WriterMessageNotificationPartial(IMessageService messageService)
        {
            _messageService=messageService;
        }

        public IViewComponentResult Invoke()
        {
           var messageList= _messageService.TGetList(x=>x.Receiver==User.Identity.Name);
            return View(messageList);
        }
    }
}
