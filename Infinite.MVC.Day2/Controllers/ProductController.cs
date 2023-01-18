using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infinite.MVC.Day2.Models;
using System.Data.Entity;

namespace Infinite.MVC.Day2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context = null;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Product
        public ActionResult Index()
        {
            //Product prop = new Product();
            //List<Product> products = prop.GetProducts();
            var products = _context.Products.ToList();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            //Product productsObj = new Product();
            //var product = productsObj.GetProducts().FirstOrDefault(c => c.Id == id);
            //var product = _context.Products.FirstOrDefault(p => p.Id == id);
            var product = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                return View(product);
            }
            return HttpNotFound();
        }

        public ActionResult Create()
        {
            var categoreis = _context.Categories.ToList();
            ViewBag.Categories = categoreis;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid) { 
            _context.Products.Add(product);
            _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if(product!=null)
            {
                var categories = _context.Categories.ToList();
                ViewBag.Categories = categories;
                return View(product);
            }
            return HttpNotFound("Product Id doesn't exists");
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if(product!=null)
            {
                var productInDb = _context.Products.Find(product.Id);
                if(productInDb!=null)
                {
                    productInDb.Price = product.Price;
                    productInDb.Quantity = product.Quantity;
                    //_context.Products.AddOrUpdate(productInDb);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var productInDb = _context.Products.FirstOrDefault(p => p.Id == id);
            if(productInDb!=null)
            {
                _context.Products.Remove(productInDb);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

      
    }
}