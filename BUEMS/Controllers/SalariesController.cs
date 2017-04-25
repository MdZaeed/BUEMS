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
    public class SalariesController : Controller
    {
        private BUEMSDbContext db = new BUEMSDbContext();

        // GET: Salaries
        public ActionResult Index()
        {
            List<Salary> salaries = new List<Salary>();
            var employees = db.Employees.ToList();
            foreach (Employee employee in employees)
            {
                Salary salary = MapEmployeeToSalary(employee);
                salaries.Add(salary);
            }
            return View(salaries);
        }


        public ActionResult SalarySheet()
        {
            List<Salary> salaries = new List<Salary>();
            var employees = db.Employees.ToList();
            foreach (Employee employee in employees)
            {
                Salary salary = MapEmployeeToSalary(employee);
                salaries.Add(salary);
            }
            return View(salaries);
        }

        public ActionResult SalarySheetAng()
        {
            List<Salary> salaries = new List<Salary>();
            var employees = db.Employees.ToList();
            foreach (Employee employee in employees)
            {
                Salary salary = MapEmployeeToSalary(employee);
                salaries.Add(salary);
            }
            return Json(salaries, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IndividualSheetData(int id)
        {
            var employee = db.Employees.Find(id);
            Salary salary = MapEmployeeToSalary(employee);
            return Json(salary, JsonRequestBehavior.AllowGet);
        }
        // GET: Salaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = db.Salaries.Find(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // GET: Salaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SerialNo,Name,Title,JoiningDate,MainSalary,PayableMainSalary,HouseRent,MedicalAllowance,CurriculumAssitanceAllowance,AssistantProctorAllowance,DeanORChairmanOrProvostAllowance,AdditionalDutiesOrStudentAdvisorAllowance,ResearchAllowance,TelephoneAllowance,Somonnoy,Total,GPF,BF,TransportationAllowance,IncomeTax,RevenueStamp,TotalSubtraction,NeatSalary")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                db.Salaries.Add(salary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salary);
        }

        // GET: Salaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = db.Salaries.Find(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // POST: Salaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SerialNo,Name,Title,JoiningDate,MainSalary,PayableMainSalary,HouseRent,MedicalAllowance,CurriculumAssitanceAllowance,AssistantProctorAllowance,DeanORChairmanOrProvostAllowance,AdditionalDutiesOrStudentAdvisorAllowance,ResearchAllowance,TelephoneAllowance,Somonnoy,Total,GPF,BF,TransportationAllowance,IncomeTax,RevenueStamp,TotalSubtraction,NeatSalary")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salary);
        }

        // GET: Salaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = db.Salaries.Find(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salary salary = db.Salaries.Find(id);
            db.Salaries.Remove(salary);
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

        public Salary MapEmployeeToSalary(Employee employee)
        {
            Salary salary = new Salary
            {
                SerialNo = employee.SerialNo,
                AdditionalDutiesAllowance = SalaryGenrationHelper.GetAdditionalDutiesAllowance(employee.IsAddiitonalDuties) + SalaryGenrationHelper.GetStudentAdvisorAllowance(employee.IsStudentAdviser),
                AssistantProctorAllowance = SalaryGenrationHelper.GetProctorAssistanceBill(employee.IsAssistantProctor),
                AccountNo = employee.AccountNo,
                BF = SalaryGenrationHelper.GetBf(employee.Salary, employee.Category),
                CurriculumAssitanceAllowance = SalaryGenrationHelper.GetCurriculumAssistanceBill(),
                //                DeanORChairmanOrProvostAllowance = getDeanAllowance(employee.IsDean) + getChairmanAllowance(employee.IsChairman) + getProvostAllowance(employee.IsProvost),
                DeanAllowance = SalaryGenrationHelper.GetDeanAllowance(employee.IsDean),
                GPF = SalaryGenrationHelper.GetGpf(employee.Salary),
                HouseRent = SalaryGenrationHelper.CalculateHouseRent(employee.Salary),
                IncomeTax = SalaryGenrationHelper.GetTax(1, 1, employee.Sex, employee.IsFreedomFighter),
                Institute = employee.Department,
                JoiningDate = employee.JoiningDate,
                MainSalary = employee.Salary,
                MedicalAllowance = SalaryGenrationHelper.GetMedicalBill(),
                Month = "ফেব্রুয়ারি/২০১৭",
                Name = employee.FullName,
                PayableMainSalary = employee.Salary,
                ResearchAllowance = SalaryGenrationHelper.GetResearchAllowance(),
                RevenueStamp = SalaryGenrationHelper.GetRevenueStampCost(),
                Somonnoy = "০",
                TelephoneAllowance = SalaryGenrationHelper.GetTelephoneAllowance(),
                Title = employee.Podobi,
                TransportationAllowance = SalaryGenrationHelper.GetTransportationAllowance(employee.HasOwnTransportationMethod),
                AssistantProvostAllowance = "",
                BookAllowance = "",
                ChairmanAllowance = SalaryGenrationHelper.GetChairmanAllowance(employee.IsChairman),
                Club = "",
                DevelopmentFund = "",
                FestivalAllowance = "",
                FutureFund = "",
                GasBill = "",
                Grade = "",
                GroupInsurance = "",
                HouseRentSub = "",
                InternetBill = "",
                MoharghoAlloowance = "",
                OthersAddition = "",
                PresonAllowance = "",
                ProvostAllowance = "",
                StudentAdvisorAllowance = "",
                StudentDevelopmentFund = "",
                TeacherFamilyDevelopment = "",
                WardenDirectorAllowance = ""
            };
            salary.Total = SalaryGenrationHelper.GetGrandTotal(salary);
            salary.TotalSubtraction = SalaryGenrationHelper.GetTotalSubtraction(salary);
            salary.NeatSalary = SalaryGenrationHelper.GetNeatTotalSalary(salary);

            return salary;
        }
    }
}
