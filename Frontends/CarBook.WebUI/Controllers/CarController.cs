﻿using CarBook.Dto.CarPricing;
using CarBook.Dto.CarWithBrand;
using CarBook.Dto.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7157/api/Cars/GetCarWithPricingDay");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(data);
                JArray carAndBrandArray = (JArray)jsonObject["carAndPricings"];
                var values = carAndBrandArray.ToObject<List<ResultCarPricingDto>>();
                return View(values);
            }
            return View();
        }
        
        public async Task<IActionResult> CarDetail(string Id)
        {
            ViewBag.Id = Id;
            return View();
        }
    }
}

