using BlogDemo.Areas.WriterPanel.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Abstract.UnitOfWork;
using BusinessLayer.Exceptions;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogDemo.Areas.WriterPanel.Controllers
{
    [Area("WriterPanel")]
    [Authorize(Roles ="Yazar")]
    public class WriterController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager, IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService= unitOfWorkService;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult WriterInsert()
        {
            return View();
        }
        /// <summary>
        /// yazar eklemek için gerekli olan validasyon kontrolleri ve dosya yükleme işlemlerinin yapıldığı statment 
        /// </summary>
        /// <param name="model"> Entity ile ilişkili IFromFile türünde ımage alan bir model oluşturuldu</param>
        /// <returns>IActionResult türünde bir View() dönmekte</returns>
        [HttpPost]
        public IActionResult WriterInsert(WriterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Writer writer = new()
                {
                    WriterAbout = model.WriterAbout,
                    WriterMail = model.WriterMail,
                    WriterName = model.WriterName,
                    WriterPassword = model.WriterPassword,
                    WriterStatus = true
                };
                WriterValitator validations = new();
                ValidationResult result = validations.Validate(writer);
                if (result.IsValid)
                {
                    if (!_unitOfWorkService.writerService.IsWriterControl(model.WriterMail))
                    {
                        if (model.WriterImage != null)
                        {
                            var extension = Path.GetExtension(model.WriterImage.FileName);
                            var newImageName = Guid.NewGuid() + extension;
                            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/writerImageFile", newImageName);
                            var stream = new FileStream(location, FileMode.Create);
                            model.WriterImage.CopyTo(stream);
                            writer.WriterImage = "/writerImageFile/" + newImageName;
                            return View();
                        }
                        else
                        {
                            writer.WriterImage = Path.Combine("/writerImageFile", "user.png");
                        }

                        _unitOfWorkService.writerService.TInsert(writer);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bu Mail Adresi sistemde kayıtlı");
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

        [HttpGet]
        public async Task<IActionResult> UpdateWriter()
        {
            Writer _authorUser = AuthorUser();

            if (User.Identity.Name == null)
                return View(null);
            var aspUser = await _userManager.FindByNameAsync(User.Identity.Name);
            WriterUpdateViewModel model = new()
            {
                ID=aspUser.Id,
                WriterImage = null,
                NameSurname = aspUser.NameSurname,
                UserName = aspUser.UserName,
                Email =aspUser.Email,
                WriterAbout = _authorUser.WriterAbout
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWriter(WriterUpdateViewModel model) // Güncellenen Email Değeri sistemde Güncellenmiyor Claimler ile halledilmeli
        {
            Writer _authorUser = AuthorUser();

            Writer writer = _authorUser;
            writer.WriterName=model.NameSurname;
            writer.WriterAbout=model.WriterAbout;
            writer.WriterMail=model.Email;

            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                WriterValitator validations = new();
                ValidationResult result1 = validations.Validate(writer);
                if (result1.IsValid)
                {
                    user.Email=model.Email;
                    user.NameSurname = model.NameSurname;
                    user.NormalizedNameSurname=model.NameSurname.Trim().ToUpper();
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        if (result.Succeeded)
                        {
                            _unitOfWorkService.writerService.TUpdate(writer);
                        }
                        return Redirect("/WriterPanel/Dashboard");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty,item.Description);
                        }
                    }
                }
                else
                {
                    foreach (var item in result1.Errors)
                    {
                        ModelState.AddModelError(string.Empty,errorMessage:item.ErrorMessage);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult PasswordChange()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PasswordChange(WriterPasswordChangeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var IdentityResult = await _userManager.ChangePasswordAsync(user,model.oldPassword,model.newPassword);
                if (IdentityResult.Succeeded)
                {
                    return Redirect("/WriterPanel/Dashboard");
                }
                else
                {
                    foreach (var item in IdentityResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty,item.Description);
                    }
                }
            }
            return View();
        }
        private Writer AuthorUser()
        {
            if (User.Identity.Name != null)
            {
                int authorID = int.Parse(((ClaimsIdentity)User.Identity).FindFirst(type: ClaimTypes.NameIdentifier).Value);
                var values = _unitOfWorkService.writerService.TGetList(x => x.appUserID == authorID).FirstOrDefault();
                return values;
            }   
            throw new InvalidWriterException(User.Identity.Name);
        }
    }
}