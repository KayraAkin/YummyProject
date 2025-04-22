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
    public class EventController : Controller
    {
        YummyContext _context = new YummyContext();
        public ActionResult Index()
        {
            var  values = _context.Events.ToList();
            return View(values);
        }
        public ActionResult AddEvent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEvent(Event events)
        {
            if (!ModelState.IsValid)
            {
                return View(events);
            }


            _context.Events.Add(events);
            int result = _context.SaveChanges();

            if (result == 0)
            {
                ViewBag.error = "Değerler kaydedilirken bir hata ile karşılaşıldı";
                return View(events);
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEvent(int id)
        {
            var value = _context.Events.Find(id);
            _context.Events.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateEvent(int id)
        {
            var value = _context.Events.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEvent(Event events)
        {
            _context.Entry(events).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}