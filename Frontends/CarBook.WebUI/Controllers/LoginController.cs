using CarBook.Dto.Login;
using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = JsonContent.Create(loginDto);
            var response = await client.PostAsync("https://localhost:7157/User/login", content);

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadAsStringAsync();

                // Token response'ı direkt olarak alıyoruz
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadToken(tokenResponse) as JwtSecurityToken;

                // Token doğrulama işlemleri
                var tokenValidationParams = new TokenValidationParameters
                {
                    // Token'ın algoritmasını belirtin (örneğin, "HS256" veya "RS256")
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key_here")),

                    // Token'ın yayıncısını (issuer) doğrulayın
                    ValidateIssuer = true,
                    ValidIssuer = "your_issuer_here",

                    // Token'ın alıcılarını (audience) doğrulayın
                    ValidateAudience = true,
                    ValidAudience = "your_audience_here",

                    // Token'ın zaman aşımını kontrol edin
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                // Token'ı doğrulayın
                try
                {
                    var principal = handler.ValidateToken(tokenResponse, tokenValidationParams, out _);
                    var claimsIdentity = new ClaimsIdentity(principal.Claims, JwtBearerDefaults.AuthenticationScheme);
                    var authProps = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                    return RedirectToAction("Index", "Default");
                }
                catch (SecurityTokenException ex)
                {
                    ModelState.AddModelError(string.Empty, "Invalid token format: " + ex.Message);
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid token response.");
                return View();
            }
        }
    }
}
