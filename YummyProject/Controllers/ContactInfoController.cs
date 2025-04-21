using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ContactInfoController : Controller
    {
        YummyContext _context = new YummyContext();
        public ActionResult Index()
        {
            var valeus = _context.ContactInfos.ToList();
            return View(valeus);
        }
        public ActionResult AddContactInfo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContactInfo(ContactInfo contactInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(contactInfo);
            }


            _context.ContactInfos.Add(contactInfo);
            int result = _context.SaveChanges();

            if (result == 0)
            {
                ViewBag.error = "Değerler kaydedilirken bir hata ile karşılaşıldı";
                return View(contactInfo);
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteContactInfo(int id)
        {
            var value = _context.ContactInfos.Find(id);
            _context.ContactInfos.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                message.IsRead = false;
                _context.Messages.Add(message);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}