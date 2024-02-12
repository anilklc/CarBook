using CarBook.Dto.Blog;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7157/api/Blogs/GetBlogWithAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(data);
                JArray blogAndAuthorArray = (JArray)jsonObject["blogAndAuthor"];
                var values = blogAndAuthorArray.ToObject<List<ResultBlogWithAuthorDto>>();
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> BlogDetail(string Id)
        {
            ViewBag.Id = Id;
            return View();
        }
    }
}
