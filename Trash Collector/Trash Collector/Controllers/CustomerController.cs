using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trash_Collector.Models;

namespace Trash_Collector.Controllers
{
    public class CustomerController : Controller
    {
        public ApplicationDbContext context = new ApplicationDbContext();

        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> allCustomers = context.Customers.ToList();
            return View(allCustomers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            Customer customerDetails = context.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
            return View(customerDetails);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                customer.ApplicationId = User.Identity.GetUserId();
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer foundCustomer = context.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
            return View(foundCustomer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                Customer editedCustomer = context.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
                editedCustomer.FirstName = customer.FirstName;
                editedCustomer.LastName = customer.LastName;
                editedCustomer.StreetAddress = customer.StreetAddress;
                editedCustomer.City = customer.City;
                editedCustomer.State = customer.State;
                editedCustomer.ZipCode = customer.ZipCode;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer foundCustomer = context.Customers.Find(id);
            return View(foundCustomer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                Customer foundCustomer = context.Customers.Find(id);
                context.Customers.Remove(foundCustomer);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
