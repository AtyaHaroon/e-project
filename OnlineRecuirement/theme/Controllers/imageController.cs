using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theme.Models;

namespace theme.Controllers
{
    public class imageController : Controller
    {
        // GET: image
        OnlineRecuriment_dbEntities db = new OnlineRecuriment_dbEntities();
        [HttpPost]
        public ActionResult app_img(applicant app)
        {
            string filename = Path.GetFileNameWithoutExtension(app.apl_img.FileName);
            string fileextension = Path.GetExtension(app.apl_img.FileName);

            string cvname = Path.GetFileNameWithoutExtension(app.apl_cv.FileName);
            string cvextension = Path.GetExtension(app.apl_cv.FileName);

            filename = filename + fileextension;
            cvname = cvname + cvextension;

            app.Image = "~/applicantimage/" + filename;
            app.Cv = "~/applicantcv/" + cvname;

            if (fileextension.ToLower() == ".jpg" || fileextension.ToLower() == ".png" || fileextension.ToLower() == ".jpeg" && (cvextension.ToLower() == ".docx" || cvextension.ToLower() == ".pdf"))
            {
                filename = Path.Combine(Server.MapPath("~/applicantimage/"), filename);
                cvname = Path.Combine(Server.MapPath("~/applicantcv/"), cvname);

                app.apl_img.SaveAs(filename);
                app.apl_cv.SaveAs(cvname);

                if (ModelState.IsValid)
                {
                    var record = db.applicant.Where(a => a.Email == app.Email).FirstOrDefault();
                    if (record != null)
                    {
                        Session["appli_msg"] = "<Script>alert('Email Already exists');</Script>";
                        return RedirectToAction("Create", "applicants");
                    }
                    else
                    {
                        db.applicant.Add(app);
                        db.SaveChanges();
                        ModelState.Clear();
                    }
                }
            }
            else
            {
                Session["ext_msg"] = "<Script>alert('Invalid Extension');</Script>";
            }
            return RedirectToAction("Create", "applicants");

        }
        public ActionResult vac_img(Vacancy vac)
        {
            string filename = Path.GetFileNameWithoutExtension(vac.vacimg.FileName);
            string fileextension = Path.GetExtension(vac.vacimg.FileName);
            filename = filename + fileextension;
            vac.Image = "~/vacimage/" + filename;

            if (fileextension.ToLower() == ".jpg" || fileextension.ToLower() == ".png" || fileextension.ToLower() == ".jpeg" )
            {
                filename = Path.Combine(Server.MapPath("~/vacimage/"), filename);
             

                vac.vacimg.SaveAs(filename);
           

                if (ModelState.IsValid)
                {
                    db.Vacancy.Add(vac);
                    db.SaveChanges();
                    ModelState.Clear();
                }
            }
            else
            {
                Session["ext_msg"] = "<Script>alert('Invalid Extension');</Script>";
            }
            return RedirectToAction("Create", "vacancies");

        }
    }
    }
