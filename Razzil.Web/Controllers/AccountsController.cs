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
    public class AccountsController : Controller
    {
        private Entities db = new Entities();

        // GET: Accounts
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(a => a.AccountGroup).Include(a => a.Bank).Include(a => a.UserRole).Include(a => a.UserRole1).Include(a => a.User).Include(a => a.User1);
            return View(accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            ViewBag.AccountGroupId = new SelectList(db.AccountGroups, "Id", "Name");
            ViewBag.BankId = new SelectList(db.Banks, "Id", "BankId");
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Description");
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Description");
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Password");
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Password");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BankId,AccountGroupId,AccountName,AccountNumber,Password,Phone,Balance,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountGroupId = new SelectList(db.AccountGroups, "Id", "Name", account.AccountGroupId);
            ViewBag.BankId = new SelectList(db.Banks, "Id", "BankId", account.BankId);
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Description", account.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Description", account.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Password", account.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Password", account.LastUpdatedByUserID);
            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountGroupId = new SelectList(db.AccountGroups, "Id", "Name", account.AccountGroupId);
            ViewBag.BankId = new SelectList(db.Banks, "Id", "BankId", account.BankId);
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Description", account.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Description", account.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Password", account.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Password", account.LastUpdatedByUserID);
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BankId,AccountGroupId,AccountName,AccountNumber,Password,Phone,Balance,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountGroupId = new SelectList(db.AccountGroups, "Id", "Name", account.AccountGroupId);
            ViewBag.BankId = new SelectList(db.Banks, "Id", "BankId", account.BankId);
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Description", account.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Description", account.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Password", account.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Password", account.LastUpdatedByUserID);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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
