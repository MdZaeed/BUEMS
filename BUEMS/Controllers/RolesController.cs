using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUEMS.CustomFilters;
using BUEMS.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BUEMS.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public RolesController()
        {
            _dbContext=new ApplicationDbContext();
        }
        // GET: Roles
        [AuthLog(Roles = "Teacher")]
        public ActionResult Index()
        {
            return View(_dbContext.Roles.ToList());
        }

        public ActionResult Create()
        {
            var role = new IdentityRole();
            return View(role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            _dbContext.Roles.Add(role);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");   
        }

    }
}