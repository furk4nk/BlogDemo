using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Controllers
{
	public class BlogController : Controller
	{
		private readonly IBlogService _blogService;
		private readonly IWriterService _writerService;
		private readonly ICategoryService _categoryService;
		public BlogController(IBlogService blogService, IWriterService writerService, ICategoryService categoryService)
		{
			_blogService = blogService;
			_writerService = writerService;
			_categoryService = categoryService;
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
		public IActionResult BlogListByWriter()
		{
			var VerifiedAuthor = _writerService.TGetList(x => x.WriterMail == User.Identity.Name).FirstOrDefault();
			var values = _blogService.TGetBlogListByWriter(VerifiedAuthor.WriterID);
			return View(values);
		}

		[HttpGet]
		public IActionResult BlogInsert()
		{
			var values = CategoryList();
			ViewBag.value = values;
			return View();
		}
		[HttpPost]
		public IActionResult BlogInsert(Blog blog)
		{
			BlogValidator validations = new BlogValidator();
			ValidationResult result = validations.Validate(blog);
			if (result.IsValid)
			{
				var writer=_writerService.TGetList(x => x.WriterMail == User.Identity.Name).FirstOrDefault();
				blog.WriterID = writer.WriterID;
				_blogService.TInsert(blog);
				return RedirectToAction("BlogListByWriter", "Blog");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			var values = CategoryList();
			ViewBag.value = values;
			return View(blog);		
		}

		public IActionResult BlogDelete(int id)
		{
			Blog temp = _blogService.TGetList(x => x.BlogID == id).FirstOrDefault();
			_blogService.TDelete(temp);
			return RedirectToAction("BlogListByWrite","Login");
		}
		[HttpGet]
		public IActionResult BlogUpdate(int id)
		{	

			var values=_blogService.TGetById(id);
			var CategoryValues = CategoryList();
			ViewBag.value = CategoryValues;
			return View(values);
		}
		[HttpPost]
		public IActionResult BlogUpdate(Blog blog)
		{
			BlogValidator validations = new BlogValidator();
			ValidationResult result = validations.Validate(blog);
			if (result.IsValid)
			{
				return RedirectToAction("BlogListByWriter","Login");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
				}
			}
			var values = CategoryList();	
			ViewBag.value = values;
			return View(blog);

		}
		private List<SelectListItem> CategoryList()
		{
			var values = (from x in _categoryService.TGetList()
						  select new SelectListItem
						  {
							  Text = x.CategoryName,
							  Value = x.CategoryID.ToString()
						  }).ToList();
			return values;
		}
		public IActionResult ChangeBlogStatus(int id)
		{
			var values = _blogService.TGetById(id);
			bool status = values.BlogStatus;
			values.BlogStatus=status ==true ? false : true;

			_blogService.TUpdate(values);
			return RedirectToAction("BlogListByWriter", "Blog");
		}

		//GOTO 
		//YORUM SAYISI LİSTELENECEK 
	}
}
