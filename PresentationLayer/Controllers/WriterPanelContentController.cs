using BusinessLayer.Concrete;
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
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EFContentDal());
        int writerIDinfo;
        Context c = new Context();

        public ActionResult MyContent(string p)
        {
            
            //int id;
            p = (string)Session["WriterMail"];
            //ViewBag.d = p;
            writerIDinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentvalues = cm.GetListByWriterBL(writerIDinfo);
            return View(contentvalues);
        }

        [HttpGet]
        public ActionResult AddContent(int Hid)
        {
            ViewBag.HID = Hid;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            writerIDinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            content.WriterID = writerIDinfo;
            content.ContentDate = DateTime.Parse( DateTime.Now.ToShortDateString());
            content.ContentStatus = true;
            cm.ContentAddBL(content);
            return RedirectToAction("MyContent");
        }



    }
}