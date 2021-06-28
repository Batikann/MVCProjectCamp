using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class AdminContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contectValidator = new ContactValidator();
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            var contactValues = contactManager.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var getByContactDetails = contactManager.GetById(id);
            return View(getByContactDetails);
        }

        public PartialViewResult InboxDetails(string p)
        {
            var contactMessage = contactManager.GetList().Count();
            ViewBag.contactMessage = contactMessage;

            var sendMail = messageManager.GetListSenbox(p).Count();
            ViewBag.sendMail = sendMail;

            var recevierMail = messageManager.GetList().Count();
            ViewBag.recevierMail = recevierMail;

            var draftMail = messageManager.GetDraftBox().Count();
            ViewBag.draftMail = draftMail;

            var unreadMessage = messageManager.GetList().Where(x => x.IsRead == false).Count();
            ViewBag.unreadMessage = unreadMessage;

            return PartialView();
        }
    }
}