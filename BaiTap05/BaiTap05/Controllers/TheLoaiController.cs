using BaiTap05.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap05.Controllers
{
    public class TheLoaiController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Ngay = "Ngay 1";
            ViewBag.Thang = "Thang 1";
            ViewData["Nam"] = "Nam 2024";
            return View();
        }

        public IActionResult Index2()
        {
            var theloai = new TheLoaiViewModel
            {
                id = 1,
                name = "Trinh thám"
            };

            return View(theloai);
        }
    }
}
