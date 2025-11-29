using BookApi.Data;
using BookApi.Helpers;
using BookApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public UsersController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User model)
        {
            bool exists = await _context.Users.AnyAsync(x => x.UserName == model.UserName || x.Email == model.Email);
            if (exists) return BadRequest(new { message = "Username hoặc Email đã tồn tại!" });

            model.PasswordHash = PasswordHelper.HashPassword(model.Password); // hash mật khẩu

            model.Role = "User";
            model.IsLocked = false;

            _context.Users.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Đăng ký thành công!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.UserName == request.UserInput || x.Email == request.UserInput);

            if (user == null) return Unauthorized(new { message = "User not found" });
            if (user.IsLocked) return Unauthorized(new { message = "Account locked", isLocked = true });

            if (!PasswordHelper.VerifyPassword(request.Password, user.PasswordHash))
                return Unauthorized(new { message = "Invalid password" });

            // Tạo JWT token
            string token = GenerateJwtToken(user);

            return Ok(new
            {
                idUser = user.IDUser,
                fullName = user.FullName,
                userName = user.UserName,
                email = user.Email,
                role = user.Role,
                isLocked = user.IsLocked,
                token
            });
        }
        private string GenerateJwtToken(User user)
        {
            var jwtKey = _config["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
                throw new InvalidOperationException("JWT key is not configured.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim("role", user.Role),
        new Claim("id", user.IDUser.ToString())
    };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users
                .Select(u => new
                {
                    u.IDUser,
                    u.FullName,
                    u.UserName,
                    u.Email,
                    u.Phone,
                    u.Role,
                    u.IsLocked
                })
                .ToListAsync();

            return Ok(users);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchUsers([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest(new { message = "Keyword không được rỗng" });

            var users = await _context.Users
                .Where(u => u.UserName.Contains(keyword)
                         || u.FullName.Contains(keyword)
                         || u.Email.Contains(keyword))
                .Select(u => new
                {
                    u.IDUser,
                    u.FullName,
                    u.UserName,
                    u.Email,
                    u.Phone,
                    u.Role,
                    u.IsLocked
                })
                .ToListAsync();

            return Ok(users);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Xóa thành công!" });
        }
        [HttpPut("lock/{id}")]
        public async Task<IActionResult> LockUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            user.IsLocked = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Khóa người dùng thành công!" });
        }

        [HttpPut("unlock/{id}")]
        public async Task<IActionResult> UnlockUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            user.IsLocked = false;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Mở khóa người dùng thành công!" });
        }
    }
}
        