using BlogDemo.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Abstract.UnitOfWork;
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
        public RegisterController(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
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
                AppUser user = new()
                {
                    NameSurname = model.NameSurname.Trim(),
                    NormalizedNameSurname= model.NameSurname.Trim().ToUpper(),
                    Email = model.Email.Trim(),
                    UserName=model.UserName.Trim()
                };
                UserValidator validations = new();
                ValidationResult result = validations.Validate(user);
                if (result.IsValid)
                {
                    if (model.Accept)
                    {
                        IdentityResult ıdentityResult = await _userManager.CreateAsync(user, model.Password);
                        if (ıdentityResult.Succeeded)
                        {
                            user = await _userManager.FindByNameAsync(user.UserName);
                            await _userManager.AddToRoleAsync(user, "Kullanici");
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