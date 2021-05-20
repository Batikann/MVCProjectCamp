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
    public class CategoryController : Controller
    {
        CategoryManager ctm = new CategoryManager(new EfCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var ctvalue = ctm.GetList();
           return View(ctvalue);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {

            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                ctm.Add(p);
                return RedirectToAction("GetCategoryList");
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
            return View();
        }
    }
}