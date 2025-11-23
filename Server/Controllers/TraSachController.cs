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
            var data = await _context.TraSach
                .Include(t => t.User)
                .Include(t => t.MuonSach)
                .ToListAsync();

            return Ok(data);
        }

        // GET: api/TraSach/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.TraSach
                .Include(t => t.User)
                .Include(t => t.MuonSach)
                .FirstOrDefaultAsync(t => t.IDTra == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST: api/TraSach
        [HttpPost]
        public async Task<IActionResult> Create(TraSach model)
        {
            _context.TraSach.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        // PUT: api/TraSach/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TraSach model)
        {
            var item = await _context.TraSach.FindAsync(id);

            if (item == null)
                return NotFound();

            item.IDMuon = model.IDMuon;
            item.IDUser = model.IDUser;
            item.NgayTra = model.NgayTra;
            item.TinhTrang = model.TinhTrang;
            item.GhiChu = model.GhiChu;

            await _context.SaveChangesAsync();
            return Ok(item);
        }

        // DELETE: api/TraSach/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.TraSach.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.TraSach.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
