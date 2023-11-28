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
    public class Interview_schdController : Controller
    {
        private OnlineRecuriment_dbEntities db = new OnlineRecuriment_dbEntities();

        // GET: Interview_schd
        public ActionResult Index()
        {
            var interview_schd = db.Interview_schd.Include(i => i.applicant).Include(i => i.Interviewer).Include(i => i.Vacancy);
            return View(interview_schd.ToList());
        }

        // GET: Interview_schd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interview_schd interview_schd = db.Interview_schd.Find(id);
            if (interview_schd == null)
            {
                return HttpNotFound();
            }
            return View(interview_schd);
        }

        // GET: Interview_schd/Create
        public ActionResult Create()
        {
            ViewBag.Apli_id = new SelectList(db.applicant, "Id", "Name");
            ViewBag.Inte_id = new SelectList(db.Interviewer, "Id", "Id");
            ViewBag.Vacc_id = new SelectList(db.Vacancy, "Id", "Description");
            return View();
        }

        // POST: Interview_schd/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Time,Inte_id,Vacc_id,Apli_id")] Interview_schd interview_schd)
        {
            if (ModelState.IsValid)
            {
                db.Interview_schd.Add(interview_schd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Apli_id = new SelectList(db.applicant, "Id", "Name", interview_schd.Apli_id);
            ViewBag.Inte_id = new SelectList(db.Interviewer, "Id", "Id", interview_schd.Inte_id);
            ViewBag.Vacc_id = new SelectList(db.Vacancy, "Id", "Description", interview_schd.Vacc_id);
            return View(interview_schd);
        }

        // GET: Interview_schd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interview_schd interview_schd = db.Interview_schd.Find(id);
            if (interview_schd == null)
            {
                return HttpNotFound();
            }
            ViewBag.Apli_id = new SelectList(db.applicant, "Id", "Name", interview_schd.Apli_id);
            ViewBag.Inte_id = new SelectList(db.Interviewer, "Id", "Id", interview_schd.Inte_id);
            ViewBag.Vacc_id = new SelectList(db.Vacancy, "Id", "Description", interview_schd.Vacc_id);
            return View(interview_schd);
        }

        // POST: Interview_schd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Time,Inte_id,Vacc_id,Apli_id")] Interview_schd interview_schd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interview_schd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Apli_id = new SelectList(db.applicant, "Id", "Name", interview_schd.Apli_id);
            ViewBag.Inte_id = new SelectList(db.Interviewer, "Id", "Id", interview_schd.Inte_id);
            ViewBag.Vacc_id = new SelectList(db.Vacancy, "Id", "Description", interview_schd.Vacc_id);
            return View(interview_schd);
        }

        // GET: Interview_schd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interview_schd interview_schd = db.Interview_schd.Find(id);
            if (interview_schd == null)
            {
                return HttpNotFound();
            }
            return View(interview_schd);
        }

        // POST: Interview_schd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Interview_schd interview_schd = db.Interview_schd.Find(id);
            db.Interview_schd.Remove(interview_schd);
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
