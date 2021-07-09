using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MVCProjectCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers.AdminPanel
{
    [AllowAnonymous]
    public class CalenderController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        public ActionResult Index()
        {
            return View(new Calender());
        }

        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var viewModel = new Calender();
            var events = new List<Calender>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-14);
            foreach (var item in headingManager.GetList())
            {
                events.Add(new Calender()
                {
                    title = item.HeadingName,
                    start = item.HeadingDate,
                    end = item.HeadingDate.AddDays(-14),
                    allDay = false
                });
                start = start.AddDays(7);
                end = end.AddDays(7);
            }
            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}