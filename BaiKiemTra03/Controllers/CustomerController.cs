using BaiKiemTra03.Data;
using BaiKiemTra03_03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_03.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Customer> customers = _db.Customer.Include("Contract").ToList();
            return View(customers);
        }
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            Customer customer = new Customer();
            IEnumerable<SelectListItem> dscontract = _db.Contracts.Select(
                item => new SelectListItem
                {
                    Value = item.Contract_Id.ToString(),
                    Text = item.Contract_Name,
                }
                );
            ViewBag.DSContract = dscontract;

            if (id == 0)
            {
                return View(customer);
            }
            else
            {
                customer = _db.Customer.Include("Contract").FirstOrDefault(sp => sp.Customer_Id == id);
                return View(customer);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.Customer_Id == 0)
                {
                    _db.Customer.Add(customer);
                }
                else
                {
                    _db.Customer.Update(customer);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var customer = _db.Customer.FirstOrDefault(sp => sp.Customer_Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            _db.Customer.Remove(customer);
            _db.SaveChanges();
            return Json(new { success = true });
        }
    }
}

