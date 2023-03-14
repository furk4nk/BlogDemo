using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogDemo.Areas.WriterPanel.ViewComponents.Layout
{
    public class _WriterSidebarPartial : ViewComponent
    {
        private readonly IWriterService _writerService;

        public _WriterSidebarPartial(IWriterService writerService)
        {
            _writerService=writerService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _writerService.TGetById(int.Parse(((ClaimsIdentity)User.Identity).FindFirst(type:ClaimTypes.NameIdentifier).Value));
            return View(values);
        }
    }
}
