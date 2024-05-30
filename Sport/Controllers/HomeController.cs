using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Sport.Models;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Sport.IRespoitory;

namespace Sport.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository repo;

        public HomeController(ILogger<HomeController> logger, IUserRepository repo)
        {
            _logger = logger;
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Classes()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Login login)
        {
            var b= repo.Login(login);
            if (!b)
            {
                ModelState.AddModelError("", "Istifadeci adi ve ya parol sehhvdir");
                return View("index");
            }
            var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,"1"),
                        new Claim(ClaimTypes.Name,login.UserName),
                    };

          

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);          
           

            var principial = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principial);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
                await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
