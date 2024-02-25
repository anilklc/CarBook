using CarBook.Dto.CarPricing;
using CarBook.Dto.RentACar;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(string id)
        {
            var Id = TempData["Id"];
            ViewBag.Id = Id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7157/api/RentACars/GetRentACarListByLocation/{Id}/true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(data);
                JArray carArray = (JArray)jsonObject["cars"];
                var values = carArray.ToObject<List<FilterRentACarDto>>();
                return View(values);
            }
            return View();
        }
    }
}
