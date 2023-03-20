using BusinessLayer.Abstract;
using BusinessLayer.Exceptions;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace BlogDemo.Areas.WriterPanel.Controllers
{
    [Area("WriterPanel")]
    public class MessageController : Controller
    {
        private readonly IMessage2Service _message2Service;
        private readonly IWriterService _writerService;
        private Writer _authorUser => AuthorUser();
        public MessageController(IMessage2Service message2Service, IWriterService writerService)
        {
            _writerService = writerService;
            _message2Service=message2Service;
        }

        public IActionResult InBox()
        {
            var values = _message2Service.TGetListMessagesByWriter(_authorUser.WriterID);
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
            var values = _message2Service.TGetListSendMessagesByWriter(_authorUser.WriterID);
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
        public IActionResult SendMessage(Message2 message) // receiver id alakasız değerlerde geliyor data access gtby ıd metodunda bir sorun var sanırım
        {
            MessageValidator validations = new MessageValidator(_message2Service);
            ValidationResult result = validations.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate=System.DateTime.Now;
                message.MessageStatus=true;
                message.SenderID = _authorUser.WriterID;
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
        private Writer AuthorUser()
        {
            if (User.Identity.Name!=null)
            {
                int authorID = int.Parse(((ClaimsIdentity)User.Identity).FindFirst(type: ClaimTypes.NameIdentifier).Value);
                Writer author = _writerService.TGetList(x => x.appUserID == authorID).FirstOrDefault();
                return author;
            }
            throw new InvalidWriterException(User.Identity.Name);
        }
    }
}
