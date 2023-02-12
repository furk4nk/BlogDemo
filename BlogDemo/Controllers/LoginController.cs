using BlogDemo.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogDemo.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly IWriterService _writerService;

		public LoginController(IWriterService writerService)
		{
			_writerService = writerService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				// return RedirectToAction("/Writer/Dashboard/"); eğer kullanıcı sisteme authenticate olduysa dashboarda yönelndirilsin ...
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserLoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var uservalues = _writerService.TGetList(x => x.WriterMail == model.Email);
				if (uservalues.Count != 0)
				{
					var result = BCrypt.Net.BCrypt.Verify(model.Password, uservalues[0].WriterPassword);
					if (result == true)
					{
						var claims = new List<Claim>
						{
							new Claim(ClaimTypes.Name,model.Email)
						};
						var userIdentity=new ClaimsIdentity(claims,"a ");
						ClaimsPrincipal principal= new ClaimsPrincipal(userIdentity);
						await HttpContext.SignInAsync(principal);
						return RedirectToAction("BlogListByWriter", "Blog",3 );		 // parametre gönderemedik goto
					}
				}
				ModelState.AddModelError("", "Email veya şifre hatalı");
			}
			return View();
		}
	}
}
