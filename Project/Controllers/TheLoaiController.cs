﻿using Project.Data;
using Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var theloai = _db.TheLoai.ToList();
            ViewBag.theloai = theloai;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(TheLoai theLoai)
        {
            if (ModelState.IsValid)
            {
                _db.TheLoai.Add(theLoai);
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
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public IActionResult Edit(TheLoai theLoai)
        {
            if (ModelState.IsValid)
            {
                _db.TheLoai.Update(theLoai);
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
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var theloai = _db.TheLoai.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }
            _db.TheLoai.Remove(theloai);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Search(string searchString)
        {

            if (!string.IsNullOrEmpty(searchString))
            {
                //Su dung LINQ de tim kiem
                var theloai = _db.TheLoai.
                    Where(tl => tl.Name.Contains(searchString)).ToList();

                ViewBag.seatchString = searchString;
                ViewBag.Theloai = theloai;
            }
            else
            {
                var theloai = _db.TheLoai.ToList();
                ViewBag.Theloai = theloai;
            }
            return View("Index");
        }
    }
}

