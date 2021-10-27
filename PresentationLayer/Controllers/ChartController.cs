using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart

        WriterManager wM = new WriterManager(new EFWriterDal());
        ContentManager cM = new ContentManager(new EFContentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WriterContent()
        {
            return View();
        }
        public ActionResult WriterHeading()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult WriterContentChart()
        {
            return Json(ContentList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult WriterHeadingChart()
        {
            return Json(HeadingList(),JsonRequestBehavior.AllowGet);
        }
        public List<ClassChart> BlogList()
        {
            List<ClassChart> categoryClasses = new List<ClassChart>();
            categoryClasses.Add(new ClassChart()
            {
                Name = "Yazılım",
                Count = 8
            });
            categoryClasses.Add(new ClassChart()
            {
                Name = "Səyahət",
                Count = 7
            });
            categoryClasses.Add(new ClassChart()
            {
                Name = "Texnoloji",
                Count = 5
            });
            categoryClasses.Add(new ClassChart()
            {
                Name = "Sport",
                Count = 4
            });
            return categoryClasses;
        }
        public List<ClassChart> ContentList()
        {
            List<ClassChart> values = new List<ClassChart>();
            Context c = new Context();
            values = c.Writers.Select(x => new ClassChart
            {
                Name = x.WriterName,
                Count = x.Contents.Count
            }).ToList();
              
            
            return values;
        }
        public List<ClassChart> HeadingList()
        {
            List<ClassChart> values = new List<ClassChart>();
            Context c = new Context();
            values = c.Writers.Select(x => new ClassChart
            {
                Name = x.WriterName,
                Count = x.Headings.Count
            }).ToList();

            return values;
        }
    }
}