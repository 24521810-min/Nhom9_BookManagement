using BookApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichSuController : ControllerBase
    {
        private readonly AppDbContext _db;

        public LichSuController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetLichSu()
        {
            var lichSu = new List<LichSuDto>();

            // ========== MƯỢN SÁCH ==========
            var muonList = await _db.MuonSach
                .Join(_db.Users,
                      m => m.IDUser,
                      u => u.IDUser,
                      (m, u) => new { m, u })
                .ToListAsync();

            foreach (var item in muonList)
            {
                lichSu.Add(new LichSuDto
                {
                    UserName = item.u.FullName,
                    HoatDong = "Mượn sách",
                    ChiTiet = $"Mã sách: {item.m.IDSach} | Hạn trả: {item.m.NgayTraDuKien:d}",
                    ThoiGian = item.m.NgayMuon
                });
            }

            // ========== TRẢ SÁCH ==========
            var traList = await _db.TraSach
                .Join(_db.MuonSach, t => t.IDMuon, m => m.IDMuon, (t, m) => new { t, m })
                .Join(_db.Users, tm => tm.m.IDUser, u => u.IDUser, (tm, u) => new { tm, u })
                .ToListAsync();

            foreach (var item in traList)
            {
                lichSu.Add(new LichSuDto
                {
                    UserName = item.u.FullName,
                    HoatDong = "Trả sách",
                    ChiTiet = $"Mã sách: {item.tm.m.IDSach} | Tình trạng: {item.tm.t.TinhTrang}",
                    ThoiGian = item.tm.t.NgayTra
                });
            }

            // ========== QUYÊN GÓP ==========
            var qgList = await _db.QuyenGop
                .Join(_db.Users,
                      q => q.IDUser,
                      u => u.IDUser,
                      (q, u) => new { q, u })
                .ToListAsync();

            foreach (var item in qgList)
            {
                lichSu.Add(new LichSuDto
                {
                    UserName = item.u.FullName,
                    HoatDong = "Quyên góp sách",
                    ChiTiet = $"{item.q.TenSach} - SL: {item.q.SoLuong} | Trạng thái: {item.q.TrangThai}",
                    ThoiGian = item.q.NgayQuyenGop
                });
            }

            // Sắp xếp mới nhất lên đầu
            lichSu = lichSu.OrderByDescending(x => x.ThoiGian).ToList();

            return Ok(lichSu);
        }
    }
}
