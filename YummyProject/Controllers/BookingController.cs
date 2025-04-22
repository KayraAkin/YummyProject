using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class BookingController : Controller
    {
        YummyContext _context = new YummyContext();
        public ActionResult Index()
        {
            var values = _context.Bookings.ToList();
            return View(values);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SendMessage(Booking booking, string time)
        {
            if (ModelState.IsValid)
            {
                string combinedDateTime = $"{booking.BookingDate.ToString("yyyy-MM-dd")} {time}";
                DateTime parsedDateTime;

                if (!DateTime.TryParse(combinedDateTime, out parsedDateTime))
                {
                    return new HttpStatusCodeResult(400, "Tarih veya saat formatı hatalı.");
                }
                booking.BookingDate = parsedDateTime;

                booking.IsApproved = false;
                _context.Bookings.Add(booking);
                _context.SaveChanges();

                return Content("OK");
            }
            return new HttpStatusCodeResult(400, "Geçersiz veri.");
        }
        public ActionResult ChangeIsApproved(int id)
        {
            var value = _context.Bookings.Find(id);
            if (value.IsApproved)
            {
                value.IsApproved = false;
                _context.SaveChanges();
            }
            else
            {
                value.IsApproved = true;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBooking(int id)
        {
            var value = _context.Bookings.Find(id);
            _context.Bookings.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}