using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookApi.Data;
using BookApi.Models;


namespace BookManagement.Server.Controllers

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
            var data = await _context.MuonSach
                .Include(x => x.User)
                .Include(x => x.Sach)
                .ToListAsync();

            return Ok(data);
        }

        // GET: api/MuonSach/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.MuonSach
                .Include(x => x.User)
                .Include(x => x.Sach)
                .FirstOrDefaultAsync(x => x.IDMuon == id);

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

        // PUT: api/MuonSach/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MuonSach model)
        {
            var item = await _context.MuonSach.FindAsync(id);
            if (item == null)
                return NotFound();

            item.IDUser = model.IDUser;
            item.IDSach = model.IDSach;
            item.NgayMuon = model.NgayMuon;
            item.NgayTraDuKien = model.NgayTraDuKien;
            item.TrangThai = model.TrangThai;

            await _context.SaveChangesAsync();
            return Ok(item);
        }

        // DELETE: api/MuonSach/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.MuonSach.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.MuonSach.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
