using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookApi.Data;
using BookApi.Models;
using BookApi.Helpers;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuyenGopController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuyenGopController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.QuyenGop
                .Include(q => q.User)
                .OrderByDescending(q => q.NgayQuyenGop)
                .ToListAsync();

            return Ok(data);
        }

        [HttpGet("user/{idUser}")]
        public async Task<IActionResult> GetByUser(int idUser)
        {
            var list = await _context.QuyenGop
                .Where(q => q.IDUser == idUser)
                .OrderByDescending(q => q.NgayQuyenGop)
                .ToListAsync();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.QuyenGop
                .Include(q => q.User)
                .FirstOrDefaultAsync(q => q.IDQuyenGop == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuyenGop model)
        {
            // Kiểm tra user có tồn tại hay không
            var user = await _context.Users.FindAsync(model.IDUser);
            if (user == null)
                return BadRequest("User không tồn tại.");

            model.NgayQuyenGop = DateTime.Now;
            model.TrangThai = "Chờ duyệt";

            _context.QuyenGop.Add(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, QuyenGop model)
        {
            var item = await _context.QuyenGop.FindAsync(id);

            if (item == null)
                return NotFound();

            // Chỉ cho cập nhật thông tin sách
            item.TenSach = model.TenSach;
            item.TacGia = model.TacGia;
            item.SoLuong = model.SoLuong;

            await _context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpPut("duyet/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            var item = await _context.QuyenGop
                .Include(q => q.User)
                .FirstOrDefaultAsync(q => q.IDQuyenGop == id);

            if (item == null)
                return NotFound();

            if (item.TrangThai != "Chờ duyệt")
                return BadRequest("Chỉ có thể duyệt yêu cầu đang Chờ duyệt.");

            item.TrangThai = "Đã duyệt";
            item.NgayDuyet = DateTime.Now;
            // Tác giả
            var tacGia = await _context.TacGia.FirstOrDefaultAsync(a => a.HoTen == item.TacGia);

            if (tacGia == null)
            {
                tacGia = new TacGia { HoTen = item.TacGia };
                _context.TacGia.Add(tacGia);
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
            string loaiSachName = item.LoaiSach ?? "Chưa phân loại";
            var loaiSach = await _context.LoaiSach
                .FirstOrDefaultAsync(c => c.TenLoaiSach == loaiSachName);

            if (loaiSach == null)
            {
                loaiSach = new LoaiSach { TenLoaiSach = loaiSachName };
                _context.LoaiSach.Add(loaiSach);
                await _context.SaveChangesAsync();
            }

            // =========================
            // 3. Kiểm tra sách đã có chưa
            // =========================
            var sach = await _context.Sach
                .FirstOrDefaultAsync(b => b.TenSach == item.TenSach && b.IDTacGia == tacGia.IDTacGia);

            if (sach != null)
            {
                sach.SoLuong += item.SoLuong; // cộng số lượng
            }
            else
            {
                sach = new Sach
                {
                    TenSach = item.TenSach,
                    IDTacGia = tacGia.IDTacGia,
                    IDLoaiSach = loaiSach.IDLoaiSach,
                    SoLuong = item.SoLuong
                };
                _context.Sach.Add(sach);
            }

            await _context.SaveChangesAsync();

            // Gửi email
            try
            {
                if (item.User != null && !string.IsNullOrEmpty(item.User.Email))
                {
                    string subject = "📚 Thông báo: Yêu cầu quyên góp sách của bạn đã được duyệt!";
                    string body = $@"
<h2>📚 Thông báo duyệt quyên góp sách</h2>
<p>Xin chào {item.User.FullName},</p>
<p>Chúng tôi vui mừng thông báo rằng yêu cầu quyên góp sách của bạn <b>đã được duyệt thành công</b>.</p>
<p>Tên sách: <b>{item.TenSach}</b><br>
Số lượng: <b>{item.SoLuong}</b></p>
<p>Cảm ơn bạn đã đóng góp cho cộng đồng và hỗ trợ chương trình sách đa năng của chúng tôi.</p>
<hr>
<p style='font-size:14px;color:gray;'>Thân ái,<br>Hệ thống quản lý sách</p>
";
                    await EmailHelper.SendMailAsync(item.User.Email, subject, body);
                }

            }
            catch { /* tránh lỗi 500 */ }

            return Ok(item);
        }

        [HttpPut("tuchoi/{id}")]
        public async Task<IActionResult> Reject(int id)
        {
            var item = await _context.QuyenGop
                .Include(q => q.User)
                .FirstOrDefaultAsync(q => q.IDQuyenGop == id);

            if (item == null)
                return NotFound();

            if (item.TrangThai != "Chờ duyệt")
                return BadRequest("Chỉ có thể từ chối yêu cầu đang Chờ duyệt.");

            item.TrangThai = "Từ chối";
            await _context.SaveChangesAsync();

            // Gửi email
            try
            {
                if (item.User != null && !string.IsNullOrEmpty(item.User.Email))
                {
                    string subject = "❗ Thông báo: Yêu cầu quyên góp sách không được duyệt";
                    string body = $@"
<h2>❗ Thông báo từ chối quyên góp sách</h2>
<p>Xin chào {item.User.FullName},</p>
<p>Rất tiếc, yêu cầu quyên góp sách của bạn <b>không được duyệt</b>.</p>
<p>Tên sách: <b>{item.TenSach}</b><br>
Số lượng: <b>{item.SoLuong}</b></p>
<p>Nếu bạn cần biết lý do hoặc muốn gửi lại yêu cầu, vui lòng liên hệ hỗ trợ.</p>
<hr>
<p style='font-size:14px;color:gray;'>Trân trọng,<br>Hệ thống quản lý sách</p>
";

                    await EmailHelper.SendMailAsync(item.User.Email, subject, body);
                }
            }
            catch { }

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.QuyenGop.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.QuyenGop.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}