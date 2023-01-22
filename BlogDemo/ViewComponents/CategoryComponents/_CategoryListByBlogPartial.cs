using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogDemo.ViewComponents.CategoryComponents
{
    public class _CategoryListByBlogPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoryListByBlogPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            List<Category> values = _categoryService.TGetList();
            return View(values);
        }
    }
}
