using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogDemo.Areas.WriterPanel.ViewComponents.Dashboard
{
    public class _DashboardBlogListByWriter : ViewComponent
    {
        private readonly IBlogService _blogService;
        private readonly IWriterService _writerService;
        private readonly UserManager<AppUser> _userManager;

        public _DashboardBlogListByWriter(IBlogService blogService, IWriterService writerService, UserManager<AppUser> userManager)
        {
            _blogService = blogService;
            _writerService = writerService;
            _userManager = userManager;

        }

        public IViewComponentResult Invoke()
        {
            int authorID = int.Parse(((ClaimsIdentity)User.Identity).FindFirst(type: ClaimTypes.NameIdentifier).Value);
            EntityLayer.Concrete.Writer author = _writerService.TGetList(x => x.appUserID == authorID).FirstOrDefault();
            var values = _blogService.TGetRecentBlogListByWriter(id: author.WriterID, 4);
            return View(values);
        }
    }
}
