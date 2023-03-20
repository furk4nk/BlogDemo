using BlogDemo.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IWriterService _writerService;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(IWriterService writerService , SignInManager<AppUser> signInManager)
        {
            this._signInManager=signInManager;
            _writerService = writerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard", new { area = "WriterPanel" });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Dashboard",new {area="WriterPanel"});
                }
                else
                {
                    ModelState.AddModelError("","Kullanıcı Adı veya Şifre Hatalı");
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
