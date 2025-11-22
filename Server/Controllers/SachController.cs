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

        [HttpPost]
        public async Task<IActionResult> Add(Sach model)
        {
            _context.Sach.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Sach model)
        {
            var item = await _context.Sach.FindAsync(id);
            if (item == null) return NotFound();

            item.TenSach = model.TenSach;
            item.SoLuong = model.SoLuong;
            item.IDTacGia = model.IDTacGia;
            item.IDLoaiSach = model.IDLoaiSach;

            await _context.SaveChangesAsync();
            return Ok(item);
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