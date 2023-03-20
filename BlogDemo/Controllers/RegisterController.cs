using BlogDemo.Models;
using BusinessLayer.Abstract;
using BusinessLayer.ActionFilters;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWriterService _writerService;
        public RegisterController(UserManager<AppUser> userManager, IWriterService writerService)
        {
            this._userManager = userManager;
            this._writerService=writerService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    NameSurname = model.NameSurname.Trim(),
                    NormalizedNameSurname= model.NameSurname.Trim().ToUpper(),
                    Email = model.Email.Trim(),
                    UserName=model.UserName.Trim()
                };
                UserValidator validations = new UserValidator();
                ValidationResult result = validations.Validate(user);
                if (result.IsValid)
                {
                    if (model.Accept)
                    {
                        IdentityResult ıdentityResult = await _userManager.CreateAsync(user, model.Password);
                        if (ıdentityResult.Succeeded)
                        {
                            return RedirectToAction("Index", "Login");
                        }
                        else
                        {
                            foreach (var item in ıdentityResult.Errors)
                            {
                                ModelState.AddModelError("", errorMessage: item.Description);
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Accept", "Lütfen Kullanım Şartlarını Kabul ediniz");
                    }
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View(model);
        }
    }
}