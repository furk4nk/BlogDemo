using DocumentFormat.OpenXml.VariantTypes;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BlogDemo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class RoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager=roleManager;
        }

        public IActionResult Index(int? page)
		{
			int _page = page ?? 1;
			var values = _roleManager.Roles.ToPagedList(_page ,15);
			return View(values);
		}
		[HttpGet]
		public IActionResult RoleInsert()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> RoleInsert(AppRole role)
		{
			var result =await _roleManager.RoleExistsAsync(roleName: role.Name);
			if (!result)
			{
				await _roleManager.CreateAsync(role);
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Role Sistemde Zaten Mevcut");
			}
			return Redirect("/Admin/Role/Index");
		}
		public async Task<IActionResult> RoleDelete(int ID)
		{	
			var role = await _roleManager.FindByIdAsync(ID.ToString());
			var result = await _roleManager.DeleteAsync(role);
			if (result.Succeeded)
			{
				return Redirect("/Admin/Role/Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
                    ModelState.AddModelError(string.Empty,item.Description);
                }
			}
			return Redirect("/Admin/Role/Index");
		}
		[HttpGet]
		public async Task<IActionResult> RoleUpdate(int ID)
		{
			AppRole Role = await _roleManager.FindByIdAsync(ID.ToString());
			return View(Role);
		}
		[HttpPost]
		public async Task<IActionResult> RoleUpdate(AppRole role)
		{
			var result = _roleManager.RoleExistsAsync(roleName: role.Name);
			if (result.IsCompletedSuccessfully)
			{
				var Updated = await _roleManager.UpdateAsync(role);
				if (Updated.Succeeded)
				{
					return Redirect("/Admin/Role/Index");
				}
				else
				{
					foreach (var item in Updated.Errors)
					{
						ModelState.AddModelError(string.Empty, item.Description);
					}
				}
			}
			else ModelState.AddModelError(string.Empty, "Bu Rol Sistemde Mevcut");
			return View(role);
		}
	}
}