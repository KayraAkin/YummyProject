using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using YummyProject.Context;

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
            var value = _context.Messages.Find(id);
            return View(value);
            
        }
    }
}