using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;

using Project.Models;

namespace Project.Controllers
{
    [Area("Admin")]
    public class DonHangController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DonHangController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<HoaDon> hoadon = _db.HoaDon.Include(h => h.ApplicationUser).ToList();

            return View(hoadon);
        }
    }
}
