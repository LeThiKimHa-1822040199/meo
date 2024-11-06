using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using System.Security.Claims;

namespace Project.Controllers
{
    [Area("Customer")]
    public class GioHangController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GioHangController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize]
        public IActionResult Index()
        {
            // Lay thong tin tai khoan
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);

            // Lay danh sach cac san pham trong gio hang cua User
            //IEnumerable<GioHang> dsGioHang = _db.GioHang.Include("SanPham").
            //                Where(gh => gh.ApplicationUserId == claim.Value).ToList();

            //return View(dsGioHang);
            GiohangViewModel giohang = new GiohangViewModel
            {
                DsGioHang = _db.GioHang.Include("SanPham").Where(gh => gh.ApplicationUserId == claim.Value).ToList(),
                HoaDon = new HoaDon()
            };

            foreach (var item in giohang.DsGioHang)
            {
                // Tính tien san pham theo so luong
                double productprice = item.Quantity * item.SanPham.price;
                giohang.HoaDon.Total += item.ProductPrice;
            }
            return View(giohang);
        }
        public IActionResult Xoa(int giohangId)
        {
            GioHang giohang = _db.GioHang.FirstOrDefault(gh => gh.Id == giohangId);
            _db.GioHang.Remove(giohang);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Tang(int giohangId)
        {
            var giohang = _db.GioHang.FirstOrDefault(gh => gh.Id == giohangId);
            giohang.Quantity++;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Giam(int giohangId)
        {
            var giohang = _db.GioHang.FirstOrDefault(gh => gh.Id == giohangId);
            giohang.Quantity--;
            if (giohang.Quantity == 0)
            {
                _db.GioHang.Remove(giohang);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult ThanhToan()
        {
            // Lay thong tin tai khoan
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);

            // Lay danh sach cac san pham trong gio hang cua User
            //IEnumerable<GioHang> dsGioHang = _db.GioHang.Include("SanPham").
            //                Where(gh => gh.ApplicationUserId == claim.Value).ToList();

            //return View(dsGioHang);
            GiohangViewModel giohang = new GiohangViewModel
            {
                DsGioHang = _db.GioHang.Include("SanPham").Where(gh => gh.ApplicationUserId == claim.Value).ToList(),
                HoaDon = new HoaDon()
            };

            giohang.HoaDon.ApplicationUser = _db.ApplicationUsers.FirstOrDefault(u => u.Id == claim.Value);
            giohang.HoaDon.Name = giohang.HoaDon.ApplicationUser.name;
            giohang.HoaDon.Address = giohang.HoaDon.ApplicationUser.address;
            giohang.HoaDon.PhoneNumber = giohang.HoaDon.ApplicationUser.PhoneNumber;


            foreach (var item in giohang.DsGioHang)
            {
                // Tính tien san pham theo so luong
                double productprice = item.Quantity * item.SanPham.price;
                giohang.HoaDon.Total += productprice;
            }
            return View(giohang);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult ThanhToan(GiohangViewModel giohang)
        {
            // Lay thong tin tai khoan
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);


            giohang.DsGioHang = _db.GioHang.Include("SanPham").Where(gh => gh.ApplicationUserId == claim.Value).ToList();

            giohang.HoaDon.ApplicationUserId = claim.Value;
            giohang.HoaDon.OrderDate = DateTime.Now;
            giohang.HoaDon.OrderStatus = "Đang xác nhận";

            foreach (var item in giohang.DsGioHang)
            {
                // Tính tien san pham theo so luong
                double productprice = item.Quantity * item.SanPham.price;
                giohang.HoaDon.Total += productprice;
            }

            _db.HoaDon.Add(giohang.HoaDon);
            _db.SaveChanges();

            // Them thong tin chi tiet hoa don
            foreach (var item in giohang.DsGioHang)
            {
                ChiTietHoaDon chitiethoadon = new ChiTietHoaDon()
                {
                    SanPhamId = item.SanPhamId,
                    HoaDonId = giohang.HoaDon.Id,
                    ProductPrice = item.SanPham.price * item.Quantity,
                    Quantity = item.Quantity
                };
                _db.ChiTietHoaDon.Add(chitiethoadon);
                _db.SaveChanges();

            }

            // Xoa thong tin trong gio hang
            _db.GioHang.RemoveRange(giohang.DsGioHang);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}