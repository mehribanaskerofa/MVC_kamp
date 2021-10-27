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
    [AllowAnonymous]
    public class HomeController : Controller
    {
        
        ContactManager cM=new ContactManager(new EFContactDal());
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        MessageManager messageManager = new MessageManager(new EFMessageDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult HomePage()
        {
            ViewBag.headingCount = headingManager.GetListBL().Count;
            ViewBag.contactCount = cM.GetListBL().Count;
            ViewBag.writerCount = writerManager.GetList().Count;
            ViewBag.messageCount = messageManager.GetAllMessage().Count;
            ViewBag.ImageWriterPath = writerManager.GetByID(1).WriterImage;
            return View();
        }

        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(Contact contact)
        {
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            cM.ContactAddBL(contact);
            return RedirectToAction("HomePage", "Home");
        }
    }
}