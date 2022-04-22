using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        MessageManager mm = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
          
        }
        public PartialViewResult MessageListMenu()
        {
            string session = (string)Session["AdminMail"];
            var contact = cm.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = mm.GetListSendbox(session).Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = mm.GetListInbox(session).Count();
            ViewBag.receiverMail = receiverMail;

            var draftMail = mm.GetListDraft(session).Count();
            ViewBag.draftMail = draftMail;

            var trashMail = mm.GetListTrash().Count();
            ViewBag.trashMail = trashMail;

            var readMail = mm.GetReadList(session).Count;
            ViewBag.readMail = readMail;

            var unReadMail = mm.GetUnReadList(session).Count;
            ViewBag.unReadMail = unReadMail;

            var importantMail = mm.GetListImportant(session).Count();
            ViewBag.importantMail = importantMail;

            var spamMail = mm.GetListSpam(session).Count();
            ViewBag.spamMail = spamMail;


            return PartialView();
        }
        public PartialViewResult PartialMessageList()
        {
            return PartialView();
        }
        public PartialViewResult PartialMessageListFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialMessageListFooterButton()
        {
            return PartialView();
        }
        public ActionResult IsRead(int id) 
        {
            var contactValue = cm.GetByID(id);

            if (contactValue.IsRead)
            {
                contactValue.IsRead = false;
            }
            else
            {
                contactValue.IsRead = true;
            }

            cm.ContactUpdate(contactValue);
            return RedirectToAction("Index");
        }
        public ActionResult IsImportant(int id) //Bu alan sistem mesajlarindaki önemli butonundan gelen degeri DB yazar
        {
            var contactValue = cm.GetByID(id);

            if (contactValue.IsImportant)
            {
                contactValue.IsImportant = false;
            }
            else
            {
                contactValue.IsImportant = true;
            }

            cm.ContactUpdate(contactValue);
            return RedirectToAction("Index");
        }
    }
}