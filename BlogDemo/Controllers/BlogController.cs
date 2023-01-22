using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogDemo.Controllers
{
	public class BlogController : Controller
	{
		private readonly IBlogService _blogService;
		public BlogController(IBlogService blogService)
		{
			_blogService = blogService;
		}

		public IActionResult Index()
		{
			List<Blog> values = _blogService.TGetBlogInListAll();
			return View(values);
		}

		public IActionResult BlogReadMore(int id)
		{
			var values = _blogService.TGetList(x => x.BlogID == id);
			ViewBag.id = id;
			return View(values);
		}

		//GOTO 
		//YORUM SAYISI LİSTELENECEK 
	}
}
