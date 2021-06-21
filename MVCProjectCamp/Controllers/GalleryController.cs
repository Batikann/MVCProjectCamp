using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager fileManager = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var results = fileManager.GetList();
            return View(results);
        }
    }
}