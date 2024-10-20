using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EState.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleManagementController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;

        public RoleManagementController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var list = _roleManager.Roles.ToList();
            return View(list);
        }

        public IActionResult RoleCreate()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoleCreate(IdentityRole model)
        {

            IdentityResult result = await _roleManager.CreateAsync(model);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View(model);
        }

        public async Task<IActionResult> DeleteRole(string id)
        {
            var delete = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(delete);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateRole(string id)
        {
            var update = await _roleManager.FindByIdAsync(id);
            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRole(IdentityRole data)
        {
            var update = await _roleManager.FindByIdAsync(data.Id);
            update.Name = data.Name;
            await _roleManager.UpdateAsync(update);
            return RedirectToAction("Index");
        }
    }
}
