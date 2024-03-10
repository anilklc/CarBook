using CarBook.Dto.Brand;
using CarBook.Dto.Car;
using CarBook.Dto.CarWithBrand;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using CarBook.Dto.Role;
using CarBook.Dto.Location;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminAddUserRole")]
    public class AdminAddUserRoleController : Controller
    {
       
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAddUserRoleController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7157/api/Roles/GetAllUserWithRole");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(data);
                JArray userWithRoleArray = (JArray)jsonObject["usersWithRoles"];
                var values = userWithRoleArray.ToObject<List<ResultUserWithRoleDto>>();
                return View(values);
            }
            return View();

        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> AddUserRole()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7157/api/Roles/GetAllRole");
            var data = await responseMessage.Content.ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(data);
            JArray roleArray = (JArray)jsonObject["roles"];
            var values = roleArray.ToObject<List<ResultRoleDto>>();
            List<SelectListItem> roleValues = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.Name
                                                }).ToList();
            ViewBag.roleValues = roleValues;
            return View();

        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddUserRole(AddRoleUserDto addRoleUserDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addRoleUserDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7157/api/Roles/AddRoleUser", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("[action]/{username}/{rolename}")]
        public async Task<IActionResult> RemoveUserRole(string username,string rolename)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7157/api/Roles/RemoveRole/{username}/{rolename}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
