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
    public class HRsController : Controller
    {
        private OnlineRecuriment_dbEntities db = new OnlineRecuriment_dbEntities();

        // GET: HRs
        public ActionResult Index()
        {
            return View(db.HR.ToList());
        }

        // GET: HRs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HR hR = db.HR.Find(id);
            if (hR == null)
            {
                return HttpNotFound();
            }
            return View(hR);
        }

        // GET: HRs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HRs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Passwod")] HR hR)
        {
            if (ModelState.IsValid)
            {
                hR.Super_User = false;
                db.HR.Add(hR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hR);
        }

        // GET: HRs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HR hR = db.HR.Find(id);
            if (hR == null)
            {
                return HttpNotFound();
            }
            return View(hR);
        }

        // POST: HRs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Passwod")] HR hR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hR);
        }

        // GET: HRs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HR hR = db.HR.Find(id);
            if (hR == null)
            {
                return HttpNotFound();
            }
            return View(hR);
        }

        // POST: HRs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HR hR = db.HR.Find(id);
            db.HR.Remove(hR);
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
