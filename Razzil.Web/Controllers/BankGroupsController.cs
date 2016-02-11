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
    public class BankGroupsController : Controller
    {
        private Entities db = new Entities();

        // GET: BankGroups
        public ActionResult Index()
        {
            var bankGroups = db.BankGroups.Include(b => b.UserRole).Include(b => b.UserRole1).Include(b => b.User).Include(b => b.User1);
            return View(bankGroups.ToList());
        }

        // GET: BankGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankGroup bankGroup = db.BankGroups.Find(id);
            if (bankGroup == null)
            {
                return HttpNotFound();
            }
            return View(bankGroup);
        }

        // GET: BankGroups/Create
        public ActionResult Create()
        {
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Name");
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Name");
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name");
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: BankGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BankId,Name,FullName,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] BankGroup bankGroup)
        {
            if (ModelState.IsValid)
            {
                db.BankGroups.Add(bankGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Name", bankGroup.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Name", bankGroup.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", bankGroup.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", bankGroup.LastUpdatedByUserID);
            return View(bankGroup);
        }

        // GET: BankGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankGroup bankGroup = db.BankGroups.Find(id);
            if (bankGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Name", bankGroup.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Name", bankGroup.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", bankGroup.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", bankGroup.LastUpdatedByUserID);
            return View(bankGroup);
        }

        // POST: BankGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BankId,Name,FullName,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] BankGroup bankGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Name", bankGroup.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Name", bankGroup.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", bankGroup.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", bankGroup.LastUpdatedByUserID);
            return View(bankGroup);
        }

        // GET: BankGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankGroup bankGroup = db.BankGroups.Find(id);
            if (bankGroup == null)
            {
                return HttpNotFound();
            }
            return View(bankGroup);
        }

        // POST: BankGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankGroup bankGroup = db.BankGroups.Find(id);
            db.BankGroups.Remove(bankGroup);
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
