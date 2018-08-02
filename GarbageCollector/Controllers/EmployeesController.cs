using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GarbageCollector.Models;
using Microsoft.AspNet.Identity;

namespace GarbageCollector.Controllers
{
    [Authorize(Roles = "Employee, Admin")]
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var pickupsToday = DateTime.Now.DayOfWeek.ToString();
            string currentUserId = User.Identity.GetUserId();
            Employees me = db.Employees.Where(e => e.Id == currentUserId).FirstOrDefault();

            var zoneCustomers = db.Customers.Where(c => c.ZipCode == me.ZipCode);

            return View(zoneCustomers.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,ZipCode")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                employees.Id = User.Identity.GetUserId();
                db.Employees.Add(employees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            if (id .Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }
        
        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WeeklyIsPickedUp,OneTimeIsPickedUp")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customers);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = db.Employees.Find(id);
            db.Employees.Remove(employees);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult CustomersList(Employees employee, Customers customers)
        {
            if (employee.ZipCode == customers.ZipCode)
            {
                foreach (var zipcode in db.Customers)
                {
                    return View(db.Customers.ToList());
                }
            }
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterPickupsByDay(Customers customers)
        {
            if (customers.WeeklyPickUpDate == "Monday")
            {
                return View(db.Customers.ToList());
            }
            if (customers.WeeklyPickUpDate == "Tuesday")
            {
                return View(db.Customers.ToList());
            }
            if (customers.WeeklyPickUpDate == "Wednesday")
            {
                return View(db.Customers.ToList());
            }
            if (customers.WeeklyPickUpDate == "Thursday")
            {
                return View(db.Customers.ToList());
            }
            if (customers.WeeklyPickUpDate == "Friday")
            {
                return View(db.Customers.ToList());
            }
            if (customers.WeeklyPickUpDate == "Saturday")
            {
                return View(db.Customers.ToList());
            }
            if (customers.WeeklyPickUpDate == "Sunday")
            {
                return View(db.Customers.ToList());
            }
            return View();
        }
    }
}

