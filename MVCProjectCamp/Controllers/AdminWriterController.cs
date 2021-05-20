using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class AdminWriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        public ActionResult Index()
        {
            var writerList = wm.GetList();
            return View(writerList);
        }

        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                wm.Add(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(writer);

        }

        public ActionResult EditWriter(int id)
        {
            var writerValue = wm.GetById(id);
            return View(writerValue);

        }

        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                wm.Update(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(writer);
        }
    }
}