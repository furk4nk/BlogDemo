using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
	public class NewsLetterController : Controller
	{
		private readonly INewsLetterService _newsLetterService;

		public NewsLetterController(INewsLetterService newsLetterService)
		{
			_newsLetterService = newsLetterService;
		}
		[HttpGet]
		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult SubscribeMail(NewsLetter newsLetter)
		{
			newsLetter.MailStatus = true;
			_newsLetterService.TInsert(newsLetter);
			return PartialView();
		}
	}
}
