using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Footer
{
	public class _FooterPostPartial :ViewComponent
	{
		private readonly IBlogService _blogService;

		public _FooterPostPartial(IBlogService blogService)
		{
			_blogService= blogService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _blogService.TGetLastBlogs(3);
			return View(values);
		}
	}
}
