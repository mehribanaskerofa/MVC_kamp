using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager ifM = new ImageFileManager(new EFImageFileDal());
        public ActionResult Index()
        {
            var files = ifM.GetListBL();
            return View(files);
        }
    }
}