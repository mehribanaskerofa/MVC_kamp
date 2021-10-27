using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context _context = new Context();
        ContactManager Cm = new ContactManager(new EFContactDal());
        MessageManager Mm = new MessageManager(new EFMessageDal());
        ContactValidator Cv = new ContactValidator();

        public ActionResult Index()
        {
            var contactvalues = Cm.GetListBL();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalue = Cm.GetByIDBL(id);
            return View(contactvalue);
        }

        public PartialViewResult MessageListMenu()
        {
            //ViewBag.contactCount = Cm.GetListBL().Count;
            //var inbox= Mm.GetListInbox();
            //ViewBag.sendboxCount = Mm.GetListSendbox().Count;

            //return PartialView(inbox);
            string p = (string)Session["WriterMail"];
            var writeridinfo = _context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            var receiverMail = _context.Messages.Count(m => m.ReceiverMail == p).ToString();
            ViewBag.receiverMail = receiverMail;

            var senderMail = _context.Messages.Count(m => m.SenderMail == p).ToString();
            ViewBag.senderMail = senderMail;

            var contact = _context.Contacts.Count().ToString();
            ViewBag.contact = contact;

            //var draft = _context.Drafts.Count().ToString();
            //ViewBag.draft = draft;

            var readMessage = _context.Messages.Count(m=>m.Read==true);
            ViewBag.readMessage = readMessage;

            var unReadMessage = _context.Messages.Count(m => m.Read == false);
            ViewBag.unReadMessage = unReadMessage;

            return PartialView();
        }



    }
}