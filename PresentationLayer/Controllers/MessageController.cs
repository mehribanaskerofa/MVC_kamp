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

namespace PresentationLayer.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager Mm = new MessageManager(new EFMessageDal());
        MessageValidator Mv = new MessageValidator();
        Message message = new Message();

      // [Authorize(Roles ="A")]
        public ActionResult Inbox()
        {
            var messagelistin = Mm.GetListInbox();
            return View(messagelistin);
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
            message.Read = true;
            Mm.MessageUpdate(message);
            var values = Mm.GetByID(id);
            return View(values);
        }

       // [Authorize(Roles="A")]
        public ActionResult Sendbox()
        {
            var messagelistsend = Mm.GetListSendbox();
            return View(messagelistsend);
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
            if (results.IsValid)
            {
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