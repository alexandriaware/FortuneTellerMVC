using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FortuneTellerMVC.Models;

namespace FortuneTellerMVC.Controllers
{
    public class CustomersController : Controller
    {
        private FortuneTellerMVCEntities db = new FortuneTellerMVCEntities();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            

            //begin fortune teller response
            //retirement age
            if ((customer.Age % 2) == 0)
            {
                ViewBag.RetirementAge = 12;

            }
            else
            {
               ViewBag.RetirementAge = 20;
            }

            //In the bank
            if (customer.BirthMonth >= 1 && customer.BirthMonth <= 4)
            {
                ViewBag.BankMoney = 1000000;
            }
            else if (customer.BirthMonth >= 5 && customer.BirthMonth <= 8)
            {
                ViewBag.BankMoney = 1000;
            }
            else if (customer.BirthMonth >= 9 && customer.BirthMonth <= 12)
            {
                ViewBag.BankMoney = 1;
            }
            else
            {
                ViewBag.BankMoney = 0;
            }

            //Transportations!
            if (customer.FavoriteColor == "red")
            {
                ViewBag.Transport = "Motorized Wheelchair";
            }
            else if (customer.FavoriteColor == "orange")
            {
                ViewBag.Transport = "Arabian Stallion";
            }
            else if (customer.FavoriteColor == "yellow")
            {
                ViewBag.Transport = "Ice Cream Truck";
            }
            else if (customer.FavoriteColor == "green")
            {
                ViewBag.Transport = "Skateboard";
            }
            else if (customer.FavoriteColor == "blue")
            {
                ViewBag.Transport = "Yacht";
            }
            else if (customer.FavoriteColor == "indigo")
            {
                ViewBag.Transport = "Hover Car";
            }
            else if (customer.FavoriteColor == "violet")
            {
                ViewBag.Transport = "Tesla Model S";
            }
            else
                ViewBag.Transport = "pair of roller skates";


            //Homecation
            if (customer.NumberOfSiblings == 0)
            {
                ViewBag.Location = "Amsterdam";
            }
            else if (customer.NumberOfSiblings == 1)
            {
                ViewBag.Location = "New York";
            }
            else if (customer.NumberOfSiblings == 2)
            {
                ViewBag.Location = "London";
            }
            else if (customer.NumberOfSiblings == 3)
            {
                ViewBag.Location = "Dublin";
            }
            else if (customer.NumberOfSiblings > 3)
            {
                ViewBag.Location = "Orlando";
            }
            else
            {
                ViewBag.Location = "WWII Germany";
            }




            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
    }
}
