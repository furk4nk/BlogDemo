using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
    public class CommentController : Controller
	{	
		private readonly ICommentService _commentService;

		public CommentController(ICommentService commentService)
		{
			_commentService = commentService;
		}
		[HttpGet]
		public PartialViewResult AddComment()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult AddComment(Comment comment)
		{
			comment.CommentDate=System.DateTime.Now;
			comment.CommentStatus = true;
			_commentService.TInsert(comment);
			return PartialView();
		}
	}
}
