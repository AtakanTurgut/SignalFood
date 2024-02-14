using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalFoodWebUI.Dtos.ProductDtos;

namespace SignalFoodWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurMenuPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7116/api/Product");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData); // json -> string

                return View(values);
            }

            return View();
        }
    }
}
