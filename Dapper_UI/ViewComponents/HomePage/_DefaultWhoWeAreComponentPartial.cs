using Microsoft.AspNetCore.Mvc;

namespace Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {       
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
