using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata;

namespace BlogDemo.Controllers
{
	public class DashboardController : Controller
	{
		private readonly IWriterService _writerService;
		private readonly IBlogService _blogService;
		private readonly ICategoryService _categoryService;

        public DashboardController(IWriterService writerService, IBlogService blogService, ICategoryService categoryService)
        {
			_categoryService = categoryService;
			_blogService= blogService;
            _writerService = writerService;
        }

        public IActionResult Index()
		{
			var author= _writerService.TGetList(x => x.WriterMail == User.Identity.Name).FirstOrDefault();
			ViewBag.author = author;
			ViewBag.WriterMail=author.WriterMail;
			ViewBag.blogcount = _blogService.TBlogCount;
			ViewBag.writerblogcount=_blogService.TWriterBlogCount(author.WriterID);
			ViewBag.categorycount = _categoryService.TGetList().Count();
			return View();
		}
	}
}
