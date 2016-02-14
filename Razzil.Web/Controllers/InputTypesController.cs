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
    public class InputTypesController : Controller
    {
        private Entities db = new Entities();

        // GET: InputTypes
        public ActionResult Index()
        {
            var inputTypes = db.InputTypes.Include(i => i.User).Include(i => i.User1);
            return View(inputTypes.ToList());
        }

        // GET: InputTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataAccess.Repository.InputType inputType = db.InputTypes.Find(id);
            if (inputType == null)
            {
                return HttpNotFound();
            }
            return View(inputType);
        }

        // GET: InputTypes/Create
        public ActionResult Create()
        {
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name");
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: InputTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] DataAccess.Repository.InputType inputType)
        {
            if (ModelState.IsValid)
            {
                db.InputTypes.Add(inputType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", inputType.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", inputType.LastUpdatedByUserID);
            return View(inputType);
        }

        // GET: InputTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataAccess.Repository.InputType inputType = db.InputTypes.Find(id);
            if (inputType == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", inputType.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", inputType.LastUpdatedByUserID);
            return View(inputType);
        }

        // POST: InputTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] DataAccess.Repository.InputType inputType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inputType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", inputType.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", inputType.LastUpdatedByUserID);
            return View(inputType);
        }

        // GET: InputTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataAccess.Repository.InputType inputType = db.InputTypes.Find(id);
            if (inputType == null)
            {
                return HttpNotFound();
            }
            return View(inputType);
        }

        // POST: InputTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DataAccess.Repository.InputType inputType = db.InputTypes.Find(id);
            db.InputTypes.Remove(inputType);
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
