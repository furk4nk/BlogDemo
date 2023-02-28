﻿using BCrypt.Net;
using BlogDemo.Models;
using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace BlogDemo.Controllers
{
    
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
                    if (!_writerService.IsWriterControl(model.WriterMail))
                    {
                        if (model.WriterImage!=null)
                        {
                            var extension = Path.GetExtension(model.WriterImage.FileName);
                            var newImageName = Guid.NewGuid()+extension;
                            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/writerImageFile", newImageName);
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
            if (User.Identity.Name!=null)
            {
                values = _writerService.TGetList(x => x.WriterMail==User.Identity.Name).FirstOrDefault();
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
                    writer.CityID=1;
                    writer.DisctrictID=1;
                    writer.CountryID=1;
                    _writerService.TInsert(writer);
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
                Writer writer = _authorUser;
                writer.WriterPassword=model.newPassword;

                WriterValitator validations = new WriterValitator();
                ValidationResult result = validations.Validate(writer);
                if (result.IsValid)
                {
                    
                    if (!BCrypt.Net.BCrypt.Verify(model.oldPassword,_authorUser.WriterPassword))
                        _writerService.TUpdate(_authorUser, model.newPassword);
                    else
                    {
                        ModelState.AddModelError("", "Yeni Şifreniz Mevcut şifrenizle Aynı olamaz");
                        return View(model);
                    }
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    foreach ( var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.ErrorMessage);
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
            if (User.Identity.Name!=null)
            {
                return _writerService.TGetList(x => x.WriterMail==User.Identity.Name).FirstOrDefault();
            }
            return null;
        }
    }
}