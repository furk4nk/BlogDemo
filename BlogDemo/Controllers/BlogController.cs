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

		//Blogların Ana Sayfada Listelenmesi
		public IActionResult Index()
		{
			List<Blog> values = _blogService.TGetBlogInListAll();
			return View(values);
		}

		//Blog Detaylarının Listelenmesi
		public IActionResult BlogReadMore(int id)
		{
			var values = _blogService.TGetList(x => x.BlogID == id);
			ViewBag.id = id;
			return View(values);
		}

		//Yazarın Bloglarının listelenmesi
		public IActionResult BlogListByWriter(int id)
		{
			//var VerifiedAuthor = 
			var values = _blogService.TGetBlogListByWriter(id);
			return View(values);
		}

		//GOTO 
		//YORUM SAYISI LİSTELENECEK 
	}
}
