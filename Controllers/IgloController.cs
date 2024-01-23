using Microsoft.AspNetCore.Mvc;

namespace WowMagical.WebUI.Controllers
{
    public class IgloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
