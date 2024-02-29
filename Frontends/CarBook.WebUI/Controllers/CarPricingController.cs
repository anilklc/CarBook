﻿using CarBook.Dto.CarWithBrandWithPricing;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public CarPricingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7157/api/Cars/GetCarWithBrandWithPricing");
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				JObject jsonObject = JObject.Parse(data);
				JArray brandArray = (JArray)jsonObject["cars"];
				var values = brandArray.ToObject<List<ResultCarAndBrandAndPricingDto>>();
				return View(values);
			}
			return View();

		}
	}
}
