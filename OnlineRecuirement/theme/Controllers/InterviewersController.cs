using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using theme.Models;

namespace theme.Controllers
{
    public class InterviewersController : Controller
    {
        private OnlineRecuriment_dbEntities db = new OnlineRecuriment_dbEntities();

        // GET: Interviewers
        public ActionResult Index()
        {
            var interviewer = db.Interviewer.Include(i => i.Employee);
            return View(interviewer.ToList());
        }

        // GET: Interviewers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interviewer interviewer = db.Interviewer.Find(id);
            if (interviewer == null)
            {
                return HttpNotFound();
            }
            return View(interviewer);
        }

        // GET: Interviewers/Create
        public ActionResult Create()
        {
            ViewBag.Emp_id = new SelectList(db.Employee, "Id", "Name");
            return View();
        }

        // POST: Interviewers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Emp_id")] Interviewer interviewer)
        {
            if (ModelState.IsValid)
            {
                db.Interviewer.Add(interviewer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Emp_id = new SelectList(db.Employee, "Id", "Name", interviewer.Emp_id);
            return View(interviewer);
        }

        // GET: Interviewers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interviewer interviewer = db.Interviewer.Find(id);
            if (interviewer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Emp_id = new SelectList(db.Employee, "Id", "Name", interviewer.Emp_id);
            return View(interviewer);
        }

        // POST: Interviewers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Emp_id")] Interviewer interviewer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interviewer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Emp_id = new SelectList(db.Employee, "Id", "Name", interviewer.Emp_id);
            return View(interviewer);
        }

        // GET: Interviewers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interviewer interviewer = db.Interviewer.Find(id);
            if (interviewer == null)
            {
                return HttpNotFound();
            }
            return View(interviewer);
        }

        // POST: Interviewers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Interviewer interviewer = db.Interviewer.Find(id);
            db.Interviewer.Remove(interviewer);
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
