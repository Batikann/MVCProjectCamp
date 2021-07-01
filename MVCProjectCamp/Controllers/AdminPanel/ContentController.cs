using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetAllContent(string p)
        {
            var values = contentManager.SearchText(p);
            return View(values.ToList());
        }



        public ActionResult ContentByHeading(int id)
        {
            var result = contentManager.GetListByHeadingId(id);
            return View(result);
        }
    }
}