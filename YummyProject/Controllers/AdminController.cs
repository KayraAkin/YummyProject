using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AdminController : Controller
    {
        YummyContext _context = new YummyContext();
        public ActionResult Index()
        {
            var values = _context.Admins.ToList();
            return View(values);
        }
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return View(admin);
            }


            _context.Admins.Add(admin);
            int result = _context.SaveChanges();

            if (result == 0)
            {
                ViewBag.error = "Değerler kaydedilirken bir hata ile karşılaşıldı";
                return View(admin);
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var value = _context.Admins.Find(id);
            _context.Admins.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateAdmin(int id)
        {
            var value = _context.Admins.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            _context.Entry(admin).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}