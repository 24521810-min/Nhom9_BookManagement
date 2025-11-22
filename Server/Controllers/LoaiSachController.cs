using BookApi.Data;
using BookApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSachController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoaiSachController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.LoaiSach.ToListAsync();
            return Ok(data);
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Tên loại sách không được để trống!");

            var data = await _context.LoaiSach
                .Where(l => l.TenLoaiSach.Contains(name))
                .ToListAsync();

            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(LoaiSach model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.TenLoaiSach))
                return BadRequest("Tên loại sách không được để trống!");

            // Kiểm tra trùng
            bool exists = await _context.LoaiSach
                .AnyAsync(l => l.TenLoaiSach == model.TenLoaiSach);

            if (exists)
                return BadRequest("Loại sách đã tồn tại!");

            _context.LoaiSach.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LoaiSach model)
        {
            var item = await _context.LoaiSach.FindAsync(id);
            if (item == null)
                return NotFound("Không tìm thấy loại sách.");

            if (string.IsNullOrWhiteSpace(model.TenLoaiSach))
                return BadRequest("Tên loại sách không được để trống!");

            // Kiểm tra trùng tên
            bool duplicate = await _context.LoaiSach
                .AnyAsync(l => l.IDLoaiSach != id && l.TenLoaiSach == model.TenLoaiSach);

            if (duplicate)
                return BadRequest("Tên loại sách đã tồn tại!");

            item.TenLoaiSach = model.TenLoaiSach;
            await _context.SaveChangesAsync();
            return Ok(item);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.LoaiSach.FindAsync(id);
            if (item == null)
                return NotFound("Không tìm thấy loại sách!");

            // Kiểm tra loại sách đang được dùng trong bảng Sách
            bool isUsed = await _context.Sach.AnyAsync(s => s.IDLoaiSach == id);

            if (isUsed)
                return BadRequest("Không thể xóa! Loại sách đang được sử dụng trong bảng Sách.");

            _context.LoaiSach.Remove(item);
            await _context.SaveChangesAsync();

            return Ok("Deleted");
        }
    }
}