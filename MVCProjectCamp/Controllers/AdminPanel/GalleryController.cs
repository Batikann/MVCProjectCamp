using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    [AllowAnonymous]
    public class GalleryController : Controller
    {
        ImageFileManager fileManager = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var results = fileManager.GetList();
            return View(results);
        }

        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(ImageFile imageFile)
        {
            if (Request.Files.Count>0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string expansion = Path.GetExtension(Request.Files[0].FileName);
                string path = "/Images/Gallery/" + fileName + expansion;
                Request.Files[0].SaveAs(Server.MapPath(path));
                imageFile.ImagePath = "/Images/Gallery/" + fileName + expansion;
                fileManager.Add(imageFile);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}