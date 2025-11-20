using BookApi.Data;
using BookApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            _context.Users.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPost("login")]
        public IActionResult Login(UserLogin model)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.UserName == model.UserName && u.PasswordHash == model.Password);

            if (user == null)
                return BadRequest("Sai tài khoản hoặc mật khẩu.");

            return Ok(user);
        }
    }

    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}