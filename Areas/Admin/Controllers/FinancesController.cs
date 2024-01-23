using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WowMagical.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FinancesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
