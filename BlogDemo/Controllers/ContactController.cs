using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			this._contactService = contactService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			ContactValidator validations = new ContactValidator();
			ValidationResult result = validations.Validate(contact);
			if (result.IsValid)
			{
				_contactService.TInsert(contact);
				return RedirectToAction("Index");
			}
			else
			{
				foreach(var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View(contact);
		}
	}
}
