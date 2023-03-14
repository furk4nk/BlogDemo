using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogDemo.Areas.WriterPanel.Controllers
{
    [Area("WriterPanel")]
    public class MessageController : Controller
    {
        private readonly IMessage2Service _message2Service;
        private int _authorUserID => AuthorUser();
        public MessageController(IMessage2Service message2Service)
        {
            _message2Service=message2Service;
        }

        public IActionResult InBox()
        {

            var values = _message2Service.TGetListMessagesByWriter(_authorUserID);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var values = _message2Service.TGetByIdWithWriter(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult SendBox()
        {
            var values = _message2Service.TGetListSendMessagesByWriter(_authorUserID);
            return View(values);
        }
        public IActionResult SendBoxDetails(int id)
        {
            var values = _message2Service.TGetByIdSendMessageWithWriter(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 message)
        {
            MessageValidator validations = new MessageValidator();
            ValidationResult result = validations.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate=System.DateTime.Now;
                message.MessageStatus=true;
                message.SenderID = _authorUserID;
                message.ReceiverID = _message2Service.TGetID(message.ReceiverUser.WriterMail);
                message.ReceiverUser=null;
                _message2Service.TInsert(message);
                return RedirectToAction("SendBox", "Message");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(message);
        }
        private int AuthorUser()
        {
            if (User.Identity.Name!=null)
            {
                return int.Parse(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);
            }
            return 0;
        }
    }
}
