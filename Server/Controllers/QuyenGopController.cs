using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookApi.Data;
using BookApi.Models;

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

        // GET: api/QuyenGop
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.QuyenGop
                .Include(q => q.User)
                .ToListAsync();

            return Ok(data);
        }

        // GET: api/QuyenGop/user/5
        [HttpGet("user/{idUser}")]
        public async Task<IActionResult> GetByUser(int idUser)
        {
            var list = await _context.QuyenGop
                .Where(q => q.IDUser == idUser)
                .OrderByDescending(q => q.NgayQuyenGop)
                .ToListAsync();

            return Ok(list);
        }

        // GET: api/QuyenGop/5
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

        // POST: api/QuyenGop
        [HttpPost]
        public async Task<IActionResult> Create(QuyenGop model)
        {
            model.NgayQuyenGop = DateTime.Now;
            model.TrangThai = "Chờ duyệt";

            _context.QuyenGop.Add(model);

            await _context.SaveChangesAsync();

            return Ok(model);
        }


        // PUT: api/QuyenGop/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, QuyenGop model)
        {
            var item = await _context.QuyenGop.FindAsync(id);

            if (item == null)
                return NotFound();

            item.IDUser = model.IDUser;
            item.TenSach = model.TenSach;
            item.TacGia = model.TacGia;
            item.SoLuong = model.SoLuong;
            item.NgayQuyenGop = model.NgayQuyenGop;
            item.TrangThai = model.TrangThai;

            await _context.SaveChangesAsync();
            return Ok(item);
        }

        // DELETE: api/QuyenGop/5
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
