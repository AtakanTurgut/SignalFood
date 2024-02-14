using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalFoodWebUI.Dtos.TestimonialDtos;

namespace SignalFoodWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultTestimonialPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7116/api/Testimonial");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData); // json -> string

                return View(values);
            }

            return View();
        }
    }
}
