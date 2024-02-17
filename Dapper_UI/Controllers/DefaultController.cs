using Microsoft.AspNetCore.Mvc;

namespace Dapper_UI.Controllers
{
    public class Default : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
