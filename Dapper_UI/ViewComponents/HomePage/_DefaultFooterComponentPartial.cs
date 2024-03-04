using Microsoft.AspNetCore.Mvc;

namespace Dapper_UI.ViewComponents.HomePage

{
    public class _DefaultFooterComponentPartial : ViewComponent
    {   
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
