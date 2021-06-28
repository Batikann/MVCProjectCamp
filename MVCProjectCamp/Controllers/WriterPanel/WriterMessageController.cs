using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers.WriterPanel
{
    public class WriterMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
           string p = (string)Session["WriterMail"]; 
            var messageList = messageManager.GetListInbox(p);
            return View(messageList);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messageSendList = messageManager.GetListSenbox(p);
            return View(messageSendList);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }
        public ActionResult AddNewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewMessage(Message message, string button)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult validation = messageValidator.Validate(message);
            if (button == "draft")
            {
                validation = messageValidator.Validate(message);
                if (validation.IsValid)
                {
                    message.SenderMail = sender;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.IsDraft = true;
                    messageManager.Add(message);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in validation.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }

            else if (button == "send")
            {
                validation = messageValidator.Validate(message);
                if (validation.IsValid)
                {
                    message.SenderMail = sender;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.IsDraft = false;
                    messageManager.Add(message);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in validation.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }

            }
            return View(message);

        }
    }
}