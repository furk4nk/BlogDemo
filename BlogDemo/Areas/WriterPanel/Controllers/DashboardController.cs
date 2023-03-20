using BlogApıDemo.DataAccess.Concrete;
using BusinessLayer.Abstract;
using BusinessLayer.Exceptions;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogDemo.Areas.WriterPanel.Controllers
{
    [Area("WriterPanel")]
    public class DashboardController : Controller
    {
        private readonly IWriterService _writerService;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(IWriterService writerService, IBlogService blogService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _categoryService = categoryService;
            _blogService= blogService;
            _writerService = writerService;
            _userManager=userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var authorUser = AuthorUser();
            ViewBag.author = authorUser;
            ViewBag.writername=authorUser.WriterName;
            ViewBag.WriterMail=authorUser.WriterMail;
            ViewBag.blogcount = _blogService.TGetCount();
            ViewBag.writerblogcount= _blogService.TGetCount(x => x.WriterID ==authorUser.WriterID);
            ViewBag.categorycount = _categoryService.TGetList().Count();
            return View();
        }
        private Writer AuthorUser()
        {
            Writer authorWriter = new Writer();

            if (User.Identity.Name != null)
            {   
                int authorID =int.Parse(((ClaimsIdentity)User.Identity).FindFirst(type:ClaimTypes.NameIdentifier).Value);
                authorWriter= _writerService.TGetList(x => x.appUserID == authorID).FirstOrDefault();
                if (authorWriter is null) throw new InvalidWriterException(User.Identity.Name);                
            }
            return authorWriter;
        }
    }
}