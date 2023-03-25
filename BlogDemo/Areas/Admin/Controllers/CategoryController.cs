using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService=categoryService;
        }

        public IActionResult Index(int? page)
        {
            int _page = page ?? 1;
            var values = _categoryService.TGetList().ToPagedList(_page,10); 
            return View(values);
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            CategoryValidator validations = new CategoryValidator();
            ValidationResult result = validations.Validate(category);
            if (result.IsValid)
            {
                category.CategoryStatus=true;
                _categoryService.TInsert(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View(category);
        }
        public IActionResult CategoryDelete(int id)
        {
            var temp = _categoryService.TGetById(id);
            _categoryService.TDelete(temp);
            return RedirectToAction("Index", "Category");
        }
        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {
            var values = _categoryService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category category)
        {
            CategoryValidator validations = new CategoryValidator();
            ValidationResult result = validations.Validate(category);
            if (result.IsValid)
            {
                category.CategoryStatus=true;
                _categoryService.TUpdate(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View(category);
        }
        public IActionResult CategoryStatusChange(int id)
        {
            var value = _categoryService.TGetById(id);
            if (value.CategoryStatus)            
                value.CategoryStatus = false;
            else
                value.CategoryStatus = true;
            _categoryService.TUpdate(value);
            return RedirectToAction("index", "Category");
        }
         
    }
}
