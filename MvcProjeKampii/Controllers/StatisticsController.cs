﻿using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class StatisticsController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Categories.Count().ToString();
            ViewBag.dgr1 = deger1;

            var deger2 = c.Headings.Count(x => x.CategoryID == 1).ToString();
            ViewBag.dgr2 = deger2;

            var deger3 = (from x in c.Writers select x.WriterName.IndexOf("a")).Distinct().Count().ToString();
            ViewBag.dgr3 = deger3;

            var deger4 = c.Categories.Where(u => u.CategoryID == c.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.dgr4 = deger4;

            var deger5 = c.Categories.Count(x => x.CategoryStatus == true) - c.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.dgr5 = deger5;

            var deger6 = c.Writers.Count().ToString();
            ViewBag.dgr6 = deger6;


            return View();
        }
    }
}