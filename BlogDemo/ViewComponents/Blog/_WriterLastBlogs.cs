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

		public IViewComponentResult Invoke(int id)
		{
			
			var values = _blogService.TGetBlogListByWriter(id);
			return View(values);
		}
	}
}
