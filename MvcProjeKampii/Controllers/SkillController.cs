using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class SkillController : Controller
    {
        SkillManager sm = new SkillManager(new EfSkillDal());

        // GET: Skill
        public ActionResult Index()
        {
            var skillvalue = sm.GetList();
            return View(skillvalue);
        }

    }
}