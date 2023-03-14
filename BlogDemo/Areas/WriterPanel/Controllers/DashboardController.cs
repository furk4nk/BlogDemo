using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace BlogDemo.Areas.WriterPanel.Controllers
{
	[Area("WriterPanel")]
	public class DashboardController : Controller
	{
		private readonly IWriterService _writerService;
		private readonly IBlogService _blogService;
		private readonly ICategoryService _categoryService;
		private Writer _authorUser  => AuthorUser();

        public DashboardController(IWriterService writerService, IBlogService blogService, ICategoryService categoryService)
        {
			_categoryService = categoryService;
			_blogService= blogService;
            _writerService = writerService;
        }

        public IActionResult Index()
		{
			ViewBag.author = _authorUser;
			ViewBag.writername=_authorUser.WriterName;
			//ViewBag.writerabout=_authorUser.WriterAbout;
			ViewBag.WriterMail=_authorUser.WriterMail;
			ViewBag.blogcount = _blogService.TBlogCount;
			ViewBag.writerblogcount=_blogService.TWriterBlogCount(_authorUser.WriterID);
			ViewBag.categorycount = _categoryService.TGetList().Count();
			return View();
		}

		private Writer AuthorUser()
		{
			if (User.Identity.Name != null)
			{
				int id = int.Parse(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);
				return _writerService.TGetById(id);
			}
			return null;
		}
	}
}
