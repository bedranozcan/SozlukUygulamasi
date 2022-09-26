using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampii.Controllers
{
    public class Login1Controller : Controller
    {
        // GET: Login1
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin1 p)
        {
            Context c = new Context();
            var adminuserinfo = c.Admins1.FirstOrDefault(x=>x.AdminUserName==p.AdminUserName
            && x.AdminPassword==p.AdminPassword);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            Context c = new Context();
            var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail
            && x.WriterPassword == p.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
              return  RedirectToAction("WriterLogin");
            }
           
          
        }
    }
}