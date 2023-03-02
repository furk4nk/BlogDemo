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
		CountryManager country = new CountryManager(new EfCountryDal());
		CityManager cm = new CityManager(new EfCityDal());
		private readonly IWriterService _writerService;

		public RegisterController(IWriterService writerService)
		{
			_writerService = writerService;
		}

		[HttpGet]
		public IActionResult Index()
		{			
			ViewBag.v1 = CountryList();
			ViewBag.v2 = CityList(1);
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
				CountryID = model.CountryID,
				CityID = model.CityID,
				WriterStatus = true
            };
			WriterValitator validations = new WriterValitator();
			ValidationResult result = validations.Validate(writer);
			if (result.IsValid)
			{
				_writerService.TInsert(writer,model.WriterPassword);
				return RedirectToAction("Index", "Blog");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			ViewBag.v1 = CountryList();
			ViewBag.v2 = CityList(1);
			return View();
		}
		private List<SelectListItem> CountryList()
		{
			List<SelectListItem> liste = (from x in country.TGetList()
										  orderby x.CountryName ascending
										  select new SelectListItem
										  {
											  Text = x.CountryName,
											  Value = x.CountryID.ToString()
										  }).ToList();
			return liste;
		}
		private List<SelectListItem> CityList(int id)
		{
			List<SelectListItem> liste = (from x in cm.TGetList(x=>x.CountryID==id)
										   orderby x.CityName ascending
										   select new SelectListItem
										   {
											   Text = x.CityName,
											   Value = x.CityID.ToString()
										   }).ToList();
			return liste;
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