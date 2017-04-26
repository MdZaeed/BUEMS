using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BUEMS.Controllers
{
    public class SalaryGenController : Controller
    {
        // GET: SalaryGen
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Individal(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }

        public ActionResult All()
        {
            return View();
        }

        public ActionResult Salaries()
        {
            return View();
        }

        public ActionResult Salary()
        {
            return View();
        }
    }
}