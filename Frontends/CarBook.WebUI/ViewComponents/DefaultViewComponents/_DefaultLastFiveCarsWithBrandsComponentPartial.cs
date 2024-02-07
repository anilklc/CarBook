using CarBook.Dto.CarWithBrand;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultLastFiveCarsWithBrandsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultLastFiveCarsWithBrandsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7157/api/Cars/GetLastFiveCarWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(data);
                JArray carAndBrandArray = (JArray)jsonObject["carAndBrandDto"];
                var values = carAndBrandArray.ToObject<List<ResultCarWithBrandDto>>();
                return View(values);
            }
            return View();


        }
    }
}
