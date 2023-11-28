using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theme.Models;

namespace theme.Controllers
{
    public class AdminController : Controller
    {
        OnlineRecuriment_dbEntities db = new OnlineRecuriment_dbEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
   
      
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(HR h)
        {
            var record = db.HR.Where(a => a.Email == h.Email && a.Passwod == h.Passwod).FirstOrDefault();
            if(record != null)
            {
                Session["id"] = record.Id;
                Session["name"] = record.Name;
                Session["email"] = record.Email;
                Session["status"] = record.Super_User;


                return Redirect("Index");

            }
            else
            {
                ViewBag.msg = "<script>alert('Invalid Credentials');</script>";
            }
            return View();
        }
        public ActionResult logout()
        {
            Session.Abandon();
                return RedirectToAction("login", "admin");
        }

        public ActionResult Edit()
        {
            int id = (int)Session["id"];
            var fetch_record = db.HR.Where(a => a.Id == id).FirstOrDefault();
            return View(fetch_record);
        }
        [HttpPost]
        public ActionResult Edit(HR h)
        {
            db.Entry(h).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("index");
        }

    }
}