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
    public class StepTypesController : Controller
    {
        private Entities db = new Entities();

        // GET: StepTypes
        public ActionResult Index()
        {
            return View(db.StepTypes.ToList());
        }

        // GET: StepTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StepType stepType = db.StepTypes.Find(id);
            if (stepType == null)
            {
                return HttpNotFound();
            }
            return View(stepType);
        }

        // GET: StepTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StepTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] StepType stepType)
        {
            if (ModelState.IsValid)
            {
                db.StepTypes.Add(stepType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stepType);
        }

        // GET: StepTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StepType stepType = db.StepTypes.Find(id);
            if (stepType == null)
            {
                return HttpNotFound();
            }
            return View(stepType);
        }

        // POST: StepTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] StepType stepType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stepType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stepType);
        }

        // GET: StepTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StepType stepType = db.StepTypes.Find(id);
            if (stepType == null)
            {
                return HttpNotFound();
            }
            return View(stepType);
        }

        // POST: StepTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StepType stepType = db.StepTypes.Find(id);
            db.StepTypes.Remove(stepType);
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
