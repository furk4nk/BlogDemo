using BlogDemo.Areas.Admin.Models;
using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace BlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    { 
    private readonly IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService=writerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetWriterList()
        {
            var result = _writerService.TGetList().Select(x => new WriterModel
            {
                ID=x.WriterID,
                WriterName =x.WriterName
            });
            return Json(result);
        }

        public IActionResult WriterInsert(Writer w)
        {
            w.WriterStatus=true;
            _writerService.TInsert(w);
            var result = JsonConvert.SerializeObject(w);
            return Json(result);
        }
        public IActionResult WriterDelete(int id)
        {
            var temp = _writerService.TGetById(id);
            _writerService.TDelete(temp);
            return RedirectToAction("Index");
        }
    }
}
// yazarlar için ek onaylama gerekiyor yani normal kullanıcılar ile ayrım yapılamsı için admin tarafında yazar olmak isteyen kişiler
// için yazar rolünü onaylaması gerekiyor