using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.RegularExpressions;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class HomeController(TestDbContext context) : Controller
    {
        private readonly TestDbContext _context = context;

        public IActionResult Login()
        {
            return View(new ApplicationUser());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel request)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
                if (user == null)
                    return BadRequest();
                // TODO - implement some sort of hashing for the password and potentially all data.
                if (user.Password != request.Password)
                    return Unauthorized();
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, request.Username),
                    new(ClaimTypes.Email, user.Email),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return Redirect("/Home");
            }
            return View(request);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Home/Login");
        }


        [Authorize]
        public IActionResult Index()
        {
            var user = _context.Users
                .AsEnumerable()
                .Where(u => u.Username == User.Identity.Name && u.Ints.Contains(1))
                .FirstOrDefault();
            if (user == null) return NotFound();
            return View(user);
        }
        
        public record LoginModel(string Username, string Password);
    }
}
