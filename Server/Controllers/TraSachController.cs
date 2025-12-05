using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookApi.Data;
using BookApi.Models;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraSachController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TraSachController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TraSach
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _context.TraSach
                    .Include(t => t.MuonSach)
                    .ToListAsync();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // GET: api/TraSach/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var item = await _context.TraSach
                    .Include(t => t.MuonSach)
                    .FirstOrDefaultAsync(t => t.IDTra == id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // POST: api/TraSach
        [HttpPost]
        public async Task<IActionResult> Create(TraSach model)
        {
            try
            {
                _context.TraSach.Add(model);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Đã gửi yêu cầu trả sách thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPut("duyet/{id}")]
        public async Task<IActionResult> DuyetTra(int id)
        {
            try
            {
                // 1. Lấy yêu cầu trả sách
                var tra = await _context.TraSach.FindAsync(id);
                if (tra == null)
                    return NotFound(new { message = "Không tìm thấy yêu cầu trả sách." });

                // 2. Lấy phiếu mượn
                var muon = await _context.MuonSach.FindAsync(tra.IDMuon);
                if (muon == null)
                    return BadRequest(new { message = "Không tìm thấy phiếu mượn." });

                // 3. Lấy sách
                var sach = await _context.Sach.FindAsync(muon.IDSach);
                if (sach == null)
                    return BadRequest(new { message = "Không tìm thấy sách." });

                // 4. Cập nhật trạng thái mượn + số lượng sách
                muon.TrangThai = "DaTra";
                sach.SoLuong += 1;

                await _context.SaveChangesAsync();

                // 5. Gửi email cho user
                var user = await _context.Users.FindAsync(muon.IDUser);
                if (user != null)
                {                    
                    string subject = "📚 Thông báo: Xác nhận trả sách thành công!";
                    string body = $@"
                        <h2>📚 Thông báo trả sách</h2>
                        <p>Xin chào {user.FullName},</p>
                        <p>Chúng tôi vui mừng thông báo rằng yêu cầu trả sách của bạn <b>đã được duyệt thành công</b>.</p>
                        <p><b>Mã sách:</b> {muon.IDSach}<br>
                        <b>Ngày trả:</b> {tra.NgayTra:dd/MM/yyyy}</p>
                    <p>Cảm ơn bạn đã sử dụng thư viện!</p>
                        <p style='font-size:14px;color:gray;'>Thân ái,<br>Hệ thống BookManagement</p>
                        ";
                    await EmailHelper.SendMailAsync(user.Email, subject, body);
                }

                return Ok(new { message = "Đã duyệt trả sách + cập nhật số lượng + gửi email thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // DELETE: api/TraSach/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await _context.TraSach.FindAsync(id);

                if (item == null)
                    return NotFound();

                _context.TraSach.Remove(item);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
