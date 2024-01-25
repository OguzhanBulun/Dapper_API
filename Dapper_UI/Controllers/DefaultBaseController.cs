using Microsoft.AspNetCore.Mvc;

namespace Dapper_UI.Controllers
{
    public class DefaultBaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
