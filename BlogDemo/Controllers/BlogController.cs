using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IWriterService _writerService;
        private readonly ICategoryService _categoryService;
        private Writer _authorUser => AuthorUser();
        public BlogController(IBlogService blogService, IWriterService writerService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _writerService = writerService;
            _categoryService = categoryService;
        }
        [AllowAnonymous]
        //Blogların Ana Sayfada Listelenmesi
        public IActionResult Index()
        {
            List<Blog> values = _blogService.TGetBlogInListAll();
            return View(values);
        }

        [AllowAnonymous]
        //Blog Detaylarının Listelenmesi
        public IActionResult BlogReadMore(int id=1)
        {
            var values = _blogService.TGetById(id);
            ViewBag.id = id;
            if (values!=null)
                ViewBag.writerid=values.WriterID;
            return View(values);
        }
        [AllowAnonymous]
        //Yazarın Bloglarının listelenmesi
        public IActionResult BlogListByWriter()
        {
            var VerifiedAuthor = _authorUser;
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
                blog.WriterID = _authorUser.WriterID;
                blog.BlogCreateDate=System.DateTime.Now;
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
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        [HttpGet]
        public IActionResult BlogUpdate(int id)
        {

            var values = _blogService.TGetById(id);
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
                _blogService.TUpdate(blog);
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

        private Writer AuthorUser()
        {
            if (User.Identity.Name!=null)
            {
                int id = int.Parse(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);
                return _writerService.TGetById(1);
            }
            return null;
        }

        //GOTO 
        //YORUM SAYISI LİSTELENECEK 
    }
}
