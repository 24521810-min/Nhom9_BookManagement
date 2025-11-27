using BookApi.Data;
using BookApi.Helpers;
using BookApi.Models;
using Microsoft.AspNetCore.Identity.Data;
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User model)
        {
            // Kiểm tra trùng email hoặc username
            bool exists = await _context.Users.AnyAsync(x =>
                x.UserName == model.UserName || x.Email == model.Email);

            if (exists)
                return BadRequest(new { message = "Username hoặc Email đã tồn tại!" });

            // Hash mật khẩu
            model.PasswordHash = PasswordHelper.HashPassword(model.PasswordHash);

            // Set default field
            model.Role = "User";
            model.IsLocked = false;

            _context.Users.Add(model);

            await _context.SaveChangesAsync();

            return Ok(new { message = "Đăng ký thành công!", user = model });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] BookApi.Models.LoginRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x =>
                    x.UserName == request.UserInput ||
                    x.Email == request.UserInput);

            if (user == null)
                return Unauthorized(new { message = "User not found" });

            if (user.IsLocked)
                return Unauthorized(new { message = "Account locked", isLocked = true });

            bool validPassword = PasswordHelper.VerifyPassword(request.Password, user.PasswordHash);

            if (!validPassword)
                return Unauthorized(new { message = "Invalid password" });

            return Ok(new
            {
                idUser = user.IDUser,
                fullName = user.FullName,
                userName = user.UserName,
                email = user.Email,
                role = user.Role,
                isLocked = user.IsLocked
            });
        }


        [HttpGet("search")]
        public async Task<IActionResult> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return Ok(await _context.Users.ToListAsync());

            var result = await _context.Users
                .Where(u =>
                    u.FullName.Contains(keyword) ||
                    u.UserName.Contains(keyword) ||
                    u.Email.Contains(keyword) ||
                    u.Phone.Contains(keyword))
                .ToListAsync();

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User model)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            user.FullName = model.FullName;
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Phone = model.Phone;
            user.PasswordHash = model.PasswordHash;
            user.Role = model.Role;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Cập nhật thành công!" });
        }
        /*[HttpPut("lock/{id}")]
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
        }*/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Xóa thành công!" });
        }
    }
}