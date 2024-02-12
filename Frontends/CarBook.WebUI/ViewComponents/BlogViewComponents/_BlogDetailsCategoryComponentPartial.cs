using CarBook.Dto.About;
using CarBook.Dto.Category;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCategoryComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7157/api/Categories/GetAllCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(data);
                JArray categoriesArray = (JArray)jsonObject["categories"];
                var values = categoriesArray.ToObject<List<ResultCategoryDto>>();
                return View(values);
            }
            return View();
        }
    }
}
