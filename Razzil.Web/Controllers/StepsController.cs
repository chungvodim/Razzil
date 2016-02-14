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
    public class StepsController : Controller
    {
        private Entities db = new Entities();

        // GET: Steps
        public ActionResult Index()
        {
            var steps = db.Steps.Include(s => s.Bank).Include(s => s.InputType).Include(s => s.StepType).Include(s => s.User).Include(s => s.User1);
            return View(steps.ToList());
        }

        // GET: Steps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Step step = db.Steps.Find(id);
            if (step == null)
            {
                return HttpNotFound();
            }
            return View(step);
        }

        // GET: Steps/Create
        public ActionResult Create()
        {
            ViewBag.BankId = new SelectList(db.Banks, "Id", "Name");
            ViewBag.InputTypeId = new SelectList(db.InputTypes, "Id", "Name");
            ViewBag.StepTypeId = new SelectList(db.StepTypes, "Id", "Name");
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name");
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: Steps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PreviousStepId,CurrentStepId,NextStepId1,NextStepId0,InputTypeId,StepTypeId,BankId,Name,Url,Params,QueyStrings,Encoding,Sign,Pattern,XPath,XPathAttribute,IsConditionType,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] Step step)
        {
            if (ModelState.IsValid)
            {
                db.Steps.Add(step);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BankId = new SelectList(db.Banks, "Id", "Name", step.BankId);
            ViewBag.InputTypeId = new SelectList(db.InputTypes, "Id", "Name", step.InputTypeId);
            ViewBag.StepTypeId = new SelectList(db.StepTypes, "Id", "Name", step.StepTypeId);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", step.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", step.LastUpdatedByUserID);
            return View(step);
        }

        // GET: Steps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Step step = db.Steps.Find(id);
            if (step == null)
            {
                return HttpNotFound();
            }
            ViewBag.BankId = new SelectList(db.Banks, "Id", "Name", step.BankId);
            ViewBag.InputTypeId = new SelectList(db.InputTypes, "Id", "Name", step.InputTypeId);
            ViewBag.StepTypeId = new SelectList(db.StepTypes, "Id", "Name", step.StepTypeId);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", step.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", step.LastUpdatedByUserID);
            return View(step);
        }

        // POST: Steps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PreviousStepId,CurrentStepId,NextStepId1,NextStepId0,InputTypeId,StepTypeId,BankId,Name,Url,Params,QueyStrings,Encoding,Sign,Pattern,XPath,XPathAttribute,IsConditionType,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] Step step)
        {
            if (ModelState.IsValid)
            {
                db.Entry(step).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BankId = new SelectList(db.Banks, "Id", "Name", step.BankId);
            ViewBag.InputTypeId = new SelectList(db.InputTypes, "Id", "Name", step.InputTypeId);
            ViewBag.StepTypeId = new SelectList(db.StepTypes, "Id", "Name", step.StepTypeId);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", step.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", step.LastUpdatedByUserID);
            return View(step);
        }

        // GET: Steps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Step step = db.Steps.Find(id);
            if (step == null)
            {
                return HttpNotFound();
            }
            return View(step);
        }

        // POST: Steps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Step step = db.Steps.Find(id);
            db.Steps.Remove(step);
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
