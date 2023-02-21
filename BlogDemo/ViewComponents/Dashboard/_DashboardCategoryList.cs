using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Dashboard
{
    public class _DashboardCategoryList : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _DashboardCategoryList(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TGetList();
            return View(values);
        }
    }
}
