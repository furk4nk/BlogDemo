using BlogDemo.Areas.Admin.Models;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace BlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
        [HttpGet]
        public IActionResult GetChartList() // count= kategoriyi kaç tane blog kullanıyor 
        {
            var values = _categoryService.TGetList().Select(x => new CategoryChartModel
            {
                Count = x.CategoryID,
                CategoryName= x.CategoryName
            });         
            return Json(values);
        }
    }
}
