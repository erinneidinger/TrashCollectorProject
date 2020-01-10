using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trash_Collector.Models;

namespace Trash_Collector.Controllers
{
    public class EmployeeController : Controller
    {
        public ApplicationDbContext context = new ApplicationDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> allEmployees = context.Employees.ToList();
            return View(allEmployees);
        }

        public ActionResult IndividualIndex()
        {
            var Id = User.Identity.GetUserId();
            var foundEmployee = context.Employees.Where(a => a.ApplicationID== Id).FirstOrDefault();
            List<Employee> oneEmployee = context.Employees.Where(a => a.EmployeeId == foundEmployee.EmployeeId).ToList();
            return View(oneEmployee);
        }


        

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            Employee employeeDetails = context.Employees.Where(a => a.EmployeeId == id).FirstOrDefault();
            return View(employeeDetails);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                employee.ApplicationID = User.Identity.GetUserId();
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("ListOfPickups");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            Employee foundEmployee = context.Employees.Where(a => a.EmployeeId == id).FirstOrDefault();
            return View(foundEmployee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                // TODO: Add update logic here
                Employee editedEmployee = context.Employees.Where(a => a.EmployeeId == id).FirstOrDefault();
                editedEmployee.FirstName = employee.FirstName;
                editedEmployee.LastName = employee.LastName;
                editedEmployee.ZipCode = employee.ZipCode;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            Employee foundEmployee = context.Employees.Find(id);
            return View(foundEmployee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                // TODO: Add delete logic here
                Employee foundEmployee = context.Employees.Find(id);
                context.Employees.Remove(foundEmployee);
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
