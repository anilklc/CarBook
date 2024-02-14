using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CarBook.Dto.Author;
using CarBook.Dto.TagCloud;
using CarBook.Dto.Category;
using Newtonsoft.Json.Linq;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsAuthorAboutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _BlogDetailsAuthorAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
            ViewBag.Id = Id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7157/api/Blogs/GetBlogWithByIdAuthor" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(data);
                JArray categoriesArray = (JArray)jsonObject["blogAndAuthor"];
                var values = categoriesArray.ToObject<List<GetAuthorByBlogAuthorIdDto>>();
                return View(values);
            }
            return View();
        }
    }
}