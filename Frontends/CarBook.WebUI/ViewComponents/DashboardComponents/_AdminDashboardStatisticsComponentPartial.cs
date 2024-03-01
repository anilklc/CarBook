using CarBook.Dto.Statistics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


         public async Task<IViewComponentResult> InvokeAsync()
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
                 var responseMessage3 = await client.GetAsync("https://localhost:7157/api/Statistics/GetBrandCount");
                 if (responseMessage3.IsSuccessStatusCode)
                 {
                     var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                     var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                     ViewBag.brandCount = values3.brandCount;
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
                 return View();
             }
    }
}
