using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Footer
{
	public class _FooterAboutPartial : ViewComponent
	{
		private readonly IAboutService _aboutService;

		public _FooterAboutPartial(IAboutService aboutService)
		{
			this._aboutService = aboutService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _aboutService.TGetList();
			return View(values);

		}
	}
}
