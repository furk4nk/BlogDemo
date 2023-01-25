using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogDemo.ViewComponents.Blog
{
	public class _LastRecentBlog : ViewComponent
	{
		private readonly IBlogService _blogService;

		public _LastRecentBlog(IBlogService blogService)
		{
			_blogService = blogService;
		}

		public IViewComponentResult Invoke(int count)
		{
			var values = _blogService.TGetLastBlogs(count);			
			return View(values);
		}
	}
}
