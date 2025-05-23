﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;


namespace YummyProject.Controllers
{
    public class ChefController : Controller
    {
        YummyContext _context = new YummyContext();
        public ActionResult Index()
        {
            var values = _context.Chefs.ToList();
            return View(values);
        }
        public ActionResult AddChef()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddChef(Chef chef)
        {
            if (!ModelState.IsValid)
            {
                return View(chef);
            }


            _context.Chefs.Add(chef);
            int result = _context.SaveChanges();

            if (result == 0)
            {
                ViewBag.error = "Değerler kaydedilirken bir hata ile karşılaşıldı";
                return View(chef);
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteChef(int id)
        {
            var value = _context.Chefs.Find(id);
            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateChef(int id)
        {
            var value = _context.Chefs.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateChef(Chef chef)
        {
            _context.Entry(chef).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateChefSocailMedia(int id)
        {
            var value = _context.ChefSocials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateChefSocailMedia(ChefSocial chefSocial)
        {
            _context.Entry(chefSocial).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}