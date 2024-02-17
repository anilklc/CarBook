using CarBook.Dto.Pricing;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminPricing")]
    public class AdminPricingController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7157/api/Pricings/GetAllPricing");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(data);
                JArray pricingArray = (JArray)jsonObject["pricings"];
                var values = pricingArray.ToObject<List<ResultPricingDto>>();
                return View(values);
            }
            return View();

        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult CreatePricing()
        {

            return View();

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreatePricing(CreatePricingDto createPricingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPricingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7157/api/Pricings/CreatePricing", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });
            }
            return View();
        }

        [Route("[action]/{id}")]
        public async Task<IActionResult> RemovePricing(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7157/api/Pricings/RemovePricing/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });
            }
            return View();

        }
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdatePricing(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var resposenMessage = await client.GetAsync($"https://localhost:7157/api/Pricings/GetByIdPricing/{id}");
            if (resposenMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposenMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdatePricingDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdatePricing(UpdatePricingDto updatePricingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatePricingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7157/api/Pricings/UpdatePricing", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });
            }
            return View();
        }
    }
}
