using BlogDemo.Models;
using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace BlogDemo.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }
        [HttpGet]
        public IActionResult WriterInsert()
        {
            return View();
        }
        /// <summary>
        /// yazar eklemek için gerekli olan validasyon kontrolleri ve dosya yükleme işlemlerinin yapıldığı statment 
        /// </summary>
        /// <param name="model"> Entity ile ilişkili IFromFile türünde ımage alan bir model oluşturuldu</param>
        /// <returns>IActionResult türünde bir View() dönmekte</returns>
        [HttpPost]
        public IActionResult WriterInsert(WriterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Writer writer = new Writer()
                {
                    WriterAbout= model.WriterAbout,
                    WriterMail= model.WriterMail,
                    WriterName= model.WriterName,
                    WriterPassword= model.WriterPassword,
                    WriterStatus=model.WriterStatus,
                    CityID=1,
                    CountryID=1,
                    DisctrictID=1
                };
                WriterValitator validations = new WriterValitator();
                ValidationResult result = validations.Validate(writer);
                if (result.IsValid)
                {
                    if (model.WriterImage!=null)
                    {
                        var extension = Path.GetExtension(model.WriterImage.FileName);
                        var newImageName = Guid.NewGuid()+extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/writerImageFile",newImageName);
                        var stream = new FileStream(location, FileMode.Create);
                        model.WriterImage.CopyTo(stream);
                        writer.WriterImage= newImageName;
                        _writerService.TInsert(writer, writer.WriterPassword);
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Lütfen Bir Dosya Seçiniz");
                    }
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateWriter() // veriler kaydedilirken cityId bilgisi eklenmeklidir
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateWriter(Writer writer)
        {
            return View();
        }
    }
}
