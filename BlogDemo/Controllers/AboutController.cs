using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
	[AllowAnonymous]
	public class AboutController : Controller
	{
		private readonly IAboutService _aboutService;

		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		public IActionResult Index()
		{
			var values = _aboutService.TGetList();
			return View(values);
		}

		public PartialViewResult SocialMedia()
		{
			return PartialView();
		}
	}
}
