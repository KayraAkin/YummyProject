using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ServiceController : Controller
    {
        YummyContext _context = new YummyContext();
        public ActionResult Index()
        {
            var values = _context.Services.ToList();
            return View(values);
        }
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            _context.Services.Add(service);
            var result = _context.SaveChanges();
            if (result == 0)
            {
                ViewBag.error = "Değerler kaydedilirken bir hata ile karşılaşıldı";
                return View(service);
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}