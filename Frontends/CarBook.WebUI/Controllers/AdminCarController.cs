using CarBook.Dto.Brand;
using CarBook.Dto.Car;
using CarBook.Dto.CarWithBrand;
using CarBook.Dto.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7157/api/Cars/GetAllCarWithBrand");
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

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7157/api/Brands/GetAllBrand");
            var data = await responseMessage.Content.ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(data);
            JArray brandArray = (JArray)jsonObject["brands"];
            var values = brandArray.ToObject<List<ResultBrandDto>>();
            List<SelectListItem> brandValues = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.Id
                                                    }).ToList();
            ViewBag.BrandValues = brandValues;         
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7157/api/Cars/CreateCar", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
