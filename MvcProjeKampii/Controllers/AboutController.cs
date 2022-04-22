using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class AboutController : Controller
    {

        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {

            return PartialView();
        }
        public ActionResult IsActive(int id)
        {
            var aboutValue = abm.GetByID(id);
            if (aboutValue.Status)
            {
                aboutValue.Status = false;
            }
            else
            {
                aboutValue.Status = true;
            }
            abm.AboutUpdate(aboutValue);
            return RedirectToAction("Index");
        }
    }
}