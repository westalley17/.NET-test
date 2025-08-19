using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using test.Data;
using test.Models;

namespace test.Controllers
{
    [Controller]
    [Route("[controller]/[action]")]
    public class UserController(TestDbContext context) : Controller
    {
        private readonly TestDbContext _context = context;
        
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUser userRequest)
        {
            // saying IsValid here auto detects if something didn't bind to our User model correctly.
            if(ModelState.IsValid)
            {  
                userRequest.Ints = [1, 2, 3];
                //_context.Users.Add(userRequest);
                await _context.SaveChangesAsync();
                return Redirect("User/Login");
            }
            return BadRequest();
        }

        public IActionResult Create()
        {
            return View(new ApplicationUser());
        }
    }
}
