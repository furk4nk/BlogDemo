using BusinessLayer.Abstract;
using BusinessLayer.Abstract.UnitOfWork;
using BusinessLayer.Exceptions;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace BlogDemo.Areas.WriterPanel.Controllers
{
    [Area("WriterPanel")]
    [Authorize(Roles ="Yazar")]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager,IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService=unitOfWorkService;
            _userManager=userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var authorUser = AuthorUser();
            ViewBag.author = authorUser;
            ViewBag.writername=authorUser.WriterName;
            ViewBag.WriterMail=authorUser.WriterMail;
            ViewBag.blogcount = _unitOfWorkService.BlogService.TGetCount();
            ViewBag.writerblogcount= _unitOfWorkService.BlogService.TGetCount(x => x.WriterID ==authorUser.WriterID);
            ViewBag.categorycount = _unitOfWorkService.categoryService.TGetCount();
            return View();
        }
        private Writer AuthorUser()
        {
            Writer authorWriter = new();

            if (User.Identity.Name != null)
            {   
                int authorID =int.Parse(((ClaimsIdentity)User.Identity).FindFirst(type:ClaimTypes.NameIdentifier).Value);
                authorWriter= _unitOfWorkService.writerService.TGetList(x => x.appUserID == authorID).FirstOrDefault();
                if (authorWriter is null) throw new InvalidWriterException(User.Identity.Name);                
            }
            return authorWriter;
        }
    }
}