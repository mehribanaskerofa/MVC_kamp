using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
//using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidatior categoryValidatior = new CategoryValidatior();
            ValidationResult results = categoryValidatior.Validate(category);
            if (results.IsValid)
            {
                cm.CategoryAddBL(category);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
        //    cm.CategoryAddBL(category);
            return View();
        }
    }
}