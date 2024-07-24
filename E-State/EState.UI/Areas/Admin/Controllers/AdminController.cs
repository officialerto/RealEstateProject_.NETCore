using Microsoft.AspNetCore.Mvc;

namespace EState.UI.Areas.Admin.Controllers
{       
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
