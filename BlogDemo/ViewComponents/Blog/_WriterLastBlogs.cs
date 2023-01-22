using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Blog
{
	public class _WriterLastBlogs : ViewComponent
	{
		private readonly IBlogService _blogService;

		public _WriterLastBlogs(IBlogService blogService)
		{
			_blogService = blogService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _blogService.TGetWriteLastByBlog(1);
			return View(values);
		}
	}
}
