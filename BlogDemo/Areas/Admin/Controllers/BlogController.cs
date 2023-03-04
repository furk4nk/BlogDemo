using BlogDemo.Areas.Admin.Models;
using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService=blogService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogTitleListExcell()
        {
            return View();
        }
        public IActionResult ExportDynamicsExcellBlogTitleList()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Çalışma 1");
                workSheet.Cell(1, 1).Value="ID";
                workSheet.Cell(1, 2).Value="Blog Başlığı";

                int RowNumber = 2;
                foreach (var item in GetBlogListByExcell())
                {
                    workSheet.Cell(row: RowNumber, column: 1).Value=item.ID;
                    workSheet.Cell(row: RowNumber, column: 2).Value=item.BlogTitle;
                    RowNumber++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Blog Listesi.xlxs");
                }

            }
        }

        private List<ExcellBlogViewModel> GetBlogListByExcell()
        {
            List<ExcellBlogViewModel> models = new List<ExcellBlogViewModel>();

            models = _blogService.TGetList().Select(x => new ExcellBlogViewModel
            {
                ID= x.CategoryID,
                BlogTitle = x.BlogTitle
            }).ToList();
            return models;
        }

    }

}
