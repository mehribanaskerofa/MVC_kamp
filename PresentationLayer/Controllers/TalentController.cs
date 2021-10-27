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
    [AllowAnonymous]
    public class TalentController : Controller
    {
        // GET: Talent

        TalentManager TM = new TalentManager(new EFTalentDal());

        public ActionResult Index()
        {
            var talentinfos = TM.GetListBL();
            return View(talentinfos);
        }

        public  ActionResult TalentsCard()
        {
            var talents = TM.GetListBL();
            return View(talents);
        }

        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTalent(Talent talent)
        {
            TM.TalentAddBL(talent);
            return RedirectToAction("TalentsCard");
        }

        [HttpGet]
        public ActionResult UpdateTalent(int id)
        {
            var talent = TM.GetByIDBL(id);
            return View(talent);
        }
        [HttpPost]
        public ActionResult UpdateTalent(Talent talent)
        {
            TM.TalentUpdateBL(talent);
            return RedirectToAction("TalentsCard");
        }

        public ActionResult DeleteTalent(Talent talent)
        {
            TM.TalentDeleteBL(talent);
            return RedirectToAction("TalentsCard");
        }
    }
}