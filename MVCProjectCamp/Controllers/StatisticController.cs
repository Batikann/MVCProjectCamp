using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class StatisticController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var categoryCaount= c.Categories.Count().ToString();
            var heading = c.Headings.Where(x => x.Category.CategoryID == 12).Count().ToString();
            var writer = c.Writers.Where(x => x.WriterName.Contains("a") || x.WriterName.Contains("A")).Count().ToString();
            var topHeading = (from x in c.Headings orderby x.CategoryID ascending select x.Category.CategoryName).FirstOrDefault();
            var val = (c.Categories.Where(x => x.CategoryStatus == true).Count() - c.Categories.Where(x => x.CategoryStatus == false).Count()).ToString();
            ViewBag.dgr1 = categoryCaount;
            ViewBag.dgr2 = heading;
            ViewBag.dgr3 = writer;
            ViewBag.dgr4 = topHeading;
            ViewBag.dgr5 = val;
            return View();

        }
    }
}