using BookApi.Data;
using BookApi.Dtos;
using BookApi.Helpers;
using BookApi.Models;
using BookApi.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
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

            if (user == null) return Unauthorized(new { message = "Vui lòng nhập tên đăng nhập/email và mật khẩu!" });
            if (user.IsLocked) return Unauthorized(new { message = "Tài khoản của bạn đã bị khóa. Vui lòng liên hệ Admin!", isLocked = true });

            if (!PasswordHelper.VerifyPassword(request.Password, user.PasswordHash))
                return Unauthorized(new { message = "Tên đăng nhập/email hoặc mật khẩu không đúng!" });

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
                    u.BirthDate,
                    u.Gender,
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
                    u.BirthDate,
                    u.Gender,
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

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.IDUser == id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPut("{id}/profile")]
        public async Task<IActionResult> UpdateProfile(int id, [FromBody] UpdateProfileDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.IDUser == id);
            if (user == null)
                return NotFound();

            // Có thể check quyền ở đây (user chỉ được sửa profile của chính mình)

            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.Phone = dto.Phone;
            user.BirthDate = dto.BirthDate;
            user.Gender = dto.Gender;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Ví dụ email bị trùng unique constraint
                return BadRequest(new { message = ex.Message });
            }

            return NoContent();
        }
        [AllowAnonymous]
        [HttpPost("forget_password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Email))
                return BadRequest(new { message = "Email không được để trống" });

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == req.Email);
            if (user == null)
                return NotFound(new { message = "Email chưa đăng ký trong hệ thống!" });

            // Tạo mật khẩu tạm 8 ký tự
            string tempPass = Guid.NewGuid().ToString("N").Substring(0, 8);

            // Hash và lưu vào PasswordHash
            user.PasswordHash = PasswordHelper.HashPassword(tempPass);
            await _context.SaveChangesAsync();

            // Gửi email
            bool sent = await EmailHelper.SendTemporaryPasswordMail(req.Email, tempPass);
            if (!sent)
                return StatusCode(500, new { message = "Không gửi được email. Kiểm tra lại cấu hình Gmail/Internet." });

            return Ok(new { message = "Mật khẩu mới đã được gửi tới email của bạn. Vui lòng kiểm tra hộp thư." });
        }
        [AllowAnonymous]
        [HttpPost("reset_password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Email) ||
                string.IsNullOrWhiteSpace(req.TemporaryPassword) ||
                string.IsNullOrWhiteSpace(req.NewPassword))
            {
                return BadRequest(new { message = "Vui lòng nhập đầy đủ Email, mật khẩu tạm và mật khẩu mới." });
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == req.Email);
            if (user == null)
                return NotFound(new { message = "Email không tồn tại trong hệ thống!" });

            // Kiểm tra mật khẩu tạm (so sánh hash)
            bool ok = PasswordHelper.VerifyPassword(req.TemporaryPassword, user.PasswordHash);
            if (!ok)
                return BadRequest(new { message = "Mật khẩu tạm không chính xác!" });

            // Hash mật khẩu mới rồi lưu lại
            user.PasswordHash = PasswordHelper.HashPassword(req.NewPassword);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Đổi mật khẩu thành công. Hãy đăng nhập lại bằng mật khẩu mới." });
        }

    }
}
        