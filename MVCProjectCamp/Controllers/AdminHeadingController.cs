﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class AdminHeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingValues = hm.GetHeadingDetails();
            return View(headingValues);
        }


        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                               ).ToList();
            ViewBag.vlc = valueCategory;


            List<SelectListItem> valueWriter = (from x in wm.GetList()

                                                select new SelectListItem
                                                {
                                                    Text=x.WriterName + " " + x.WriterSurName,
                                                    Value=x.WriterID.ToString()
                                                }
                                             ).ToList();

            ViewBag.vlw = valueWriter;

            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            hm.Add(heading);
            return RedirectToAction("Index");
        }
    }
}