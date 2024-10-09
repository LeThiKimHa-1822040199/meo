using BaiKiemTra03.Data;
using BaiKiemTra03_03.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra03_03.Controllers
{
    public class ContractController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ContractController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Contract = _db.Contracts.ToList();
            ViewBag.theloai = Contract;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Contract contract)
        {
            if (ModelState.IsValid)
            {
                _db.Contracts.Add(contract);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var contract = _db.Contracts.Find(id);
            return View(contract);
        }
        [HttpPost]
        public IActionResult Edit(Contract contract)
        {
            if (ModelState.IsValid)
            {
                _db.Contracts.Update(contract);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var contract = _db.Contracts.Find(id);
            return View(contract);
        }
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.Contracts.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var contract = _db.Contracts.Find(id);
            if (contract == null)
            {
                return NotFound();
            }
            _db.Contracts.Remove(contract);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Search(string searchString)
        {

            if (!string.IsNullOrEmpty(searchString))
            {
                //Su dung LINQ de tim kiem
                var contract = _db.Contracts.
                    Where(tl => tl.Contract_Name.Contains(searchString)).ToList();

                ViewBag.seatchString = searchString;
                ViewBag.Contract = contract;
            }
            else
            {
                var contract = _db.Contracts.ToList();
                ViewBag.Contract = contract;
            }
            return View("Index");
        }
    }
}

