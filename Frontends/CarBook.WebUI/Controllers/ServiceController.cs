using CarBook.Dto.CarWithBrand;
using CarBook.Dto.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
       
        public IActionResult Index()
        {
          
            return View();
        }
    }
}
