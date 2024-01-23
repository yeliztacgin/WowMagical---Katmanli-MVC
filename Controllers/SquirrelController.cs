using Microsoft.AspNetCore.Mvc;

namespace WowMagical.WebUI.Controllers
{
    public class SquirrelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
