using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Comment
{
    public class _CommentAddBlog : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
