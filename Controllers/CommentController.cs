﻿using Microsoft.AspNetCore.Mvc;

namespace WowMagical.WebUI.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
