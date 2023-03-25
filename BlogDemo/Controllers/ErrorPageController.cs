using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult ErrorPageNotFound(int code)
		{			
			return View();
		}	
		public IActionResult AccessDenied()
		{
			return View();
		}

    }
}
