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
            try
            {
                var data = await _context.TraSach
                    .Include(t => t.MuonSach)
                    .ToListAsync();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // GET: api/TraSach/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var item = await _context.TraSach
                    .Include(t => t.MuonSach)
                    .FirstOrDefaultAsync(t => t.IDTra == id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // POST: api/TraSach
        [HttpPost]
        public async Task<IActionResult> Create(TraSach model)
        {
            try
            {
                // 🔥 LẤY ĐÚNG IDUSER TỪ PHIẾU MƯỢN
                var muon = await _context.MuonSach.FindAsync(model.IDMuon);
                if (muon == null)
                    return BadRequest("Không tìm thấy phiếu mượn!");

                // 🔥 TỰ GÁN IDUSER — KHÔNG LẤY TỪ WINFORMS NỮA
                model.IDUser = muon.IDUser;

                _context.TraSach.Add(model);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Đã gửi yêu cầu trả sách thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }



        [HttpPut("duyet/{id}")]
        public async Task<IActionResult> DuyetTra(int id)
        {
            try
            {
                var tra = await _context.TraSach.FindAsync(id);
                if (tra == null)
                    return NotFound(new { message = "Không tìm thấy yêu cầu trả sách." });

                var muon = await _context.MuonSach.FindAsync(tra.IDMuon);
                if (muon == null)
                    return BadRequest(new { message = "Không tìm thấy phiếu mượn." });

                var sach = await _context.Sach.FindAsync(muon.IDSach);
                if (sach == null)
                    return BadRequest(new { message = "Không tìm thấy sách." });

                // cập nhật trạng thái mượn
                muon.TrangThai = "Đã Trả";
                sach.SoLuong += 1;

                // 🔥 Cập nhật trạng thái trả
                tra.TinhTrang = "Trả Thành Công";

                await _context.SaveChangesAsync();

                return Ok(new { message = "Duyệt trả thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }


        // DELETE: api/TraSach/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await _context.TraSach.FindAsync(id);

                if (item == null)
                    return NotFound();

                _context.TraSach.Remove(item);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
        [HttpGet("user/{id}/count")]
        public async Task<IActionResult> CountByUser(int id)
        {
            int count = await _context.TraSach
                .Include(t => t.MuonSach)
                .Where(t => t.MuonSach != null && t.MuonSach.IDUser == id && t.MuonSach.TrangThai == "Đã Trả")
                .CountAsync();

            return Ok(count);
        }
    }
}
