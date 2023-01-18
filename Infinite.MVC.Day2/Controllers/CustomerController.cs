using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infinite.MVC.Day2.Models;

namespace Infinite.MVC.Day2.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context = null;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customer
        public ActionResult Index()
        {
            //Customer customer = new Customer();
            //List<Customer> customers = customer.GetCustomers();
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //Customer customerObj = new Customer();
            //var customer = customerObj.GetCustomers().FirstOrDefault(c => c.Id == id);
            var customer = _context.Customers.FirstOrDefault(p => p.Id == id);
            if (customer != null)
            {
                return View(customer);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            return View();
        }

        
        
    }
}