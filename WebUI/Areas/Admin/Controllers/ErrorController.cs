﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class ErrorController : Controller
    {
        [Area("Admin")]
        public IActionResult WentWrong()
        {
            return View();
        }
    }
}
