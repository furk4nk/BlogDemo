using BusinessLayer.Abstract.UnitOfWork;
using BusinessLayer.Exceptions;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace BlogDemo.Areas.WriterPanel.Controllers
{
    [Area("WriterPanel")]
    [Authorize(Roles ="Yazar")]
    public class MessageController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        public MessageController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public IActionResult InBox()
        {
            var values = _unitOfWorkService.message2Service.TGetListMessagesByWriter(AuthorUser().WriterID);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var values = _unitOfWorkService.message2Service.TGetByIdWithWriter(id);
            values.MessageStatus = false;
            _unitOfWorkService.message2Service.TUpdate(values);
            _unitOfWorkService.TSaveChange();
            return View(values);
        }
        [HttpGet]
        public IActionResult SendBox()
        {
            var values = _unitOfWorkService.message2Service.TGetListSendMessagesByWriter(AuthorUser().WriterID);
            return View(values);
        }
        public IActionResult SendBoxDetails(int id)
        {
            var values = _unitOfWorkService.message2Service.TGetByIdSendMessageWithWriter(id);
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
            MessageValidator validations = new(_unitOfWorkService.writerService);
            ValidationResult result = validations.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate=System.DateTime.Now;
                message.MessageStatus=true;
                message.SenderID = AuthorUser().WriterID;
                message.ReceiverID = _unitOfWorkService.writerService.TGetList(x => x.WriterMail == message.ReceiverUser.WriterMail).FirstOrDefault().WriterID;
                message.ReceiverUser=null;
                _unitOfWorkService.message2Service.TInsert(message);
                _unitOfWorkService.TSaveChange();
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
                Writer author = _unitOfWorkService.writerService.TGetList(x => x.appUserID == authorID).FirstOrDefault();
                return author;
            }
            throw new InvalidWriterException(User.Identity.Name);
        }
    }
}
