﻿using Microsoft.AspNetCore.Mvc;

namespace Dapper_UI.ViewComponents.Layout
{
    public class _NavbarViewComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
