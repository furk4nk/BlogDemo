﻿using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BlogDemo.Areas.WriterPanel.Controllers
{
    [Area("WriterPanel")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private int _authorUserID => AuthorUser();
        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;            
            _categoryService = categoryService;
        }

        //Yazarın Bloglarının listelenmesi
        public IActionResult BlogListByWriter()
        {
            var values = _blogService.TGetBlogListByWriterWithCategory(_authorUserID);
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
                blog.WriterID = _authorUserID;
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
        private int AuthorUser()
        {
            if (User.Identity.Name!=null)
            {
                return int.Parse(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);
            }
            return 0;
        }
    }
}