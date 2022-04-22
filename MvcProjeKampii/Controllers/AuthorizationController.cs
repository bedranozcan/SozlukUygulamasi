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
    public class AuthorizationController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        // GET: Authorization
        public ActionResult Index()
        {
            var adminvalues = am.GetList();
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            am.AdminAddBL(p);
            return RedirectToAction("Index");
        }


    }
}