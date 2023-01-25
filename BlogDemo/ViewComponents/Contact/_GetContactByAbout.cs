using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Contact
{
	public class _GetContactByAbout :ViewComponent
	{
		private readonly IAboutService _aboutService;

		public _GetContactByAbout(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _aboutService.TGetList();
			return View(values);
		}
	}
}
