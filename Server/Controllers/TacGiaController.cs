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
            return Ok(await _context.TacGia.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add(TacGia model)
        {
            _context.TacGia.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TacGia model)
        {
            var item = await _context.TacGia.FindAsync(id);
            if (item == null) return NotFound();

            item.HoTen = model.HoTen;
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.TacGia.FindAsync(id);
            if (item == null) return NotFound();

            _context.TacGia.Remove(item);
            await _context.SaveChangesAsync();

            return Ok("Deleted");
        }
    }
}