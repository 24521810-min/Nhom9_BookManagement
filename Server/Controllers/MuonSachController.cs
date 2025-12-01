using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookApi.Data;
using BookApi.Models;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuonSachController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MuonSachController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MuonSach
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.MuonSach
                .Include(m => m.Sach)
                .ToListAsync();

            return Ok(list);
        }

        // GET: api/MuonSach/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.MuonSach
                .Include(m => m.Sach)
                .FirstOrDefaultAsync(m => m.IDMuon == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST: api/MuonSach
        [HttpPost]
        public async Task<IActionResult> Create(MuonSach model)
        {
            _context.MuonSach.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        // PUT: api/MuonSach/duyet/5
        [HttpPut("duyet/{id}")]
        public async Task<IActionResult> DuyetMuon(int id)
        {
            // Lấy yêu cầu mượn
            var muon = await _context.MuonSach.FindAsync(id);
            if (muon == null)
                return NotFound(new { message = "Không tìm thấy yêu cầu mượn." });

            // Lấy thông tin user
            var user = await _context.Users.FindAsync(muon.IDUser);
            if (user == null)
                return BadRequest(new { message = "Không tìm thấy người dùng." });

            // ===== GIẢM SỐ LƯỢNG SÁCH =====
            var sach = await _context.Sach.FindAsync(muon.IDSach);
            if (sach == null)
                return BadRequest(new { message = "Không tìm thấy sách." });

            if (sach.SoLuong <= 0)
                return BadRequest(new { message = "Sách đã hết số lượng!" });

            sach.SoLuong -= 1;
            _context.Sach.Update(sach);

            // Cập nhật trạng thái
            muon.TrangThai = "DaDuyet";

            await _context.SaveChangesAsync();

            // ===== GỬI EMAIL =====
            string email = user.Email;
            string name = !string.IsNullOrEmpty(user.FullName) ? user.FullName : user.UserName;

            string subject = "Yêu cầu mượn sách đã được duyệt";
            string body = $@"
                <h3>Chào {name},</h3>
                <p>Yêu cầu mượn sách của bạn đã được <b>DUYỆT THÀNH CÔNG</b>.</p>
                <p><b>Mã sách:</b> {muon.IDSach}<br>
                   <b>Ngày mượn:</b> {muon.NgayMuon:dd/MM/yyyy}<br>
                   <b>Ngày trả dự kiến:</b> {muon.NgayTraDuKien:dd/MM/yyyy}
                </p>
                <p>Vui lòng đến thư viện nhận sách trong 3 ngày.</p>
                <p>Trân trọng,<br>Hệ thống BookManagement</p>
            ";

            if (!string.IsNullOrEmpty(email))
            {
                await EmailHelper.SendMailAsync(email, subject, body);
            }

            return Ok(new { message = "Duyệt thành công + Đã trừ số lượng + Email đã gửi!" });
        }

        // PUT: api/MuonSach/tuchoi/5
        [HttpPut("tuchoi/{id}")]
        public async Task<IActionResult> TuChoiMuon(int id)
        {
            var muon = await _context.MuonSach.FindAsync(id);
            if (muon == null) return NotFound();

            var user = await _context.Users.FindAsync(muon.IDUser);
            if (user == null) return BadRequest();

            muon.TrangThai = "TuChoi";
            await _context.SaveChangesAsync();

            await EmailHelper.SendMailAsync(
                user.Email,
                "Yêu cầu mượn sách bị từ chối",
                $"<p>Xin lỗi {user.FullName}, yêu cầu mượn sách của bạn đã bị từ chối.</p>"
            );

            return Ok(new { message = "Từ chối thành công + Email đã gửi" });
        }

        // DELETE: api/MuonSach/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.MuonSach.FindAsync(id);
            if (item == null) return NotFound();

            _context.MuonSach.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
