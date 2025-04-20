using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ProductController : Controller
    {
        YummyContext _context = new YummyContext();
        public ActionResult Index()
        {
            var values = _context.Products.ToList();
            return View(values);
        }
        public ActionResult AddProduct()
        {
            ViewBag.categoryList = _context.Categories.Select(x=> new SelectListItem{
                Text =x.CategoryName,
                Value =x.CategoryId.ToString()
            }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {


            if (!ModelState.IsValid)
            {
                ViewBag.categoryList = _context.Categories.Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();

                return View(product);
            }
            _context.Products.Add(product);
            var result = _context.SaveChanges();
            if(result == 0)
            {
                ViewBag.error = "Değerler kaydedilirken bir hata ile karşılaşıldı";
            }

            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}