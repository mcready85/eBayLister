using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eBayLister.Models;

namespace eBayLister.Controllers
{
    public class eBayItemsController : Controller
    {
        private eBayListerContext db = new eBayListerContext();

        // GET: eBayItems
        public ActionResult Index()
        {
            return View(db.eBayItems.ToList());
        }

        // GET: eBayItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eBayItem eBayItem = db.eBayItems.Find(id);
            if (eBayItem == null)
            {
                return HttpNotFound();
            }
            return View(eBayItem);
        }

        // GET: eBayItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: eBayItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ItemSKU,Title,CategoryType,Price,Condition,HandlingTime,Duration,Format,PictureURL,Quantity,ProductDescription")] eBayItem eBayItem)
        {
            if (ModelState.IsValid)
            {
                db.eBayItems.Add(eBayItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eBayItem);
        }

        // GET: eBayItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eBayItem eBayItem = db.eBayItems.Find(id);
            if (eBayItem == null)
            {
                return HttpNotFound();
            }
            return View(eBayItem);
        }

        // POST: eBayItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemSKU,Title,CategoryType,Price,Condition,HandlingTime,Duration,Format,PictureURL,Quantity,ProductDescription")] eBayItem eBayItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eBayItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eBayItem);
        }

        // GET: eBayItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eBayItem eBayItem = db.eBayItems.Find(id);
            if (eBayItem == null)
            {
                return HttpNotFound();
            }
            return View(eBayItem);
        }

        // POST: eBayItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eBayItem eBayItem = db.eBayItems.Find(id);
            db.eBayItems.Remove(eBayItem);
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
