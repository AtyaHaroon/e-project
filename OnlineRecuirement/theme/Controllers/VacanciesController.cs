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
    public class VacanciesController : Controller
    {
        private OnlineRecuriment_dbEntities db = new OnlineRecuriment_dbEntities();

        // GET: Vacancies
        public ActionResult Index()
        {
            var vacancy = db.Vacancy.Include(v => v.Department).Include(v => v.Designation).Include(v => v.HR);
            return View(vacancy.ToList());
        }

        // GET: Vacancies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = db.Vacancy.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        // GET: Vacancies/Create
        public ActionResult Create()
        {
            ViewBag.Dept_id = new SelectList(db.Department, "Id", "Name");
            ViewBag.Desig_id = new SelectList(db.Designation, "Id", "Name");
            ViewBag.Hr_id = new SelectList(db.HR, "Id", "Name");
            return View();
        }

        // POST: Vacancies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Salary,Description,Status,Hr_id,Desig_id,Dept_id,Image")] Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                db.Vacancy.Add(vacancy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dept_id = new SelectList(db.Department, "Id", "Name", vacancy.Dept_id);
            ViewBag.Desig_id = new SelectList(db.Designation, "Id", "Name", vacancy.Desig_id);
            ViewBag.Hr_id = new SelectList(db.HR, "Id", "Name", vacancy.Hr_id);
            return View(vacancy);
        }

        // GET: Vacancies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = db.Vacancy.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dept_id = new SelectList(db.Department, "Id", "Name", vacancy.Dept_id);
            ViewBag.Desig_id = new SelectList(db.Designation, "Id", "Name", vacancy.Desig_id);
            ViewBag.Hr_id = new SelectList(db.HR, "Id", "Name", vacancy.Hr_id);
            return View(vacancy);
        }

        // POST: Vacancies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Salary,Description,Status,Hr_id,Desig_id,Dept_id,Image")] Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacancy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dept_id = new SelectList(db.Department, "Id", "Name", vacancy.Dept_id);
            ViewBag.Desig_id = new SelectList(db.Designation, "Id", "Name", vacancy.Desig_id);
            ViewBag.Hr_id = new SelectList(db.HR, "Id", "Name", vacancy.Hr_id);
            return View(vacancy);
        }

        // GET: Vacancies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = db.Vacancy.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        // POST: Vacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacancy vacancy = db.Vacancy.Find(id);
            db.Vacancy.Remove(vacancy);
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
