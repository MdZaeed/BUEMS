using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BUEMS.Models;

namespace BUEMS.Controllers
{
    public class SalaryHisController : Controller
    {
        private BUEMSDbContext db = new BUEMSDbContext();

        // GET: SalaryHis
        public ActionResult Index()
        {
            MailModel mail=new MailModel
            {
                Body = "hjaw",
                From = "tz2201@gmail.com",
                Subject = "maw",
                To = "bsse0504@iit.du.ac.bd"
            };
            MailSending.SendMail(mail);
            return View(db.SalaryHises.ToList());
        }

        // GET: SalaryHis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryHis salaryHis = db.SalaryHises.Find(id);
            if (salaryHis == null)
            {
                return HttpNotFound();
            }
            return View(salaryHis);
        }

        // GET: SalaryHis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalaryHis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SerialNo,Data")] SalaryHis salaryHis)
        {
            if (ModelState.IsValid)
            {
                db.SalaryHises.Add(salaryHis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salaryHis);
        }

        // GET: SalaryHis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryHis salaryHis = db.SalaryHises.Find(id);
            if (salaryHis == null)
            {
                return HttpNotFound();
            }
            return View(salaryHis);
        }

        // POST: SalaryHis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SerialNo,Data")] SalaryHis salaryHis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salaryHis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salaryHis);
        }

        // GET: SalaryHis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryHis salaryHis = db.SalaryHises.Find(id);
            if (salaryHis == null)
            {
                return HttpNotFound();
            }
            return View(salaryHis);
        }

        // POST: SalaryHis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalaryHis salaryHis = db.SalaryHises.Find(id);
            db.SalaryHises.Remove(salaryHis);
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
