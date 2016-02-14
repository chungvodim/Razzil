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
    public class AccountGroupsController : Controller
    {
        private Entities db = new Entities();

        // GET: AccountGroups
        public ActionResult Index()
        {
            var accountGroups = db.AccountGroups.Include(a => a.User).Include(a => a.User1);
            return View(accountGroups.ToList());
        }

        // GET: AccountGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGroup = db.AccountGroups.Find(id);
            if (accountGroup == null)
            {
                return HttpNotFound();
            }
            return View(accountGroup);
        }

        // GET: AccountGroups/Create
        public ActionResult Create()
        {
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name");
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: AccountGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] AccountGroup accountGroup)
        {
            if (ModelState.IsValid)
            {
                db.AccountGroups.Add(accountGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", accountGroup.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", accountGroup.LastUpdatedByUserID);
            return View(accountGroup);
        }

        // GET: AccountGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGroup = db.AccountGroups.Find(id);
            if (accountGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", accountGroup.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", accountGroup.LastUpdatedByUserID);
            return View(accountGroup);
        }

        // POST: AccountGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] AccountGroup accountGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", accountGroup.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", accountGroup.LastUpdatedByUserID);
            return View(accountGroup);
        }

        // GET: AccountGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGroup = db.AccountGroups.Find(id);
            if (accountGroup == null)
            {
                return HttpNotFound();
            }
            return View(accountGroup);
        }

        // POST: AccountGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountGroup accountGroup = db.AccountGroups.Find(id);
            db.AccountGroups.Remove(accountGroup);
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
