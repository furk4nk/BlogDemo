using BlogDemo.Areas.ApiDemo.Models;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BlogDemo.Areas.ApiDemo.Controllers
{
    [Area("ApiDemo")]
    public class BlogApiController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44319/api/v1/Blogs");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ApiViewModel>>(value: jsonString).OrderByDescending(keySelector: x => x.BlogCreateDate)
                .ToPagedList(pageNumber: page, pageSize: 15);
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> BlogInsert() // KAtegori listesi drowdown list olarak gitmeli
        {
            HttpClient client = new();
            var responseMessage = await client.GetAsync("https://localhost:44319/api/V1/Category");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<SelectListItem>>(value: jsonString);
            ViewBag.value=values;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BlogInsert(ApiViewModel model)
        {
            model.CategoryID=1;
            model.WriterID=1;
            HttpClient httpClient = new();
            var values = JsonConvert.SerializeObject(model);
            StringContent content = new(content: values, encoding: Encoding.UTF8, mediaType: "application/json");
            var responseMessage = await httpClient.PostAsync(requestUri: "https://localhost:44319/api/v1/Blogs", content: content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(viewName: "BlogInsert", model: model);

        }
        public async Task<IActionResult> BlogDelete(int id)
        {
            HttpClient http = new();
            var responseMessage = await http.DeleteAsync(requestUri: "https://localhost:44319/api/v1/Blogs/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(actionName: "Index", controllerName: "BlogApi", routeValues: new { area = "ApiDemo" });
            }
            else
            {
                ModelState.AddModelError(key: "", errorMessage: responseMessage.RequestMessage.ToString());
                return RedirectToAction(actionName: "Index", controllerName: "BlogApi", routeValues: new { area = "ApiDemo" });
            }
        }
        [HttpGet]
        public async Task<ActionResult> BlogUpdate(int id)
        {
            HttpClient httpClient = new();
            var responseMessage = await httpClient.GetAsync("https://localhost:44319/api/v1/Blogs/"+id);
            var jsonstring = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ApiViewModel>(value: jsonstring);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> BlogUpdate(ApiViewModel model)
        {
            HttpClient httpClient = new();
            string jsonString = JsonConvert.SerializeObject(value: model);
            StringContent content = new(content: jsonString, encoding: Encoding.UTF8, mediaType: "application/json");
            var responseMessage = await httpClient.PutAsync(requestUri: "https://localhost:44319/api/v1/Blogs", content: content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(actionName: "Index", controllerName: "BlogApi", routeValues: new { area = "ApiDemo" });
            }
            else
            {
                ModelState.AddModelError(key: "", errorMessage: responseMessage.RequestMessage.ToString() + responseMessage.StatusCode);
                return View();
            }
        }
    }
}