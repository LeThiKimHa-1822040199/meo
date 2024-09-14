using BaiTap06.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap06.Controllers
{
    public class TaiKhoanController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy(TaiKhoanViewModel TaiKhoan)
        {
            if (TaiKhoan != null && TaiKhoan.Password != null && TaiKhoan.Password.Length > 0)
            {
                TaiKhoan.Password = TaiKhoan.Password + "_da_ma_hoa";
            }
            return View(TaiKhoan);
        }
    }
}
