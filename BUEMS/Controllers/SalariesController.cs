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

        protected int CalculateHouseRent(int mainSalary)
        {
            int tax = 0;
            if (mainSalary <= 9700)
            {
                tax = (int)(mainSalary * .55);
                if (tax < 5000)
                {
                    return 5000;
                }
            }
            else if (mainSalary <= 16000)
            {
                tax = (int)(mainSalary * .5);
                if (tax < 5400)
                {
                    return 5400;
                }
            }
            else if (mainSalary <= 35500)
            {
                tax = (int)(mainSalary * .45);
                if (tax < 8000)
                {
                    return 8000;
                }
            }
            else
            {
                tax = (int)(mainSalary * .4);
                if (tax < 16000)
                {
                    return 16000;
                }
            }
            return tax;
        }

        public int getMedicalBill()
        {
            return 1500;
        }

        public int getCurriculumAssistanceBill()
        {
            return 0;
        }

        public int getProctorAssistanceBill(Boolean answer)
        {
            if (answer)
            {
                return 1500;
            }
            else
            {
                return 0;
            }

        }

        public int getDeanAllowance(Boolean answer)
        {
            if (answer)
            {
                return 1500;
            }
            else
            {
                return 0;
            }

        }

        public int getChairmanAllowance(Boolean answer)
        {
            if (answer)
            {
                return 1500;
            }
            else
            {
                return 0;
            }

        }

        public int getProvostAllowance(Boolean answer)
        {
            if (answer)
            {
                return 1000;
            }
            else
            {
                return 0;
            }

        }

        public int getAdditionalDutiesAllowance(Boolean answer)
        {
            if (answer)
            {
                return 1000;
            }
            else
            {
                return 0;
            }
        }

        public int getStudentAdvisorAllowance(Boolean answer)
        {
            if (answer)
            {
                return 1500;
            }
            else
            {
                return 0;
            }

        }

        public int getResearchAllowance()
        {
            return 500;
        }

        public int getTelephoneAllowance()
        {
            return 800;
        }

        public int getGPF(int MainSalary)
        {
            return (int)(MainSalary * .1);
        }

        public int getBF(int MainSalary, string Category)
        {
            if (Category.Equals("শিক্ষক"))
            {
                return (int)(MainSalary * .1);
            }
            else if (Category.Equals("??????") || Category.Equals("?????????") || Category.Equals("?? ??????"))
            {
                return (int)(MainSalary * .25);
            }
            else
            {
                return (int)(MainSalary * .125);
            }
        }

        public int getTransportationAllowance(Boolean answer)
        {
            if (answer)
            {
                return 0;
            }
            else
            {
                return 200;
            }

        }

        public int getTax(int Scale, int Grade, string Sex, Boolean isFreedomFighter)
        {
            return 0;
        }

        public int getRevenueStampCost()
        {
            return 10;
        }

        public int getGrandTotal(Salary salary)
        {
            int grandTotal = salary.PayableMainSalary
                + salary.HouseRent
                + salary.MedicalAllowance
                + salary.CurriculumAssitanceAllowance
                + salary.AssistantProctorAllowance
                + salary.DeanAllowance
                + salary.AdditionalDutiesAllowance
                + salary.ResearchAllowance
                + salary.TelephoneAllowance
                + salary.Somonnoy;
            return grandTotal;
        }

        public int getTotalSubtraction(Salary salary)
        {
            int subbed = salary.GPF
                + salary.BF
                + salary.TransportationAllowance
                + salary.IncomeTax
                + salary.RevenueStamp;
            return subbed;
        }

        public int getNeatTotalSalary(Salary salary)
        {
            int neat = salary.Total - salary.TotalSubtraction;
            return neat;
        }

        public Salary MapEmployeeToSalary(Employee employee)
        {
            Salary salary = new Salary
            {
                SerialNo = employee.SerialNo,
                AdditionalDutiesAllowance = getAdditionalDutiesAllowance(employee.IsAddiitonalDuties) + getStudentAdvisorAllowance(employee.IsStudentAdviser),
                AssistantProctorAllowance = getProctorAssistanceBill(employee.IsAssistantProctor),
                AccountNo = employee.AccountNo,
                BF = getBF(employee.Salary, employee.Category),
                CurriculumAssitanceAllowance = getCurriculumAssistanceBill(),
                //                DeanORChairmanOrProvostAllowance = getDeanAllowance(employee.IsDean) + getChairmanAllowance(employee.IsChairman) + getProvostAllowance(employee.IsProvost),
                GPF = getGPF(employee.Salary),
                HouseRent = CalculateHouseRent(employee.Salary),
                IncomeTax = getTax(1, 1, employee.Sex, employee.IsFreedomFighter),
                Institute = employee.Department,
                JoiningDate = employee.JoiningDate,
                MainSalary = employee.Salary,
                MedicalAllowance = getMedicalBill(),
                Month = "ফেব্রুয়ারি/২০১৭",
                Name = employee.FullName,
                PayableMainSalary = employee.Salary,
                ResearchAllowance = getResearchAllowance(),
                RevenueStamp = getRevenueStampCost(),
                Somonnoy = 0,
                TelephoneAllowance = getTelephoneAllowance(),
                Title = employee.Podobi,
                TransportationAllowance = getTransportationAllowance(employee.HasOwnTransportationMethod)
            };
            salary.Total = getGrandTotal(salary);
            salary.TotalSubtraction = getTotalSubtraction(salary);
            salary.NeatSalary = getNeatTotalSalary(salary);

            return salary;
        }
    }
}
