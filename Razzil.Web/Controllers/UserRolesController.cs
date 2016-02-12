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
    public class UserRolesController : Controller
    {
        private Entities db = new Entities();

        // GET: UserRoles
        public ActionResult Index()
        {
            var userRoles = db.UserRoles.Include(u => u.UserRole2).Include(u => u.UserRole3).Include(u => u.User).Include(u => u.User1);
            return View(userRoles.ToList());
        }

        // GET: UserRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // GET: UserRoles/Create
        public ActionResult Create()
        {
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Name");
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Name");
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name");
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                db.UserRoles.Add(userRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Name", userRole.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Name", userRole.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", userRole.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", userRole.LastUpdatedByUserID);
            return View(userRole);
        }

        // GET: UserRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Name", userRole.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Name", userRole.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", userRole.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", userRole.LastUpdatedByUserID);
            return View(userRole);
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedByUserID = new SelectList(db.UserRoles, "Id", "Name", userRole.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.UserRoles, "Id", "Name", userRole.LastUpdatedByUserID);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", userRole.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", userRole.LastUpdatedByUserID);
            return View(userRole);
        }

        // GET: UserRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRole userRole = db.UserRoles.Find(id);
            db.UserRoles.Remove(userRole);
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