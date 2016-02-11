using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Razzil.DataAccess.Repository;

namespace Razzil.Web.Controllers
{
    public class TransactionTypesController : Controller
    {
        private Entities db = new Entities();

        // GET: TransactionTypes
        public ActionResult Index()
        {
            var transactionTypes = db.TransactionTypes.Include(t => t.UserRole).Include(t => t.UserRole1).Include(t => t.User).Include(t => t.User1);
            return View(transactionTypes.ToList());
        }

        // GET: TransactionTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionType transactionType = db.TransactionTypes.Find(id);
            if (transactionType == null)
            {
                return HttpNotFound();
            }
            return View(transactionType);
        }

        // GET: TransactionTypes/Create
        public ActionResult Create()
        {
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Name");
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Name");
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name");
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: TransactionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] TransactionType transactionType)
        {
            if (ModelState.IsValid)
            {
                db.TransactionTypes.Add(transactionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Name", transactionType.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Name", transactionType.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", transactionType.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", transactionType.CreatedByUserID);
            return View(transactionType);
        }

        // GET: TransactionTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionType transactionType = db.TransactionTypes.Find(id);
            if (transactionType == null)
            {
                return HttpNotFound();
            }
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Name", transactionType.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Name", transactionType.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", transactionType.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", transactionType.CreatedByUserID);
            return View(transactionType);
        }

        // POST: TransactionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] TransactionType transactionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Name", transactionType.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Name", transactionType.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", transactionType.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", transactionType.CreatedByUserID);
            return View(transactionType);
        }

        // GET: TransactionTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionType transactionType = db.TransactionTypes.Find(id);
            if (transactionType == null)
            {
                return HttpNotFound();
            }
            return View(transactionType);
        }

        // POST: TransactionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransactionType transactionType = db.TransactionTypes.Find(id);
            db.TransactionTypes.Remove(transactionType);
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
