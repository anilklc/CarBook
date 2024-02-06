using CarBook.Dto.About;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.ViewComponents.AboutViewCompenents
{
    public class _AboutUsComponentPartial : ViewComponent
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7157/api/Abouts/GetAllAbout");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(data);
                JArray aboutsArray = (JArray)jsonObject["abouts"];
                var values = aboutsArray.ToObject<List<ResultAboutDto>>();
                return View(values);
            }
            return View();
        }
    }
}
