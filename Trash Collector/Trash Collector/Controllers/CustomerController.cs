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

        public ActionResult IndividualIndex()
        {
            var Id = User.Identity.GetUserId();
            var foundCustomer = context.Customers.Where(a => a.ApplicationId== Id).FirstOrDefault();
            List<Customer> oneCustomer = context.Customers.Where(a => a.CustomerId == foundCustomer.CustomerId).ToList();
            return View(oneCustomer);
        }

        //Get: Customer Lists (For Employees)
        public ActionResult ListOfPickups()
        {
            string dayOfTheWeek = DateTime.Now.DayOfWeek.ToString();
            var Id = User.Identity.GetUserId();
            FilterViewModel filterView = new FilterViewModel();
            filterView.DaysOfTheWeek = new SelectList(new List<string> { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" });
            var foundEmployee = context.Employees.Where(a => a.ApplicationID == Id).FirstOrDefault();
            filterView.Customers = context.Customers.Where(a => a.ZipCode == foundEmployee.ZipCode && a.PickUpDay == dayOfTheWeek || a.ExtraPickUpDate == dayOfTheWeek).ToList();

            return View(filterView);
        }

        [HttpPost]
        public ActionResult ListOfPickups(FilterViewModel Filterview)
        {
            FilterViewModel filterView = new FilterViewModel();
            filterView.DaysOfTheWeek = new SelectList(new List<string> { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" });            
            string weekDay = Filterview.WeekDay;
            var Id = User.Identity.GetUserId();
            var foundEmployee = context.Employees.Where(a => a.ApplicationID == Id).FirstOrDefault();
            filterView.Customers = context.Customers.Where(a => a.ZipCode == foundEmployee.ZipCode && a.PickUpDay == weekDay || a.ExtraPickUpDate == weekDay).ToList();

            return View(filterView);
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
                return RedirectToAction("IndividualIndex");
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
                return RedirectToAction("IndividualIndex");
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
                return RedirectToAction("IndividualIndex", "Customer");
            }
            catch
            {
                return View();
            }
        }
        // GET: Customer/Edit/5
        public ActionResult CreatePickup(int id)
        {
            Customer foundCustomer = context.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
            return View(foundCustomer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult CreatePickup(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                Customer editedCustomer = context.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
                editedCustomer.PickUpDay = customer.PickUpDay;
                editedCustomer.SuspendedStart = customer.SuspendedStart;
                editedCustomer.SuspectedEnd = customer.SuspectedEnd;

               if(User.IsInRole("Customer"))
                if (editedCustomer.ExtraPickUpDate == null)
                {
                    editedCustomer.ExtraPickUpDate = customer.ExtraPickUpDate;
                }
           
                if (User.IsInRole("Employee"))
                {
                    editedCustomer.Balance = customer.Balance;
                    editedCustomer.PickupConfirmation = customer.PickupConfirmation;
                    if(editedCustomer.PickupConfirmation == true)
                    {
                        editedCustomer.Balance += 10.00;
                    }
                }
      
                context.SaveChanges();

                if (User.IsInRole("Employee"))
                {
                    return RedirectToAction("ListOfPickups");
                }
                else
                {
                    return RedirectToAction("IndividualIndex");
                }
            }
            catch
            {
                return View();
            }
        }

    }
}
