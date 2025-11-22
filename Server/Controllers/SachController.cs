using BookApi.Data;
using BookApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SachController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SachController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.Sach
                .Include(t => t.TacGia)
                .Include(l => l.LoaiSach)
                .ToListAsync();

            return Ok(data);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Tên sách không được để trống!");

            var data = await _context.Sach
                .Where(s => s.TenSach.Contains(name))
                .Include(t => t.TacGia)
                .Include(l => l.LoaiSach)
                .ToListAsync();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Sach model)
        {
            if (model == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            if (string.IsNullOrWhiteSpace(model.TenSach))
                return BadRequest("Tên sách không được để trống.");

            // Xử lý tác giả
            string? tacGiaName = model.TacGia?.HoTen;
            if (string.IsNullOrWhiteSpace(tacGiaName))
                return BadRequest("Tên tác giả không được để trống.");
            var tacGia = await _context.TacGia
                .FirstOrDefaultAsync(t => t.HoTen == tacGiaName);

            if (tacGia == null)
            {
                tacGia = new TacGia { HoTen = tacGiaName };
                _context.TacGia.Add(tacGia);
                await _context.SaveChangesAsync();
            }

            // Xử lý loại sách
            string? loaiSachName = model.LoaiSach?.TenLoaiSach;
            if (string.IsNullOrWhiteSpace(loaiSachName))
                return BadRequest("Tên loại sách không được để trống.");

            var loaiSach = await _context.LoaiSach
                .FirstOrDefaultAsync(l => l.TenLoaiSach == loaiSachName);

            if (loaiSach == null)
            {
                loaiSach = new LoaiSach { TenLoaiSach = loaiSachName };
                _context.LoaiSach.Add(loaiSach);
                await _context.SaveChangesAsync();
            }

            // Kiểm tra sách trùng
            var existed = await _context.Sach.FirstOrDefaultAsync(s =>
                s.TenSach == model.TenSach &&
                s.IDTacGia == tacGia.IDTacGia);

            if (existed != null)
                return BadRequest("Sách đã tồn tại!");

            // Lưu sách mới
            var sach = new Sach
            {
                TenSach = model.TenSach,
                SoLuong = model.SoLuong,
                IDTacGia = tacGia.IDTacGia,
                IDLoaiSach = loaiSach.IDLoaiSach
            };

            _context.Sach.Add(sach);
            await _context.SaveChangesAsync();

            return Ok(sach);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Sach model)
        {
            var sach = await _context.Sach
                .Include(t => t.TacGia)
                .Include(l => l.LoaiSach)
                .FirstOrDefaultAsync(s => s.IDSach == id);

            if (sach == null)
                return NotFound("Không tìm thấy sách.");

            // Xử lý tác giả
            string? tacGiaName = model.TacGia?.HoTen;
            if (string.IsNullOrWhiteSpace(tacGiaName))
                return BadRequest("Tên tác giả không được để trống.");

            var tacGia = await _context.TacGia
                .FirstOrDefaultAsync(t => t.HoTen == tacGiaName);

            // Nếu không có -> tạo mới
            if (tacGia == null)
            {
                tacGia = new TacGia { HoTen = tacGiaName };
                _context.TacGia.Add(tacGia);
                await _context.SaveChangesAsync();
            }

            // Xử lý loại sách
            string? loaiSachName = model.LoaiSach?.TenLoaiSach;
            if (string.IsNullOrWhiteSpace(loaiSachName))
                return BadRequest("Tên loại sách không được để trống.");

            var loaiSach = await _context.LoaiSach
                .FirstOrDefaultAsync(l => l.TenLoaiSach == loaiSachName);

            if (loaiSach == null)
            {
                loaiSach = new LoaiSach { TenLoaiSach = loaiSachName };
                _context.LoaiSach.Add(loaiSach);
                await _context.SaveChangesAsync();
            }

            // Kiểm tra trùng
            var existed = await _context.Sach.FirstOrDefaultAsync(s =>
                s.IDSach != id &&
                s.TenSach == model.TenSach &&
                s.IDTacGia == tacGia.IDTacGia);

            if (existed != null)
                return BadRequest("Sách cùng tên và tác giả đã tồn tại!");

            // Cập nhật dữ liệu
            sach.TenSach = model.TenSach;
            sach.SoLuong = model.SoLuong;
            sach.IDTacGia = tacGia.IDTacGia;
            sach.IDLoaiSach = loaiSach.IDLoaiSach;

            await _context.SaveChangesAsync();
            return Ok(sach);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Sach.FindAsync(id);
            if (item == null) return NotFound();

            _context.Sach.Remove(item);
            await _context.SaveChangesAsync();

            return Ok("Deleted");
        }
    }
}