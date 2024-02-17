using CarBook.Dto.About;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using CarBook.Dto.Blog;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBlog")]
    public class AdminBlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7157/api/Blogs/GetBlogWithAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(data);
                JArray blogArray = (JArray)jsonObject["blogAndAuthor"];
                var values = blogArray.ToObject<List<ResultBlogWithAuthorDto>>();
                return View(values);
            }
            return View();

        }

        [Route("[action]/{id}")]
        public async Task<IActionResult> RemoveBlog(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7157/api/Blogs/RemoveBlog/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }
            return View();

        }
       
    }
}
