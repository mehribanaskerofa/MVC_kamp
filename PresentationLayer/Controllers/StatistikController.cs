using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class StatistikController : Controller
    {
        // GET: Statistik
        Context _context = new Context();
        public ActionResult Index()
        {
            var ALLKategory = _context.Categories.Count(); //Toplam Kategori Sayisi
            ViewBag.ALLKategory = ALLKategory;

            var YazılımKategorisi = _context.Headings.Count(x => x.CategoryID == 8); // Yazilim Kategorisi id 8, başlik sayisi
            ViewBag.YazılKatBasNum = YazılımKategorisi;

            var SertliYazarAdı = _context.Writers.Count(x => x.WriterName.Contains("a")); // Yazar adinda "a" harfi gecen yazar sayisi
            ViewBag.SertliYazarAdı = SertliYazarAdı;

            var EnCoxBasliq = _context.Headings.Where(y => y.CategoryID == _context.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault()).Select(x => x.Category.CategoryName).FirstOrDefault(); // En fazla basliga sahip kategori adi
            ViewBag.EnCoxBasliq = EnCoxBasliq;

            var DurumuTrueOlanKategoriler = _context.Categories.Count(x => x.CategoryStatus == true); // Kategoriler tablosundaki aktif kategori sayisi
            ViewBag.AktivKategories = DurumuTrueOlanKategoriler;

            return View();
        }
    }
}