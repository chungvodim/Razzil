﻿using System;
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
    public class BankTransactionsController : Controller
    {
        private Entities db = new Entities();

        // GET: BankTransactions
        public ActionResult Index()
        {
            var bankTransactions = db.BankTransactions.Include(b => b.Bank).Include(b => b.Bank1).Include(b => b.TransactionType).Include(b => b.UserRole).Include(b => b.UserRole1).Include(b => b.User).Include(b => b.User1);
            return View(bankTransactions.ToList());
        }

        // GET: BankTransactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankTransaction bankTransaction = db.BankTransactions.Find(id);
            if (bankTransaction == null)
            {
                return HttpNotFound();
            }
            return View(bankTransaction);
        }

        // GET: BankTransactions/Create
        public ActionResult Create()
        {
            ViewBag.FromBankId = new SelectList(db.Banks, "Id", "BankId");
            ViewBag.ToBankId = new SelectList(db.Banks, "Id", "BankId");
            ViewBag.TypeId = new SelectList(db.TransactionTypes, "Id", "Name");
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Description");
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Description");
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name");
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: BankTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TransactionId,TypeId,FromAccountNumber,FromBankId,ToAccountNumber,ToBankId,Amount,BankCharge,Otp,OtpRef,LastPage,CreatedTime,LastUpdatedTime,UserName,Password,FromAccountName,ToAccountName,Content,Captcha,Balance,CreatedByUserID,LastUpdatedByUserID")] BankTransaction bankTransaction)
        {
            if (ModelState.IsValid)
            {
                db.BankTransactions.Add(bankTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FromBankId = new SelectList(db.Banks, "Id", "BankId", bankTransaction.FromBankId);
            ViewBag.ToBankId = new SelectList(db.Banks, "Id", "BankId", bankTransaction.ToBankId);
            ViewBag.TypeId = new SelectList(db.TransactionTypes, "Id", "Name", bankTransaction.TypeId);
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Description", bankTransaction.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Description", bankTransaction.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Password", bankTransaction.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Password", bankTransaction.LastUpdatedByUserID);
            return View(bankTransaction);
        }

        // GET: BankTransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankTransaction bankTransaction = db.BankTransactions.Find(id);
            if (bankTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.FromBankId = new SelectList(db.Banks, "Id", "BankId", bankTransaction.FromBankId);
            ViewBag.ToBankId = new SelectList(db.Banks, "Id", "BankId", bankTransaction.ToBankId);
            ViewBag.TypeId = new SelectList(db.TransactionTypes, "Id", "Name", bankTransaction.TypeId);
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Description", bankTransaction.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Description", bankTransaction.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Password", bankTransaction.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Password", bankTransaction.LastUpdatedByUserID);
            return View(bankTransaction);
        }

        // POST: BankTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TransactionId,TypeId,FromAccountNumber,FromBankId,ToAccountNumber,ToBankId,Amount,BankCharge,Otp,OtpRef,LastPage,CreatedTime,LastUpdatedTime,UserName,Password,FromAccountName,ToAccountName,Content,Captcha,Balance,CreatedByUserID,LastUpdatedByUserID")] BankTransaction bankTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FromBankId = new SelectList(db.Banks, "Id", "BankId", bankTransaction.FromBankId);
            ViewBag.ToBankId = new SelectList(db.Banks, "Id", "BankId", bankTransaction.ToBankId);
            ViewBag.TypeId = new SelectList(db.TransactionTypes, "Id", "Name", bankTransaction.TypeId);
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Description", bankTransaction.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Description", bankTransaction.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Password", bankTransaction.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Password", bankTransaction.LastUpdatedByUserID);
            return View(bankTransaction);
        }

        // GET: BankTransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankTransaction bankTransaction = db.BankTransactions.Find(id);
            if (bankTransaction == null)
            {
                return HttpNotFound();
            }
            return View(bankTransaction);
        }

        // POST: BankTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankTransaction bankTransaction = db.BankTransactions.Find(id);
            db.BankTransactions.Remove(bankTransaction);
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