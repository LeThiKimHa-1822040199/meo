using BaiKiemTra03.Data;
using BaiKiemTra03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BaiKiemTra03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_db = db;
        }

        public IActionResult Index()
        {
            //IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();
            //return View(sanpham);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
