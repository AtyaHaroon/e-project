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
    public class ResultsController : Controller
    {
        private OnlineRecuriment_dbEntities db = new OnlineRecuriment_dbEntities();

        // GET: Results
        public ActionResult Index()
        {
            var result = db.Result.Include(r => r.applicant).Include(r => r.Interview_schd);
            return View(result.ToList());
        }

        // GET: Results/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Result.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: Results/Create
        public ActionResult Create()
        {
            ViewBag.Apli_id = new SelectList(db.applicant, "Id", "Name");
            ViewBag.Intsh_id = new SelectList(db.Interview_schd, "Id", "Id");
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Status,Intsh_id,Apli_id")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Result.Add(result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Apli_id = new SelectList(db.applicant, "Id", "Name", result.Apli_id);
            ViewBag.Intsh_id = new SelectList(db.Interview_schd, "Id", "Id", result.Intsh_id);
            return View(result);
        }

        // GET: Results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Result.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            ViewBag.Apli_id = new SelectList(db.applicant, "Id", "Name", result.Apli_id);
            ViewBag.Intsh_id = new SelectList(db.Interview_schd, "Id", "Id", result.Intsh_id);
            return View(result);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Status,Intsh_id,Apli_id")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Apli_id = new SelectList(db.applicant, "Id", "Name", result.Apli_id);
            ViewBag.Intsh_id = new SelectList(db.Interview_schd, "Id", "Id", result.Intsh_id);
            return View(result);
        }

        // GET: Results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Result.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Result result = db.Result.Find(id);
            db.Result.Remove(result);
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
