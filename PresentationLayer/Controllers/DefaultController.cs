using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm=new ContentManager(new EFContentDal());

        public ActionResult Headings()
        {
            var values = hm.GetListBL();
            return View(values);
        }

        public PartialViewResult Index(int id=0)
        {
            var valuescontent = cm.GetListByHeadingIDBL(id);
            return PartialView(valuescontent);
        }
    }
}