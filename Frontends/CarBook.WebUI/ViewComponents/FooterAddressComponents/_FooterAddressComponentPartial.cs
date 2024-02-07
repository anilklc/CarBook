using CarBook.Dto.Contact;
using CarBook.Dto.FooterAddress;
using CarBook.Dto.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterAddressComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7157/api/FooterAddress/GetAllFooterAddress");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(data);
                JArray footerAddressArray = (JArray)jsonObject["footerAddress"];
                var values = footerAddressArray.ToObject<List<ResultFooterAddressDto>>();
                return View(values);
            }
            return View();


        }
    }
}
