using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager aboutm = new AboutManager(new EFAboutDal());

        public ActionResult Index()
        {
            var aboutvalues = aboutm.GetListBL();
            return View(aboutvalues);
        }


        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutm.AboutAddBL(about);
            return RedirectToAction("Index");
        }


        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }


        public ActionResult AktivPassivStatus(int id)
        {
            var aboutValue = aboutm.GetByIDBL(id);

            if (aboutValue.AboutStatus == true)
            {
                aboutValue.AboutStatus = false;
            }
            else
            {
                aboutValue.AboutStatus = true;
            }
            aboutm.AboutUpdateBL(aboutValue);
            return RedirectToAction("Index");
        }
    }
}