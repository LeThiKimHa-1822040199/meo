using Microsoft.AspNetCore.Mvc;

namespace BTVN_2.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Le Thi Kim Ha";
            ViewBag.MSSV = "1822040199";
            ViewData["Nam"] = "Nam 2004";
            return View();
        }
    }
}
