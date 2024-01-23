using Microsoft.AspNetCore.Mvc;

namespace WowMagical.WebUI.Controllers
{
    public class PolarBearController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
