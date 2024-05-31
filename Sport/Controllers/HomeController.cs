using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Sport.Models;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Sport.IRespoitory;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public IActionResult Register(RegisterViewModel req)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error");
                return View("Register");

            }
            var u= repo.GetUser(new Entites.User
            {
                Email = req.Email,
                UserName = req.UserName
            });

            if (u is not null)
            {
                ModelState.AddModelError("", "user exsist");
                return View("Register");
            }

            repo.Signin(new Entites.User
            {
                Email = req.Email,
                FullName = req.FullName,
                Password = req.Password,
                UserName = req.UserName
            });
            return View("Index");
        }

        public IActionResult Classes()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Login login)
        {
            var u = repo.Login(login);
            if (u is null)
            {
                ModelState.AddModelError("", "Istifadeci tapilmadi");
                return View("index");
            }          
            var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,u.Id.ToString()),
                        new Claim(ClaimTypes.Name,u.FullName),
                    };
            if (u.UserName == "admin")
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
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
