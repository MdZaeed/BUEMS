using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUEMS.Models;
using Microsoft.Ajax.Utilities;

namespace BUEMS.Controllers
{
    public class HomeController : Controller
    {
        static BUEMSDbContext _db = new BUEMSDbContext();

        public ActionResult Index()
        {
            if(User.IsInRole("Teacher"))
            {
                return RedirectToAction("GetSalaryByUser","Salaries");
            }
            return View();
        }

        public void Base()
        {
            var title = _db.Titles.ToList();
            ViewBag.TitlesCom = title;

            var category = _db.Titles.Select(i => i.Category).Distinct();
            ViewBag.CategoriesCom = category;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}