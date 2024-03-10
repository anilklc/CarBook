using CarBook.Dto.Role;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/AdminRole")]
	public class AdminRoleController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminRoleController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7157/api/Roles/GetAllRole");
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				JObject jsonObject = JObject.Parse(data);
				JArray RoleArray = (JArray)jsonObject["roles"];
				var values = RoleArray.ToObject<List<ResultRoleDto>>();
				return View(values);
			}
			return View();

		}

		[HttpGet]
		[Route("[action]")]
		public IActionResult CreateRole()
		{

			return View();

		}

		[HttpPost]
		[Route("[action]")]
		public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createRoleDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7157/api/Roles/CreateRole", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminRole", new { area = "Admin" });
			}
			return View();
		}

		
	}
}
