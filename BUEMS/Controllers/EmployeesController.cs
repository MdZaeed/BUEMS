﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BUEMS.Models;
using BUEMS.CustomFilters;

namespace BUEMS.Controllers
{
    public class EmployeesController : Controller
    {
        private BUEMSDbContext db = new BUEMSDbContext();

        // GET: Employees
        [AuthLog(Roles = "VC,Treasurer,Acountant")]
        public ActionResult QuickFixIndex(string cat)
        {
            if (cat.Equals("") || cat.Equals("সকল"))
            {
                return View(db.Employees.ToList());
            }else
            {
                return View(db.Employees.Where(i => i.Podobi.Equals(cat)).ToList());
            }
        }

        public ActionResult Index()
        {
            return RedirectToAction("QuickFixIndex",new { cat = "সকল"});
        }

        public ActionResult GetEmployeesByDepartment(string dep)
        {
            if (dep.Equals("") || dep.Equals("সকল"))
            {
                return View(db.Employees.ToList());
            }
            else
            {
                return View(db.Employees.Where(i => i.Department.Equals(dep)).ToList());
            }
        }
    

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [AuthLog(Roles = "Acountant")]
        public ActionResult Create()
        {
            var grades = db.Grades.ToList();
            ViewBag.Grades = grades;

            var titles = db.Titles.ToList();
            ViewBag.Titles = titles;

            var categories = db.Titles.Select(i => i.Category).Distinct().ToList();
            ViewBag.Categories = categories;

            var departments = db.Departments.ToList();
            ViewBag.Departments = departments;

            Employee employee = new Employee(){Salary = 0 , IsTeacher = true};
            return View(employee);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SerialNo,IdNo,FullName,EnglishFullName,Email,Podobi,Salary,Category,Department,JoiningDate,AccountNo,MainSalaryGrade,IncrementNo,Sex,IsFreedomFighter,IsAddiitonalDuties,IsStudentAdviser,IsDean,IsChairman,IsProvost,IsProctor,IsAssistantProctor,HasOwnTransportationMethod,IsTeacher")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var grade = from a in db.Grades
                    where a.GradeRange.Equals(employee.MainSalaryGrade)
                    select a;
                Grade orDefault = grade.FirstOrDefault();
                if (orDefault != null)
                {
                    int grad = orDefault.GradeNo;
                    int increment = Int32.Parse(LanguageConverter.BanglaToEnglish(employee.IncrementNo));
                    var mainsalaryString = from a in db.Taxes
                        where a.Grade.Equals(grad) && a.Scale.Equals(increment)
                        select a;
                    var firstOrDefault = mainsalaryString.FirstOrDefault();
                    if (firstOrDefault != null)
                        employee.Salary = firstOrDefault.MainSalary;
                }
                db.Employees.Add(employee);
                db.SaveChanges();
                var v = new RegisterViewModel
                {
                    FullName = employee.EnglishFullName,
                    Name = "Teacher",
                    Email = employee.Email,
                    Password = "Iit@12345",
                    ConfirmPassword = "Iit@12345"
                };
                var controller=new AccountController();
                controller.RegisterMid(v);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            var grades = db.Grades.ToList();
            ViewBag.Grades = grades;

            var titles = db.Titles.ToList();
            ViewBag.Titles = titles;

            var categories = db.Titles.Select(i => i.Category).Distinct().ToList();
            ViewBag.Categories = categories;

            var departments = db.Departments.ToList();
            ViewBag.Departments = departments;

            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SerialNo,IdNo,FullName,EnglishFullName,Email,Podobi,Salary,Category,Department,JoiningDate,AccountNo,MainSalaryGrade,IncrementNo,Sex,IsFreedomFighter,IsAddiitonalDuties,IsStudentAdviser,IsDean,IsChairman,IsProvost,IsProctor,IsAssistantProctor,HasOwnTransportationMethod,IsTeacher")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var grade = from a in db.Grades
                            where a.GradeRange.Equals(employee.MainSalaryGrade)
                            select a;
                Grade orDefault = grade.FirstOrDefault();
                if (orDefault != null)
                {
                    int grad = orDefault.GradeNo;
                    int increment = Int32.Parse(LanguageConverter.BanglaToEnglish(employee.IncrementNo));
                    var mainsalaryString = from a in db.Taxes
                                           where a.Grade.Equals(grad) && a.Scale.Equals(increment)
                                           select a;
                    var firstOrDefault = mainsalaryString.FirstOrDefault();
                    if (firstOrDefault != null)
                        employee.Salary = firstOrDefault.MainSalary;
                }
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
