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
    public class BanksController : Controller
    {
        private Entities db = new Entities();

        // GET: Banks
        public ActionResult Index()
        {
            var banks = db.Banks.Include(b => b.Bank2).Include(b => b.User).Include(b => b.User1);
            return View(banks.ToList());
        }

        // GET: Banks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Banks.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // GET: Banks/Create
        public ActionResult Create()
        {
            ViewBag.BankGroupId = new SelectList(db.Banks, "Id", "Name");
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name");
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: Banks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FullName,BankId,BankGroupId,TimeOut,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                db.Banks.Add(bank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BankGroupId = new SelectList(db.Banks, "Id", "Name", bank.BankGroupId);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", bank.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", bank.LastUpdatedByUserID);
            return View(bank);
        }

        // GET: Banks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Banks.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            ViewBag.BankGroupId = new SelectList(db.Banks, "Id", "Name", bank.BankGroupId);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", bank.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", bank.LastUpdatedByUserID);
            return View(bank);
        }

        // POST: Banks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FullName,BankId,BankGroupId,TimeOut,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BankGroupId = new SelectList(db.Banks, "Id", "Name", bank.BankGroupId);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", bank.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", bank.LastUpdatedByUserID);
            return View(bank);
        }

        // GET: Banks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Banks.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // POST: Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bank bank = db.Banks.Find(id);
            db.Banks.Remove(bank);
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
