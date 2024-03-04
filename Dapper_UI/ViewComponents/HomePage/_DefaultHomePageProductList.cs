using Dapper_UI.DTOModels.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultHomePageProductList : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _DefaultHomePageProductList(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:44326/api/Product/ListProductsWithCategory");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<List<ProductDTOViewModel>>(data);

                return View(products);
            }

            return View();
        }
    }
}
