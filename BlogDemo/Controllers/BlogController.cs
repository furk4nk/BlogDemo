using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BlogDemo.Controllers
{
    [AllowAnonymous]
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
            List<Blog> values = _blogService.TGetBlogListByTrue();
            return View(values);
        }

        //Blog Detaylarının Listelenmesi
        public IActionResult BlogReadMore(int id=1)
        {
			if (User.Identity.Name is not null)
			{
				ViewBag.commentStatus=true;
			}
			else
			{
				ViewBag.commentStatus=false;
			}
			var values = _blogService.TGetById(id);
            ViewBag.id = id;
            if (values!=null)
                ViewBag.writerid=values.WriterID;
            return View(values);
        }
        //GOTO 
        //YORUM SAYISI LİSTELENECEK 
    }
}
