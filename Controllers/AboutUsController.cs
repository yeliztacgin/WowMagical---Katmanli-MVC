﻿using Microsoft.AspNetCore.Mvc;

namespace WowMagical.WebUI.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
