using CarBook.Dto.Blog;
using CarBook.Dto.TagCloud;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCloudTagByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailCloudTagByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
            ViewBag.Id = Id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7157/api/TagClouds/GetAllTagCloudById" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(data);
                JArray tagCloudArray = (JArray)jsonObject["tagClouds"];
                var values = tagCloudArray.ToObject<List<GetByBlogIdTagCloudDto>>();
                return View(values);
                
            }
            return View();


        }
    }
}
