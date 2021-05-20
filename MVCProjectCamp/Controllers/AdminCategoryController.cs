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
    public class AdminCategoryController : Controller
    {
        CategoryManager ctm = new CategoryManager(new EfCategoryDal());
        CategoryValidator categoryValidator = new CategoryValidator();
        // GET: AdminCategory
        public ActionResult Index()
        {
            var val = ctm.GetList();
            return View(val);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                ctm.Add(p);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = ctm.GetById(id);
            ctm.Delete(categoryValue);
            return RedirectToAction("Index");
        }

        public ActionResult EditCategory(int id)
        {
            var categoryvalue = ctm.GetById(id);
            return View(categoryvalue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                ctm.Update(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(category);
        }
    }
}