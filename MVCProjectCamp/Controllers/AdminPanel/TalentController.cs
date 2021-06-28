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
    public class TalentController : Controller
    {
        TalentManager talentManager = new TalentManager(new EfTalentDal());
        TalentValidator talentValidator = new TalentValidator();
        public ActionResult Index()
        {
            var talents = talentManager.GetList();
            return View(talents);
        }

        public ActionResult TalentList()
        {
            var talents = talentManager.GetList();
            return View(talents);
        }

        public ActionResult AddTalent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTalent(Talent talent)
        {
            ValidationResult validationResult = talentValidator.Validate(talent);
            if (validationResult.IsValid)
            {
                talentManager.Add(talent);
                return RedirectToAction("TalentList");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(talent);
        }

    }
}