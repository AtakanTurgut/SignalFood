using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalFoodWebUI.Dtos.FeatureDtos;

namespace SignalFoodWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultSliderPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSliderPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7116/api/Feature");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData); // json -> string

                return View(values);
            }

            return View();
        }

    }
}
