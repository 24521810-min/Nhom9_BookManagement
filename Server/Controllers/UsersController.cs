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