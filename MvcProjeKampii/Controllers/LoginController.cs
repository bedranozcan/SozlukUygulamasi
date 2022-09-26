using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampii.Controllers
{
    public class LoginController : Controller

    {
      

        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
        //WriterLoginManager wm = new WriterLoginManager(new EfWriterDal());

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogIn(AdminLogInDto adminLogInDto)
        {
            //var response = Request["g-recaptcha-response"];
            //const string secret = "6Lc9zzgbAAAAAFBGD3Gb201yvNAX4Tb5LAzlqy0d";
            //var client = new WebClient();
            //var reply =
            //    client.DownloadString(
            //        string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            //var captchaResponse = JsonConvert.DeserializeObject<CaptchaResult>(reply);

            if (authService.AdminLogIn(adminLogInDto))
            {
                FormsAuthentication.SetAuthCookie(adminLogInDto.AdminMail, false);
                Session["AdminMail"] = adminLogInDto.AdminMail;
                var session = Session["AdminMail"];
                ViewBag.a = session;
                return RedirectToAction("Index", "Heading");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return RedirectToAction("AdminLogin");
            }

        }
        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "LogIn");
        }


































        //    [HttpGet]
        // public ActionResult Index()
        //    {
        //        return View();
        //    }
        //    [HttpPost]
        //    public ActionResult Index(Admin p)
        //    {
        //        Context c = new Context();
        //        var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName
        //        && x.AdminPassword==p.AdminPassword);
        //        if (adminuserinfo != null)
        //        {
        //            FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);
        //            Session["AdminUserName"] = adminuserinfo.AdminUserName;
        //            return RedirectToAction("Index","AdminCategory");
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        return View();
        //    }
        //}
    }
}