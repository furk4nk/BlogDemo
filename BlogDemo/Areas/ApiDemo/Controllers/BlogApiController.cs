using BlogDemo.Areas.ApiDemo.Models;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using Microsoft.AspNetCore.Mvc;
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
            var value = JsonConvert.DeserializeObject<List<ApiViewModel>>(value: jsonString).OrderByDescending(keySelector: x => x.date).ToPagedList(pageNumber: page, pageSize: 15); ;
            return View(value);
        }
        [HttpGet]
        public IActionResult BlogInsert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BlogInsert(ApiViewModel model)
        {
            model.BlogType="t";
            HttpClient httpClient = new HttpClient();
            var values = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(content: values, encoding: Encoding.UTF8, mediaType: "application/json");
            var responseMessage = await httpClient.PostAsync(requestUri: "https://localhost:44319/api/v1/Blogs", content: content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(viewName: "BlogInsert", model: model);

        }
        public async Task<IActionResult> BlogDelete(Guid id)
        {
            HttpClient http = new HttpClient();
            var responseMessage = await http.DeleteAsync(requestUri: "https://localhost:44319/api/v1/Blogs/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(actionName: "Index", controllerName: "BlogApi", routeValues: "ApiDemo");
            }
            else
            {
                ModelState.AddModelError(key: "", errorMessage: responseMessage.RequestMessage.ToString());
                return RedirectToAction(actionName: "Index", controllerName: "BlogApi", routeValues: "ApiDemo");
            }
        }
        [HttpGet]
        public async Task<ActionResult> BlogUpdate(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44319/api/v1/Blogs/"+id);
            var jsonstring = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ApiViewModel>(value: jsonstring);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> BlogUpdate(ApiViewModel model)
        {
            HttpClient httpClient = new HttpClient();
            string jsonString = JsonConvert.SerializeObject(value: model);
            StringContent content = new StringContent(content: jsonString, encoding: Encoding.UTF8, mediaType: "application/json");
            var responseMessage = await httpClient.PutAsync(requestUri: "https://localhost:44319/api/v1/Blogs", content: content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(actionName: "Index", controllerName: "BlogApi", routeValues: "ApiDemo");
            }
            else
            {
                ModelState.AddModelError(key: "", errorMessage: responseMessage.RequestMessage.ToString() + responseMessage.StatusCode);
                return View();
            }
        }
    }
}