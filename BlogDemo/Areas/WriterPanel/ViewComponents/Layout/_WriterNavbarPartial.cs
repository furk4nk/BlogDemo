using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var values = _writerService.TGetById(int.Parse(((ClaimsIdentity)User.Identity).FindFirst(type: ClaimTypes.NameIdentifier).Value));
            return View(values);
        }
    }
}
