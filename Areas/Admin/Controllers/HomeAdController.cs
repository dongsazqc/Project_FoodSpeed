﻿using Microsoft.AspNetCore.Mvc;

namespace asm.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Login","Account" ,new { Area = "" });
        }
    }
}
