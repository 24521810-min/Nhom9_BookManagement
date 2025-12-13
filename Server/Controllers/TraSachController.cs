using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookApi.Data;
using BookApi.Models;
using BookApi.Helpers;

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

        // ======================= GET ALL =======================
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

        // ======================= GET BY ID =====================
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

        // ======================= CREATE ========================
        [HttpPost]
        public async Task<IActionResult> Create(TraSach model)
        {
            try
            {
                var muon = await _context.MuonSach.FindAsync(model.IDMuon);
                if (muon == null)
                    return BadRequest("Không tìm thấy phiếu mượn!");

                model.IDUser = muon.IDUser;

                _context.TraSach.Add(model);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Đã gửi yêu cầu trả sách thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // ======================= DUYỆT TRẢ =====================
        [HttpPut("duyet/{id}")]
        public async Task<IActionResult> DuyetTra(int id)
        {
            try
            {
                var tra = await _context.TraSach.FindAsync(id);
                if (tra == null)
                    return NotFound(new { message = "Không tìm thấy yêu cầu trả sách." });

                var muon = await _context.MuonSach.FindAsync(tra.IDMuon);
                if (muon == null)
                    return BadRequest(new { message = "Không tìm thấy phiếu mượn." });

                var sach = await _context.Sach.FindAsync(muon.IDSach);
                if (sach == null)
                    return BadRequest(new { message = "Không tìm thấy sách." });

                var user = await _context.Users.FindAsync(muon.IDUser);
                if (user == null)
                    return BadRequest(new { message = "Không tìm thấy người dùng." });

                // ===== CẬP NHẬT TRẠNG THÁI =====
                muon.TrangThai = "Đã Trả";
                tra.TinhTrang = "Trả Thành Công";
                tra.NgayTra = DateTime.Now;   // 🔥 DÒNG QUYẾT ĐỊNH
                sach.SoLuong += 1;

                await _context.SaveChangesAsync();

                // ===== NỘI DUNG EMAIL (GIỮ NGUYÊN) =====
                string body = $@"
<h2>📚 Thông báo trả sách</h2>

<p>Xin chào <b>{user.FullName}</b>,</p>

<p>
Chúng tôi xin thông báo rằng <b>yêu cầu trả sách của bạn đã được duyệt thành công</b>.
</p>

<p>
<b>Mã sách:</b> {sach.IDSach}<br/>
<b>Ngày mượn:</b> {muon.NgayMuon:dd/MM/yyyy}<br/>
<b>Ngày trả thực tế:</b> {tra.NgayTra:dd/MM/yyyy}
</p>

<p>
Cảm ơn bạn đã thực hiện việc trả sách đúng quy định.
</p>

<br/>

<p>
Thân ái,<br/>
<b>Hệ thống BookManagement</b>
</p>
";

                // ===== GỬI MAIL =====
                bool emailSent = await EmailHelper.SendMailAsync(
                    user.Email,
                    $"📚 [BookManagement] Trả sách thành công - Mã sách {sach.IDSach}",
                    body,
                    isHtml: true
                );

                return Ok(new
                {
                    message = "Duyệt trả sách thành công!",
                    emailSent = emailSent
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // ======================= DELETE ========================
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

        // ======================= COUNT BY USER =================
        [HttpGet("user/{id}/count")]
        public async Task<IActionResult> CountByUser(int id)
        {
            int count = await _context.TraSach
                .Include(t => t.MuonSach)
                .Where(t => t.MuonSach != null
                            && t.MuonSach.IDUser == id
                            && t.MuonSach.TrangThai == "Đã Trả")
                .CountAsync();

            return Ok(count);
        }
    }
}