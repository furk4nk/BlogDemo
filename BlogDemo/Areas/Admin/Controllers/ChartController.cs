using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        private readonly ICategoryService _categoryService;

        public ChartController(ICategoryService categoryService)
        {
            _categoryService=categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetChartList()
        {
            var values = _categoryService.TGetList();
            return Json("");
        }
    }
}
