using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
            ViewBag.contactCount = Cm.GetListBL().Count;
            var inbox= Mm.GetListInbox();
            ViewBag.sendboxCount = Mm.GetListSendbox().Count;
  
            return PartialView(inbox);
        }



    }
}