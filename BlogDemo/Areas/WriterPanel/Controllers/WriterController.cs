using BCrypt.Net;
using BlogDemo.Areas.WriterPanel.Models;
using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace BlogDemo.Areas.WriterPanel.Controllers
{
    [Area("WriterPanel")]
    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;
        private Writer _authorUser => AuthorUser();

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
                    WriterAbout = model.WriterAbout,
                    WriterMail = model.WriterMail,
                    WriterName = model.WriterName,
                    WriterPassword = model.WriterPassword,
                    WriterStatus = true
                };
                WriterValitator validations = new WriterValitator();
                ValidationResult result = validations.Validate(writer);
                if (result.IsValid)
                {
                    if (!_writerService.IsWriterControl(model.WriterMail))
                    {
                        if (model.WriterImage != null)
                        {
                            var extension = Path.GetExtension(model.WriterImage.FileName);
                            var newImageName = Guid.NewGuid() + extension;
                            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/writerImageFile", newImageName);
                            var stream = new FileStream(location, FileMode.Create);
                            model.WriterImage.CopyTo(stream);
                            writer.WriterImage = "/writerImageFile/" + newImageName;
                            return View();
                        }
                        else
                        {
                            writer.WriterImage = Path.Combine("/writerImageFile", "user.png");
                        }

                        _writerService.TInsert(writer);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bu Mail Adresi sistemde kayıtlı");
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
            Writer values = new Writer();
            if (User.Identity.Name != null)
            {
                values = _writerService.TGetById(_authorUser.WriterID);
            }
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateWriter(Writer writer)
        {
            if (ModelState.IsValid)
            {
                WriterValitator validations = new WriterValitator();
                ValidationResult validation = validations.Validate(writer);
                if (validation.IsValid)
                {
                    writer.WriterStatus = true;
                    _writerService.TUpdate(writer);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    foreach (var item in validation.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View(writer);
        }

        [HttpGet]
        public IActionResult PasswordChange()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PasswordChange(WriterPasswordChangeViewModel model)
        {
            if (BCrypt.Net.BCrypt.Verify(model.oldPassword, _authorUser.WriterPassword))
            {   //validasyon kontrolü yapılması gerekiyor yeni şifre kurallara uygun olması gerekiyor
                Writer Ctrlwriter = _authorUser;  // kkontrol edeceğimiz yazar değerleri
                Ctrlwriter.WriterPassword = model.newPassword;

                WriterValitator validations = new WriterValitator();
                ValidationResult result = validations.Validate(Ctrlwriter);
                if (result.IsValid)
                {

                    if (!BCrypt.Net.BCrypt.Verify(model.oldPassword, _authorUser.WriterPassword))
                    {
                        _authorUser.WriterPassword = model.newPassword;
                        _writerService.TUpdate(_authorUser);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Yeni Şifreniz Mevcut şifrenizle Aynı olamaz");
                        return View(model);
                    }
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.ErrorMessage);
                    }
                }
            }
            else  // Şifre yanlış girilirse verilecek uyarı
            {
                ModelState.AddModelError("", "Şifreniz yanlış");
            }
            return View();
        }
        private Writer AuthorUser()
        {
            if (User.Identity.Name != null)
            {
                int id = int.Parse(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);
                return _writerService.TGetById(id);
            }
            return null;
        }
    }
}
// author user refactor edilecek 02/03/2023