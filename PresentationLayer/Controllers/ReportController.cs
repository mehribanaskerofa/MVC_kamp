using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class ReportController : Controller
    {
        MessageManager mM = new MessageManager(new EFMessageDal());
        // GET: Report
        public ActionResult MessageReport()
        {
            var values = mM.GetAllMessage();
            return View(values);
        }
    }
}