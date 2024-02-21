using CarBook.Dto.Statistics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            #region
            var responseMessage = await client.GetAsync("https://localhost:7157/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCount = values.carCount;
            }
            #endregion

            #region
            var responseMessage2 = await client.GetAsync("https://localhost:7157/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.locationCount = values2.locationCount;
            }
            #endregion

            #region
            var responseMessage3 = await client.GetAsync("https://localhost:7157/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.authorCount = values3.authorCount;
            }
            #endregion

            #region
            var responseMessage4 = await client.GetAsync("https://localhost:7157/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.blogCount = values4.blogCount;
            }
            #endregion

            #region
            var responseMessage5 = await client.GetAsync("https://localhost:7157/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.brandCount = values5.brandCount;
            }
            #endregion

            #region
            var responseMessage6 = await client.GetAsync("https://localhost:7157/api/Statistics/GetAvgRentPrice");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.daily = values6.daily.ToString("0.00"); ;
                ViewBag.weekly = values6.weekly.ToString("0.00"); ;
                ViewBag.monthly = values6.monthly.ToString("0.00"); ;
            }
            #endregion


            #region
            var responseMessage7 = await client.GetAsync("https://localhost:7157/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage7.IsSuccessStatusCode)
            {
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.brandName = values7.brandName;
            }
            #endregion

            #region
            var responseMessage8 = await client.GetAsync("https://localhost:7157/api/Statistics/GetCarCountByKm");
            if (responseMessage8.IsSuccessStatusCode)
            {
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.km = values8.km;
            }
            #endregion

            #region
            var responseMessage9 = await client.GetAsync("https://localhost:7157/api/Statistics/GetCarCountByFuel");
            if (responseMessage9.IsSuccessStatusCode)
            {
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.gasoline = values9.gasoline;
                ViewBag.electric = values9.electric;
            }
            #endregion


            return View();
        }
    }
}
