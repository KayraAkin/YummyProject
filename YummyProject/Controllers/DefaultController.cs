using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            
            return View();
        }

        public PartialViewResult DefaultFeatures()
        {
            var values = context.Features.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultProduct()
        {
            var values = context.Categories.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultService()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultEvent()
        {
            var values = context.Events.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultChef()
        {
            var values = context.Chefs.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultBooking()
        {
            var values = context.Bookings.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultPhotoGallery()
        {
            var values = context.PhotoGalleries.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultContactInfo()
        {
            var values = context.ContactInfos.FirstOrDefault();
            return PartialView(values);
        }
        public PartialViewResult DefaultStats()
        {
            ViewBag.product = context.Products.Count();
            ViewBag.category = context.Categories.Count();
            ViewBag.events = context.Events.Count();
            ViewBag.chefs = context.Chefs.Count();
            return PartialView();
        }

    }
}