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
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            var messageList = messageManager.GetList();
            return View(messageList);
        }

        public ActionResult Sendbox(string p)
        {
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
            ValidationResult validation = messageValidator.Validate(message);
            if (button == "draft")
            {
                validation = messageValidator.Validate(message);
                if (validation.IsValid)
                {
                    message.SenderMail = "admin@gmail.com";
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
           
            else if (button=="send")
            {
                validation = messageValidator.Validate(message);
                if (validation.IsValid)
                {
                    message.SenderMail = "admin@gmail.com";
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

        public ActionResult Draft()
        {
            var draftList = messageManager.GetDraftBox();
            return View(draftList);
        }
        public ActionResult GetDraftMessageDetails(int id)
        {
            var draftMessage = messageManager.GetById(id);
            return View(draftMessage);
        }

        public ActionResult IsRead(int id)
        {
            var message = messageManager.GetById(id);
            if (message.IsRead==false)
            {
                message.IsRead = true;
                messageManager.Update(message);
            }
            return RedirectToAction("Inbox");
        }
    }
}