using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PresentationLayer.Controllers
{
    public class LoginController : Controller
    {

        LoginManager lM = new LoginManager(new EFLoginDal());
        WriterManager WM = new WriterManager(new EFWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = admin.AdminPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            admin.AdminPassword = result;

            //var loginvalues = lM.GetListBL();
            //var login = loginvalues.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            var AdminUserinfo = lM.GetAdmin(admin.AdminUserName, admin.AdminPassword);

            if (AdminUserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(AdminUserinfo.AdminUserName, false);
                Session["AdminUserName"] = AdminUserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            ViewBag.ErrorMessage = "İstifadəçi Adı vəya Şifrə səfdir!";
            return View();          
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var response = Request["g-recaptcha-response"];
            const string secret = "6LfHFTwbAAAAAB53V5ZcixAgVCi2aTXIuF-eLxF9";
            var client = new WebClient();

            var reply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);
            if (!captchaResponse.Success)
            {
                ViewBag.ErrorMessage = "İstifadəçi Adı vəya Şifrəniz səfdir!";
                return View();
            }


            //Context c = new Context();
            //var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            var writeruserinfo = WM.GetWriter(writer.WriterMail, writer.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
        public class CaptchaResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("error-codes")]
            public List<string> ErrorCodes { get; set; }
        }


    }
}