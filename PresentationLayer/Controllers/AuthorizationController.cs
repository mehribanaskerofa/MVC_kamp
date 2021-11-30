using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adminManager = new AdminManager(new EFAdminDal());
        
        public ActionResult Index()
        {
            var adminvalues = adminManager.GetListBL();
            return View(adminvalues);
        }
        
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = admin.AdminPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            admin.AdminPassword = result;
            admin.AdminStatus = true;
            adminManager.AdminAddBL(admin);
            return RedirectToAction("Index");
        }

        //  dropdown ele tapsiriq update ve add
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var adminvalues = adminManager.GetByIDBL(id);
            return View(adminvalues);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            adminManager.AdminUpdateBL(admin);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var Adminvalue = adminManager.GetByIDBL(id);
            Adminvalue.AdminStatus = false;
            adminManager.AdminUpdateBL(Adminvalue);
            return RedirectToAction("Index");
        }

    }
}