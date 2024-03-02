using CarBook.Dto.CarDescription;
using CarBook.Dto.CarFeature;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCarDescriptionByCarIdComponentPartial : ViewComponent
    {
		private readonly IHttpClientFactory _httpClientFactory;
		public _CarDetailCarDescriptionByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
            ViewBag.Id = Id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7157/api/CarDescriptions/GetCarDescriptionWithByCarId/{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(data);
                var values = jsonObject["carDescription"].ToObject<ResultCarDescriptionDto>();
				return View(values);
            }
            return View();

        }
    }
}
