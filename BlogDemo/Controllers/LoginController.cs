using BlogDemo.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Threading.Tasks;

namespace BlogDemo.Controllers
{
	public class LoginController : Controller
	{
		private readonly IWriterService _writerService;

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(UserLoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var uservalues = _writerService.TGetList(x => x.WriterMail == model.Email);
				if (uservalues.Count != 0)
				{
					var result = BCrypt.Net.BCrypt.Verify(model.Password, uservalues[0].WriterPassword);
					if (result == true)
					{
						return RedirectToAction("Index", "Blog");
					}
				}
				ModelState.AddModelError("", "Email veya şifre hatalı");
			}
			return View();

		}
	}
}
