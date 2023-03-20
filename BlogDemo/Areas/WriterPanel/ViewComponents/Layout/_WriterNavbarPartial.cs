using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace BlogDemo.Areas.WriterPanel.ViewComponents.Layout
{
    public class _WriterNavbarPartial : ViewComponent
    {
        private readonly IWriterService _writerService;

        public _WriterNavbarPartial(IWriterService writerService)
        {
            _writerService=writerService;
        }

        public IViewComponentResult Invoke()
        {
            int authorID = int.Parse(((ClaimsIdentity)User.Identity).FindFirst(type: ClaimTypes.NameIdentifier).Value);
            EntityLayer.Concrete.Writer values = _writerService.TGetList(x => x.appUserID == authorID).FirstOrDefault();
            return View(values);
        }
    }
}
