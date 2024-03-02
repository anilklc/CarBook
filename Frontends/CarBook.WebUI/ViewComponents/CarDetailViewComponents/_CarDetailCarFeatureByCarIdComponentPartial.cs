using CarBook.Dto.CarFeature;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCarFeatureByCarIdComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _CarDetailCarFeatureByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(string Id)
		{
			ViewBag.Id=Id;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7157/api/CarFeatures/GetWithByCarId/{Id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				JObject jsonObject = JObject.Parse(data);
				JArray carFeatureArray = (JArray)jsonObject["carFeatures"];
				var values = carFeatureArray.ToObject<List<ResultCarFeatureByCarIdDto>>();
				return View(values);
			}
			return View();

		}
	}
}
