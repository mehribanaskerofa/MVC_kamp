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

namespace PresentationLayer.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager Mm = new MessageManager(new EFMessageDal());
        MessageValidator Mv = new MessageValidator();
        Context c = new Context();

        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
           string p = (string)Session["WriterMail"];         
            var messagelistin = Mm.GetListInbox(p);
            return View(messagelistin);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelistsend = Mm.GetListSendbox(p);
            return View(messagelistsend);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {

            var values = Mm.GetByID(id);
            values.Read = true;
            Mm.MessageUpdate(values);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
          
            var values = Mm.GetByID(id);
            values.Read = true;
            Mm.MessageUpdate(values);
            return View(values);
        }

        public PartialViewResult MessageListMenu()
        {
            Context _context = new Context();
            string p = (string)Session["WriterMail"];
            var writeridinfo = _context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();


            var receiverMail = _context.Messages.Count(m => m.ReceiverMail == p).ToString();
            ViewBag.receiverMail = receiverMail;

            var NoreadMail = _context.Messages.Count(m => m.Read==false).ToString();
            ViewBag.NoreadMail = NoreadMail;

            var senderMail = _context.Messages.Count(m => m.SenderMail == p).ToString();
            ViewBag.senderMail = senderMail;

            //var draft = _context.Drafts.Count().ToString();
            //ViewBag.draft = draft;
            return PartialView();
        }

        [HttpGet]
        public ActionResult AddNewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewMessage(Message message)
        {
            ValidationResult results = Mv.Validate(message);
            string sender = (string)Session["WriterMail"];

            if (results.IsValid)
            {
                message.SenderMail = sender;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                Mm.MessageAddBL(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }
    }
}