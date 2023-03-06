using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace BlogDemo.Areas.Admin.ViewComponents.Widgets
{
    public class _WidgetRow1 : ViewComponent
    {
        private readonly IBlogService _blogService;
        private readonly IMessage2Service _message2Service;
        private readonly ICommentService _commentService;

        public _WidgetRow1(IBlogService blogService, IMessage2Service message2Service, ICommentService commentService)
        {
            _blogService=blogService;
            _message2Service=message2Service;
            _commentService=commentService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.blogcount= _blogService.TGetCount();
            ViewBag.messagecount = _message2Service.TGetCount();
            ViewBag.commentcount = _commentService.TGetCount();

            string apiKey = "b4354113146ab97cfeaad8498aea4785";
            string cityName = "istanbul";
            string location = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&mode=xml&lang=tr&&units=metric&appid={apiKey}";
            XDocument document = XDocument.Load(location);
            ViewBag.weadher=document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.cityName=cityName;
            return View();
        }
    }
}
