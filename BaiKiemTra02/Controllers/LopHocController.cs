using BaiKiemTra02.Data;
using BaiKiemTra02.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra02.Controllers
{
    public class LopHocController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LopHocController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var theloai = _db.LopHoc.ToList();
            ViewBag.theloai = theloai;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
		[HttpPost]
		public IActionResult ThemMoi(LopHoc lophoc)
		{
			if (ModelState.IsValid)
			{
				_db.LopHoc.Add(lophoc);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View();
		}
		[HttpGet]
		public IActionResult ChinhSua(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}
			var lophoc = _db.LopHoc.Find(id);
			return View(lophoc);
		}
		[HttpPost]
		public IActionResult ChinhSua(LopHoc lophoc)
		{
			if (ModelState.IsValid)
			{
				_db.LopHoc.Update(lophoc);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult Xoa(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}
			var lophoc = _db.LopHoc.Find(id);
			return View(lophoc);
		}

		[HttpPost]
		public IActionResult DeleteConfirm(int id)
		{
			var lophoc = _db.LopHoc.Find(id);
			if (lophoc == null)
			{
				return NotFound();
			}
			_db.LopHoc.Remove(lophoc);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult XemChiTiet(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}
			var lophoc = _db.LopHoc.Find(id);
			return View(lophoc);
		}
		[HttpGet]
		public IActionResult Details(LopHoc lophoc)
		{
			if (ModelState.IsValid)
			{
				
				_db.LopHoc.Update(lophoc);
				
				_db.SaveChanges();
				
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
