﻿using Microsoft.AspNetCore.Mvc;

namespace Dapper_UI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
