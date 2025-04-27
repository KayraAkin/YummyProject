using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class MessageController : Controller
    {
        YummyContext _context = new YummyContext();
        public ActionResult Index()
        {
            var values = _context.Messages.ToList();
            return View(values);
        }
        public ActionResult ChangeIsRead(int id)
        {
            var value = _context.Messages.Find(id);
            if (value.IsRead)
            {
                value.IsRead =false;
                _context.SaveChanges();
            }
            else
            {
                value.IsRead = true;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult OpenMessage(int id)
        {
            var isRead = _context.Messages.Find(id);
            isRead.IsRead = true;
            _context.SaveChanges();

            var value = _context.Messages.Find(id);
            return View(value);
            
        }
        public ActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SendMessage(YummyProject.Models.Message message)
        {
            if (ModelState.IsValid)
            {
                message.IsRead = false;
                _context.Messages.Add(message);
                _context.SaveChanges();

                return Content("OK");
            }
            return new HttpStatusCodeResult(400, "Geçersiz veri.");
        }
    }
}