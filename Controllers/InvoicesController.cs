using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HF_super_mart.Models;

namespace HF_super_mart.Controllers
{
    public class InvoicesController : Controller
    {
        private HF_SUPER_MARTEntities1 db = new HF_SUPER_MARTEntities1();

        // GET: Invoices
        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.Category).Include(i => i.Customer).Include(i => i.Product).Include(i => i.Price);
            return View(invoices.ToList());
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.Category_Name = new SelectList(db.Categories, "Category_Id", "Name");
            ViewBag.Customer_Name = new SelectList(db.Customers, "Customer_Id", "First_Name");
            ViewBag.Product_Name = new SelectList(db.Products, "Product_id", "Name");
            ViewBag.Product_Price = new SelectList(db.Prices, "Price_Id", "Product_Price");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Invoice_Id,Customer_Name,Category_Name,Product_Name,Product_Price,Invoice_date,Invoice_time")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_Name = new SelectList(db.Categories, "Category_Id", "Name", invoice.Category_Name);
            ViewBag.Customer_Name = new SelectList(db.Customers, "Customer_Id", "First_Name", invoice.Customer_Name);
            ViewBag.Product_Name = new SelectList(db.Products, "Product_id", "Name", invoice.Product_Name);
            ViewBag.Product_Price = new SelectList(db.Prices, "Price_Id", "Product_Price", invoice.Product_Price);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Name = new SelectList(db.Categories, "Category_Id", "Name", invoice.Category_Name);
            ViewBag.Customer_Name = new SelectList(db.Customers, "Customer_Id", "First_Name", invoice.Customer_Name);
            ViewBag.Product_Name = new SelectList(db.Products, "Product_id", "Name", invoice.Product_Name);
            ViewBag.Product_Price = new SelectList(db.Prices, "Price_Id", "Product_Price", invoice.Product_Price);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Invoice_Id,Customer_Name,Category_Name,Product_Name,Product_Price,Invoice_date,Invoice_time")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_Name = new SelectList(db.Categories, "Category_Id", "Name", invoice.Category_Name);
            ViewBag.Customer_Name = new SelectList(db.Customers, "Customer_Id", "First_Name", invoice.Customer_Name);
            ViewBag.Product_Name = new SelectList(db.Products, "Product_id", "Name", invoice.Product_Name);
            ViewBag.Product_Price = new SelectList(db.Prices, "Price_Id", "Product_Price", invoice.Product_Price);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
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
