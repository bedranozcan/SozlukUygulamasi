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

namespace MvcProjeKampii.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        

        [Authorize]
        public ActionResult Inbox(int? page)
        {
            string session = (string)Session["AdminMail"];
            var messagelist = mm.GetListInbox(session);
            return View(messagelist);
        }
        public ActionResult Sendbox(int? page)
        {
            string session = (string)Session["AdminMail"];
            var messagelist = mm.GetListSendbox(session);
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);

        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);

        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p,string menuName)
        {
            string session = (string)Session["AdminMail"];
            ValidationResult results = messagevalidator.Validate(p);
            if (menuName == "send")
            {
                if (results.IsValid)
                {
                    p.SenderMail = session; //admin
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAdd(p);
                    return RedirectToAction("SendBox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage); 
                    }
                }
            }
            else if(menuName == "draft")
            {
                if (results.IsValid)
                {
                    p.SenderMail = session;
                    p.IsDraft = true;
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAdd(p);
                    return RedirectToAction("DraftMessages");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (menuName == "cancel")
            {
                return RedirectToAction("NewMessage");
            }
            return View();

        }
        public ActionResult DeleteMessage(int id)
        {
            var result = mm.GetByID(id);
            if (result.Trash == true)
            {
                result.Trash = false;
            }
            else
            {
                result.Trash = true;
            }
            mm.MessageDelete(result);
            return RedirectToAction("Inbox");
        }
        public ActionResult DraftMessages()
        {
            string session = (string)Session["AdminMail"];
            var result = mm.IsDraft(session);
            return View(result);
        }
        public ActionResult GetDraftDetails(int id)
        {
            var result = mm.GetByID(id);
            return View(result);
        }
        public ActionResult IsRead(int id) 
        {
            var messageValue = mm.GetByID(id);

            if (messageValue.IsRead)
            {
                messageValue.IsRead = false;
            }
            else
            {
                messageValue.IsRead = true;
            }

            mm.MessageUpdate(messageValue);
            return RedirectToAction("Inbox");
        }
        public ActionResult IsImportant(int id)
        {
            var messageValue = mm.GetByID(id);

            if (messageValue.IsImportant)
            {
                messageValue.IsImportant = false;
            }
            else
            {
                messageValue.IsImportant = true;
            }

            mm.MessageUpdate(messageValue);
            return RedirectToAction("Inbox");
        }
    }
}