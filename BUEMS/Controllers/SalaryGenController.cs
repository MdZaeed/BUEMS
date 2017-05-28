using BUEMS.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BUEMS.Models;

namespace BUEMS.Controllers
{
    public class SalaryGenController : Controller
    {


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

        //[AuthLog(Roles = "VC,Treasurer,Accoutant")]
        public ActionResult Salaries()
        {
            return View();
        }

        //[AuthLog(Roles = "VC,Treasurer,Accoutant")]
        public ActionResult Salary()
        {
            return View();
        }
    }
}