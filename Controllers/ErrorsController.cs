using Microsoft.AspNetCore.Mvc;

namespace WowMagical.WebUI.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
