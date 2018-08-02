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
    [Authorize(Roles = "Customer, Employee, Admin")]
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var customerInfo = from c in db.Customers
                               where c.Id.Equals(userId)
                               select c;
            customerInfo.ToList();
            return View(customerInfo);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Address,City,State,ZipCode,PickUpDate,DateExclusionStart,DateExclusionEnd,CurrentBill")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                customers.Id = User.Identity.GetUserId();
                db.Customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customers);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,'',FirstName,LastName,Address,City,State,ZipCode,PickUpDate,DateExclusionStart,DateExclusionEnd,CurrentBill")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customers);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customers = db.Customers.Find(id);
            db.Customers.Remove(customers);
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

        public ActionResult EmployeeEdit(int id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }
        // POST: Customers/EmployeeEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeEdit([Bind(Include = "CustomerId,Id,FirstName,LastName,Address,City,State,ZipCode,PickUpDate,DateExclusionStart,DateExclusionEnd,CurrentBill,WeeklyIsPickedUp,OneTimeisPickedUp")] Customers customers)
        {

            var customerId = customers.CustomerId;
            var pickup = (from p in db.Customers
                                where p.CustomerId.Equals(customerId)
                                select p).First();

            if (ModelState.IsValid)
            {
                pickup.OneTimeisPickedUp = customers.OneTimeisPickedUp;
                pickup.WeeklyisPickedUp = customers.WeeklyisPickedUp;
                
                db.Entry(pickup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customers);
        }
    }
}
