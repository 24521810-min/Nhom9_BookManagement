using BookApi.Data;
using BookApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacGiaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TacGiaController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.TacGia.ToListAsync();
            return Ok(data);
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Tên tác giả không được để trống!");

            var data = await _context.TacGia
                .Where(l => l.HoTen.Contains(name))
                .ToListAsync();

            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(TacGia model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.HoTen))
                return BadRequest("Tên tác giả không được để trống!");

            // Kiểm tra trùng
            bool exists = await _context.TacGia
                .AnyAsync(l => l.HoTen == model.HoTen);

            if (exists)
                return BadRequest("Tác giả đã tồn tại!");

            _context.TacGia.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TacGia model)
        {
            var item = await _context.TacGia.FindAsync(id);
            if (item == null)
                return NotFound("Không tìm thấy tác giả.");

            if (string.IsNullOrWhiteSpace(model.HoTen))
                return BadRequest("Tên tác giả không được để trống!");

            // Kiểm tra trùng tên
            bool duplicate = await _context.TacGia
                .AnyAsync(l => l.IDTacGia != id && l.HoTen == model.HoTen);

            if (duplicate)
                return BadRequest("Tên tác giả đã tồn tại!");

            item.HoTen = model.HoTen;
            await _context.SaveChangesAsync();
            return Ok(item);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.TacGia.FindAsync(id);
            if (item == null)
                return NotFound("Không tìm thấy tác giả!");

            bool isUsed = await _context.Sach.AnyAsync(s => s.IDTacGia == id);

            if (isUsed)
                return BadRequest("Không thể xóa! Tác Giả đang được sử dụng trong bảng Sách.");

            _context.TacGia.Remove(item);
            await _context.SaveChangesAsync();

            return Ok("Deleted");
        }
    }
}