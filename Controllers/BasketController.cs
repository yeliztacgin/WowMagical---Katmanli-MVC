using Microsoft.AspNetCore.Mvc;

namespace WowMagical.WebUI.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
