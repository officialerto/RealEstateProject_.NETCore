using EntityLayer.Entities;
using EState.UI.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EState.UI.Areas.User.Controllers
{
    [Area("User")]
    //[Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private UserManager<UserAdmin> _userManager;
        private SignInManager<UserAdmin> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<UserAdmin> userManager, SignInManager<UserAdmin> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "Böyle bir kullanıcı yok.");
            }

            if (await _userManager.IsLockedOutAsync(user))
            {
                ModelState.AddModelError("", "Kullanıcı bir süreliğine kitlendi.");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (result.Succeeded)
            {
                await _userManager.ResetAccessFailedCountAsync(user);

                HttpContext.Session.SetString("Id", user.Id);
                HttpContext.Session.SetString("FullName", user.FullName);
                return RedirectToAction("Index");
            }

            else
            {
                await _userManager.AccessFailedAsync(user);

                int fail = await _userManager.GetAccessFailedCountAsync(user);

                if (fail == 3)
                {
                    await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(2)));
                }

                else
                {
                    ModelState.AddModelError("", "Hatalı eposta veya şifre");
                }
            }

            return View();
        }

        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UserAdmin user = new UserAdmin()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
            };

            IdentityRole role = new IdentityRole()
            {
                Name = "User"
            };

            await _roleManager.CreateAsync(role);

            var result = await _userManager.CreateAsync(user, model.Password);

            var resultt = await _userManager.AddToRoleAsync(user, role.Name);

            if (result.Succeeded || resultt.Succeeded)
            {
                return RedirectToAction("Index");
            }

            else
            {
                result.Errors.ToList().ForEach(x => ModelState.AddModelError("", x.Description));
                return View(model);
            }
        }
    }
}
