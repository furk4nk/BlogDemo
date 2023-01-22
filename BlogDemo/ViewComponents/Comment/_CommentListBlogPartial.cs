using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogDemo.ViewComponents.Comment
{

    public class _CommentListBlogPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentListBlogPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.TGetList(x => x.BlogID == id);
            return View(values);
        }
    }
}
