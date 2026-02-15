using Microsoft.AspNetCore.Mvc;
using okruhy_pujcovnaMVCAPP.Data;
using okruhy_pujcovnaMVCAPP.Entities;
using System.Linq;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace okruhy_pujcovnaMVCAPP.Controllers
{
    public class UserController : Controller
    {
        public AppDbContext DbContext { get; set; }

        public UserController()
        {
            DbContext = new AppDbContext(); // školní styl
        }

        // GET: /User/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /User/Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // najdu uživatele v DB
            user? u = DbContext.Users.FirstOrDefault(x => x.Email == email && x.password == password);

            if (u == null)
            {
                ViewBag.Error = "Špatný email nebo heslo.";
                return View();
            }

            // vytvoř cookie identitu
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, u.UserId.ToString()),
                new Claim(ClaimTypes.Name, $"{u.FirstName} {u.LastName}"),
                new Claim(ClaimTypes.Email, u.Email)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();

            return RedirectToAction("Index", "Circuits");
        }

        // GET: /User/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /User/Register
        [HttpPost]
        public IActionResult Register(string firstName, string lastName, string email, string password)
        {
            bool exists = DbContext.Users.Any(x => x.Email == email);
            if (exists)
            {
                ViewBag.Error = "Email už existuje.";
                return View();
            }

            user u = new user
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                password = password
            };

            DbContext.Users.Add(u);
            DbContext.SaveChanges();

            return RedirectToAction("Login");
        }

        // /User/Logout
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            return RedirectToAction("Login");
        }
    }
}
