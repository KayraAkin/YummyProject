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
    public class ChefSocialController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index(int id)
        {
            var values = context.ChefSocials.Where(x=> x.ChefId == id).ToList();
            ViewBag.chef = id;
            return View(values);
        }
        public ActionResult AddChefSocial(int id)
        {
            ViewBag.chefId = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddChefSocial(ChefSocial chefSocial)
        {
            if (!ModelState.IsValid)
            {
                return View(chefSocial);
            }


            context.ChefSocials.Add(chefSocial);
            int result = context.SaveChanges();

            if (result == 0)
            {
                ViewBag.error = "Değerler kaydedilirken bir hata ile karşılaşıldı";
                return View(chefSocial);
            }
            return RedirectToAction("Index", "Chef");
        }
        public ActionResult DeleteChefSocial(int id)
        {
            var value = context.ChefSocials.Find(id);
            context.ChefSocials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index","Chef");
        }
        public ActionResult UpdateChefSocial(int id)
        {
            var value = context.ChefSocials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateChefSocial(ChefSocial chefSocial)
        {
            context.Entry(chefSocial).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index","Chef");
        }
    }
}