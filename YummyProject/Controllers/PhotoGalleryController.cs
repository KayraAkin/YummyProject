using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class PhotoGalleryController : Controller
    {
        YummyContext _context = new YummyContext();
        public ActionResult Index()
        {
            var values = _context.PhotoGalleries.ToList();
            return View(values);
        }
        public ActionResult AddPhotoGalery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPhotoGalery(PhotoGallery photoGallery)
        {
            if (!ModelState.IsValid)
            {
                return View(photoGallery);
            }


            _context.PhotoGalleries.Add(photoGallery);
            int result = _context.SaveChanges();

            if (result == 0)
            {
                ViewBag.error = "Değerler kaydedilirken bir hata ile karşılaşıldı";
                return View(photoGallery);
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeletePhotoGallery(int id)
        {
            var value = _context.PhotoGalleries.Find(id);
            _context.PhotoGalleries.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}