using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace theme.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult department()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult Single_blog()
        {
            return View();
            
        }
        public ActionResult Elements()
        {
            return View();
        }
        public ActionResult Job_listing()
        {
            return View();
        }
        public ActionResult Job_details()
        {
            return View();
        }
    }
}