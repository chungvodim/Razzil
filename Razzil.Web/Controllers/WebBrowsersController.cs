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
    public class WebBrowsersController : Controller
    {
        private Entities db = new Entities();

        // GET: WebBrowsers
        public ActionResult Index()
        {
            var webBrowsers = db.WebBrowsers.Include(w => w.User).Include(w => w.User1);
            return View(webBrowsers.ToList());
        }

        // GET: WebBrowsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebBrowser webBrowser = db.WebBrowsers.Find(id);
            if (webBrowser == null)
            {
                return HttpNotFound();
            }
            return View(webBrowser);
        }

        // GET: WebBrowsers/Create
        public ActionResult Create()
        {
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name");
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: WebBrowsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Version,Description,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] WebBrowser webBrowser)
        {
            if (ModelState.IsValid)
            {
                db.WebBrowsers.Add(webBrowser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", webBrowser.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", webBrowser.LastUpdatedByUserID);
            return View(webBrowser);
        }

        // GET: WebBrowsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebBrowser webBrowser = db.WebBrowsers.Find(id);
            if (webBrowser == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", webBrowser.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", webBrowser.LastUpdatedByUserID);
            return View(webBrowser);
        }

        // POST: WebBrowsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Version,Description,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] WebBrowser webBrowser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webBrowser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", webBrowser.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", webBrowser.LastUpdatedByUserID);
            return View(webBrowser);
        }

        // GET: WebBrowsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebBrowser webBrowser = db.WebBrowsers.Find(id);
            if (webBrowser == null)
            {
                return HttpNotFound();
            }
            return View(webBrowser);
        }

        // POST: WebBrowsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WebBrowser webBrowser = db.WebBrowsers.Find(id);
            db.WebBrowsers.Remove(webBrowser);
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
