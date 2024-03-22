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
    public class order_itemsController : Controller
    {
        private HF_SUPER_MARTEntities1 db = new HF_SUPER_MARTEntities1();

        // GET: order_items
        public ActionResult Index()
        {
            var order_items = db.order_items.Include(o => o.Order).Include(o => o.Product);
            return View(order_items.ToList());
        }

        // GET: order_items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_items order_items = db.order_items.Find(id);
            if (order_items == null)
            {
                return HttpNotFound();
            }
            return View(order_items);
        }

        // GET: order_items/Create
        public ActionResult Create()
        {
            ViewBag.Order_id = new SelectList(db.Orders, "Order_id", "Order_id");
            ViewBag.Product_id = new SelectList(db.Products, "Product_id", "Name");
            return View();
        }

        // POST: order_items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_Items1,Order_id,Product_id,Quantity,Price")] order_items order_items)
        {
            if (ModelState.IsValid)
            {
                db.order_items.Add(order_items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Order_id = new SelectList(db.Orders, "Order_id", "Order_id", order_items.Order_id);
            ViewBag.Product_id = new SelectList(db.Products, "Product_id", "Name", order_items.Product_id);
            return View(order_items);
        }

        // GET: order_items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_items order_items = db.order_items.Find(id);
            if (order_items == null)
            {
                return HttpNotFound();
            }
            ViewBag.Order_id = new SelectList(db.Orders, "Order_id", "Order_id", order_items.Order_id);
            ViewBag.Product_id = new SelectList(db.Products, "Product_id", "Name", order_items.Product_id);
            return View(order_items);
        }

        // POST: order_items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_Items1,Order_id,Product_id,Quantity,Price")] order_items order_items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Order_id = new SelectList(db.Orders, "Order_id", "Order_id", order_items.Order_id);
            ViewBag.Product_id = new SelectList(db.Products, "Product_id", "Name", order_items.Product_id);
            return View(order_items);
        }

        // GET: order_items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_items order_items = db.order_items.Find(id);
            if (order_items == null)
            {
                return HttpNotFound();
            }
            return View(order_items);
        }

        // POST: order_items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order_items order_items = db.order_items.Find(id);
            db.order_items.Remove(order_items);
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
