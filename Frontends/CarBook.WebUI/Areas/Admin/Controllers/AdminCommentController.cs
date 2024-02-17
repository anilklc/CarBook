using CarBook.Dto.Blog;
using CarBook.Dto.Comment;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminComment")]
    public class AdminCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.BlogId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7157/api/Comments/GetCommentByIdBlog/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(data);
                JArray commentArray = (JArray)jsonObject["comments"];
                var values = commentArray.ToObject<List<ResultCommentDto>>();
                return View(values);
            }
            return View();

        }

    }
}
