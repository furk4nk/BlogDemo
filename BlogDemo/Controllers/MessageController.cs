using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogDemo.Controllers
{
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
            var values =_message2Service.TGetListMessagesByWriter(_authorUserID);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var values = _message2Service.TGetById(id);
            return View(values);
        }
        public IActionResult SendBox()
        {
            return View();
        }
        private int AuthorUser()
        {
            if (User.Identity.Name!=null)
            {
                return  int.Parse(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);
            }
            return 0;
        }
    }
    
}
