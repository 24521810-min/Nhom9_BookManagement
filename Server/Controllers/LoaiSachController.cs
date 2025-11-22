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
            return Ok(await _context.LoaiSach.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add(LoaiSach model)
        {
            _context.LoaiSach.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LoaiSach model)
        {
            var item = await _context.LoaiSach.FindAsync(id);
            if (item == null) return NotFound();

            item.TenLoaiSach = model.TenLoaiSach;
            await _context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.LoaiSach.FindAsync(id);
            if (item == null) return NotFound();

            _context.LoaiSach.Remove(item);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }
    }
}