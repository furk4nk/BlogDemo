using BusinessLayer.Abstract;
using BusinessLayer.Abstract.UnitOfWork;
using BusinessLayer.Exceptions;
using BusinessLayer.FluentValidation;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BlogDemo.Areas.WriterPanel.Controllers
{
    [Area("WriterPanel")]
    [Authorize(Roles ="Yazar")]
    public class BlogController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public BlogController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        //Yazarın Bloglarının listelenmesi
        public IActionResult BlogListByWriter()
        {
            // Unit Of Work impelementasyonu kullanılıyor
            var values = _unitOfWorkService.BlogService.TGetBlogListByWriterWithCategory(Author().WriterID); 
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
            BlogValidator validations = new();
            ValidationResult result = validations.Validate(blog);
            if (result.IsValid)
            {
                blog.WriterID = Author().WriterID;
                blog.BlogCreateDate=System.DateTime.Now;
                _unitOfWorkService.BlogService.TInsert(blog);
                _unitOfWorkService.TSaveChange();
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
            Blog temp = _unitOfWorkService.BlogService.TGetList(x => x.BlogID == id).FirstOrDefault();
            _unitOfWorkService.BlogService.TDelete(temp);
            _unitOfWorkService.TSaveChange();
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        [HttpGet]
        public IActionResult BlogUpdate(int id)
        {
            var values = _unitOfWorkService.BlogService.TGetById(id);
            var CategoryValues = CategoryList();
            ViewBag.value = CategoryValues;
            return View(values);
        }
        [HttpPost]
        public IActionResult BlogUpdate(Blog blog)
        {
            BlogValidator validations = new();
            ValidationResult result = validations.Validate(blog);
            if (result.IsValid)
            {
                _unitOfWorkService.BlogService.TUpdate(blog);
                _unitOfWorkService.TSaveChange();
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
            var values = (from x in _unitOfWorkService.categoryService.TGetList()
                          select new SelectListItem
                          {
                              Text = x.CategoryName,
                              Value = x.CategoryID.ToString()
                          }).ToList();
            return values;
        }
        public IActionResult ChangeBlogStatus(int id)
        {
            var Values = _unitOfWorkService.BlogService.TGetById(id);
            Values.BlogStatus = Values.BlogStatus ? false : true;
                
            _unitOfWorkService.BlogService.TUpdate(Values);
            _unitOfWorkService.TSaveChange();
            return RedirectToAction("BlogListByWriter", "Blog");
		}
        private Writer Author()
        {
            Writer author = new();
            if (User.Identity.Name!=null)
            {
                int authorID = int.Parse(((ClaimsIdentity)User.Identity).FindFirst(type: ClaimTypes.NameIdentifier).Value);
                author =  _unitOfWorkService.writerService.TGetList(x => x.appUserID == authorID).FirstOrDefault();
                return author;
            }
            throw new InvalidWriterException(User.Identity.Name);
        }
    }
}