using BlogDemo.Areas.Admin.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Abstract.UnitOfWork;
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
        private readonly IUnitOfWorkService _unitOfWorkService;

        public WriterController(IWriterService writerService, IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService= unitOfWorkService;
        }

        public IActionResult Index() => View();

        [HttpGet]
        public JsonResult GetWriterList()
        {
            var result = _unitOfWorkService.writerService.TGetList().Select(x => new WriterModel
            {
                ID=x.WriterID,
                WriterName =x.WriterName
            });
            return Json(result);
        }

        public IActionResult WriterInsert(Writer w)
        {
            w.WriterStatus=true;
            _unitOfWorkService.writerService.TInsert(w);
            _unitOfWorkService.TSaveChange();
            var result = JsonConvert.SerializeObject(w);
            return Json(result);
        }
        public IActionResult WriterDelete(int id)
        {
            var temp = _unitOfWorkService.writerService.TGetById(id);
            _unitOfWorkService.writerService.TDelete(temp);
            _unitOfWorkService.TSaveChange();
            return RedirectToAction("Index");
        }
        
    }
}
// yazarlar için ek onaylama gerekiyor yani normal kullanıcılar ile ayrım yapılamsı için admin tarafında yazar olmak isteyen kişiler
// için yazar rolünü onaylaması gerekiyor
// Yazar listesi için bir action oluşturmak gerekiyor tüm yazarlar advanced JGrid teknolojisiyle görüntülenmeli