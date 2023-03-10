using BlogDemo.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;

namespace BlogDemo.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		private readonly IWriterService _writerService;

		public RegisterController(IWriterService writerService)
		{
			_writerService = writerService;
		}

		[HttpGet]
		public IActionResult Index()
		{			
			return View();
		}

		[HttpPost]
		public IActionResult Index(UserRegisterViewModel model)
		{
			Writer writer = new Writer()
			{
				WriterName = model.WriterName,
				WriterMail = model.WriterMail,
				WriterPassword = model.WriterPassword,
				WriterStatus = true
            };
			WriterValitator validations = new WriterValitator();
			ValidationResult result = validations.Validate(writer);
			if (result.IsValid)
			{
				_writerService.TInsert(writer);
				return RedirectToAction("Index", "Blog");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
	}
}
#region

// şehirler tabloları business ktamamnına eklenecek 
// register sayfası düzenlenecek
// readmore sayfasında son post gösterilecek 
//şehirler listelenecek
//goto 
// geri kalan kısmı unuttum
//GOTO 
// BYRCİPT EKLENECEK ŞİFRE KONTROLÜ (yapıldı)
//VALİDASYON İÇİN MODEL ORTADAN KALDIRILIP WRİTER İLE ÇALIŞMA BAĞIMLILIĞINI ORTADAN KALDIRMAMIZ GEREKİYOR (yapıldı)
//login ekranı düzenlenecek

#endregion