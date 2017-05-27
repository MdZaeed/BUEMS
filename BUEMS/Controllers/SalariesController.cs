using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BUEMS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BUEMS.Controllers
{
    public class SalariesController : Controller
    {
        public BUEMSDbContext db = new BUEMSDbContext();

        public static AllownceCheck AllowanceCheck;

        public ActionResult IsSalaryGenerated()
        {
            var firstOrDefault1
                = db.SalaryHises.ToList().FirstOrDefault();
            if (firstOrDefault1 != null)
            {
                var preData1 = firstOrDefault1.Data;
                if (!preData1.Equals(""))
                {
                    return Json(true,JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false,JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllowanceConfirm()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AllowanceConfirm([Bind(Include = "FestivalBonus,BoisakhiBonus")] AllownceCheck allownceCheck)
        {
            if (ModelState.IsValid)
            {
                SalaryGenrationHelper.AllownceCheck = allownceCheck;
                return RedirectToAction("Salary","SalaryGen");
            }
            return View(allownceCheck);
        }

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

        public ActionResult NewIndex(string month, string year)
        {
            if (month.Equals("") && year.Equals(""))
            {
                DateTime dateTime = DateTime.Now;
                int monthInt = dateTime.Month;

                month = MonthMap.GetMonthData()[monthInt].MonthNameInEnglish;
                int yearInt = dateTime.Year;
                year = yearInt + "";
            }

            var data=MonthMap.GetMonthData().Find(i => i.MonthNameInEnglish.Equals(month));
            var monthBangla = data.MonthNameInBangla;
            var yearBangla = LanguageConverter.EnglishToBangla(year);
            string searchString = monthBangla + "/" + yearBangla;

            var datam = from a in db.Salaries
                where a.Month.Equals(searchString)
                select a;

            return Json(datam, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SalarySheetEdit(string data)
        {
            List<Salary> salaries = (List<Salary>) JsonConvert.DeserializeObject(data);
            List<Salary> newSalaries = UpdateSalaryList(salaries);
            return Json(newSalaries, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SalarySheetAng()
        {
            var salaries = new List<Salary>();
            var firstOrDefault
                = db.SalaryHises.ToList().FirstOrDefault();
            if (firstOrDefault != null)
            {
                var preData = firstOrDefault.Data;
                if (preData.Equals(""))
                {
                    var employees = db.Employees.ToList();
                    foreach (Employee employee in employees)
                    {
                        Salary salary = MapEmployeeToSalary(employee);
                        salaries.Add(salary);
                    }
                        db.SalaryHises.AddOrUpdate(i => i.SerialNo, new SalaryHis { SerialNo = 1, Data = JsonConvert.SerializeObject(salaries) });
                        db.SaveChanges();
                }
                else
                {
/*                    var obj = JObject.Parse(preData);
                    var url = obj["Data"];*/
                    salaries = JsonConvert.DeserializeObject<List<Salary>>(preData);
                }
                return Json(salaries, JsonRequestBehavior.AllowGet);
            }
                var preData2 = "";
                    var employees2 = db.Employees.ToList();
                    foreach (Employee employee in employees2)
                    {
                        Salary salary = MapEmployeeToSalary(employee);
                        salaries.Add(salary);
                    }
            string json = new JavaScriptSerializer().Serialize(Json(salaries).Data);
            SalaryHis sal = new SalaryHis {SerialNo = 1, Data = json};
            try
            {
                db.SalaryHises.AddOrUpdate(i=>i.SerialNo,sal);
                db.SaveChanges();
            }
            catch (Exception e)
            {
       
                string j=e.StackTrace;
            }
            return Json(salaries, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IndividualSheetData(int id)
        {
            var salaries = new List<Salary>();
            var firstOrDefault
                = db.SalaryHises.ToList().FirstOrDefault();
            if (firstOrDefault != null)
            {
                var preData = firstOrDefault.Data;
                if (preData.Equals(""))
                {
                    var employees = db.Employees.ToList();
                    foreach (Employee employee in employees)
                    {
                        Salary salary = MapEmployeeToSalary(employee);
                        salaries.Add(salary);
                    }
                    db.SalaryHises.AddOrUpdate(new SalaryHis { Data = new JavaScriptSerializer().Serialize(Json(salaries)) });
                }
                else
                {
                    salaries = JsonConvert.DeserializeObject<List<Salary>>(preData);
                }
                Salary sa = salaries.Find(i => i.SerialNo == id);
                return Json(sa, JsonRequestBehavior.AllowGet);
            }
            var preData2 = "";
            var employees2 = db.Employees.ToList();
            foreach (Employee employee in employees2)
            {
                Salary salary = MapEmployeeToSalary(employee);
                salaries.Add(salary);
            }
            string json = new JavaScriptSerializer().Serialize(Json(salaries).Data);
            SalaryHis sal = new SalaryHis { SerialNo = 1, Data = json };
            try
            {
                db.SalaryHises.AddOrUpdate(i => i.SerialNo, sal);
                db.SaveChanges();
            }
            catch (Exception e)
            {

                string j = e.StackTrace;
            }
            Salary sa2 = salaries.Find(i => i.SerialNo == id);
            return Json(sa2, JsonRequestBehavior.AllowGet);
//            var employee = db.Employees.Find(id);
//            Salary salary = MapEmployeeToSalary(employee);
//            return Json(salary, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateAll(List<Salary> json)
        {
            List<Salary> newSalaries = UpdateSalaryList(json);
            string newJson = JsonConvert.SerializeObject(newSalaries);
            db.SalaryHises.AddOrUpdate(i => i.SerialNo, new SalaryHis { SerialNo = 1, Data = newJson });
            db.SaveChanges();
            return RedirectToAction("Salaries", "SalaryGen");
        }

        public ActionResult ShiftConfirmed()
        {
            var firstOrDefault = db.SalaryHises.ToList().FirstOrDefault();
            if (firstOrDefault != null)
            {
                var json = firstOrDefault.Data;
                var salaries = JsonConvert.DeserializeObject<List<Salary>>(json);
                db.Salaries.AddRange(salaries);
                db.SalaryHises.AddOrUpdate(i=>i.SerialNo,new SalaryHis{SerialNo = 1,Data = ""});
                db.SaveChanges();
            }
            return RedirectToAction("Salaries","SalaryGen");
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
        public ActionResult Create(
            [Bind(
                Include =
                    "SerialNo,Name,Title,JoiningDate,MainSalary,PayableMainSalary,HouseRent,MedicalAllowance,CurriculumAssitanceAllowance,AssistantProctorAllowance,DeanORChairmanOrProvostAllowance,AdditionalDutiesOrStudentAdvisorAllowance,ResearchAllowance,TelephoneAllowance,Somonnoy,Total,GPF,BF,TransportationAllowance,IncomeTax,RevenueStamp,TotalSubtraction,NeatSalary"
                )] Salary salary)
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
        public ActionResult Edit(
            [Bind(
                Include =
                    "SerialNo,Name,Title,JoiningDate,MainSalary,PayableMainSalary,HouseRent,MedicalAllowance,CurriculumAssitanceAllowance,AssistantProctorAllowance,DeanORChairmanOrProvostAllowance,AdditionalDutiesOrStudentAdvisorAllowance,ResearchAllowance,TelephoneAllowance,Somonnoy,Total,GPF,BF,TransportationAllowance,IncomeTax,RevenueStamp,TotalSubtraction,NeatSalary"
                )] Salary salary)
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
                IdNo = employee.IdNo,
                AdditionalDutiesAllowance = SalaryGenrationHelper.GetAdditionalDutiesAllowance(employee.IsAddiitonalDuties),
                AssistantProctorAllowance = SalaryGenrationHelper.GetProctorAssistanceBill(employee.IsAssistantProctor),
                AccountNo = employee.AccountNo,
                BF = SalaryGenrationHelper.GetBf(employee.Salary, employee.Category),
                CurriculumAssitanceAllowance = SalaryGenrationHelper.GetCurriculumAssistanceBill(),
                DeanAllowance = SalaryGenrationHelper.GetDeanAllowance(employee.IsDean),
                GPF = SalaryGenrationHelper.GetGpf(employee.Salary),
                HouseRent = SalaryGenrationHelper.CalculateHouseRent(employee.Salary),
                IncomeTax = SalaryGenrationHelper.GetTax(1, 1, employee.Sex, employee.IsFreedomFighter),
                Institute = employee.Department,
                JoiningDate = employee.JoiningDate,
                MainSalary = employee.Salary,
                MedicalAllowance = SalaryGenrationHelper.GetMedicalBill(),
                Month = SalaryGenrationHelper.GetMonth(),
                Name = employee.FullName,
                PayableMainSalary = employee.Salary,
                ResearchAllowance = SalaryGenrationHelper.GetResearchAllowance(),
                RevenueStamp = SalaryGenrationHelper.GetRevenueStampCost(),
                Somonnoy = "০",
                TelephoneAllowance = SalaryGenrationHelper.GetTelephoneAllowance(),
                Title = employee.Podobi,
                TransportationAllowance = SalaryGenrationHelper.GetTransportationAllowance(employee.HasOwnTransportationMethod),
                BookAllowance = SalaryGenrationHelper.GetBookAllowance(),
                ChairmanAllowance = SalaryGenrationHelper.GetChairmanAllowance(employee.IsChairman),
                Club = SalaryGenrationHelper.GetClubAllowance(),
                DevelopmentFund = SalaryGenrationHelper.GetDevelopmentFund(),
                FestivalAllowance = SalaryGenrationHelper.GetFestivalAllowance(employee.Salary),
                GasBill = SalaryGenrationHelper.GetGasBill(),
                GroupInsurance = SalaryGenrationHelper.GetGroupInsurance(),
                HouseRentSub = SalaryGenrationHelper.GetHouseRentSub(),
                InternetBill = SalaryGenrationHelper.GetInternetBill(),
                MoharghoAlloowance = SalaryGenrationHelper.GetMoharghoAllowance(),
                PresonAllowance = SalaryGenrationHelper.GtePresonAllowance(),
                ProvostAllowance = SalaryGenrationHelper.GetProvostAllowance(employee.IsProvost),
                StudentAdvisorAllowance = SalaryGenrationHelper.GetStudentAdvisorAllowance(employee.IsStudentAdviser),
                StudentDevelopmentFund = SalaryGenrationHelper.GetStudentDevelopmentAllowance(),
                TeacherFamilyDevelopment = SalaryGenrationHelper.GetTeacherFamilyDevelopmentFund(),
                WardenDirectorAllowance = "",
                FutureFund = "",
                Grade = "",
                OthersAddition = "",
                AssistantProvostAllowance = "",
                BoisakhiAllowance = SalaryGenrationHelper.GetBoisakhiAllowance(employee.Salary),
                SrantiBinodonAllowance = SalaryGenrationHelper.GetSrantiAllowance()
            };
            salary.Total = SalaryGenrationHelper.GetGrandTotal(salary);
            salary.TotalSubtraction = SalaryGenrationHelper.GetTotalSubtraction(salary);
            salary.NeatSalary = SalaryGenrationHelper.GetNeatTotalSalary(salary);

            return salary;
        }

        public List<Salary> UpdateSalaryList(List<Salary> salaries )
        {
            List<Salary> newSalaries = new List<Salary>();
            foreach (Salary salary in salaries)
            {
                Salary newSalary = salary;
                newSalary.BF = SalaryGenrationHelper.GetBf(salary.MainSalary, "শিক্ষক");
                newSalary.GPF = SalaryGenrationHelper.GetGpf(salary.MainSalary);
                newSalary.Total = SalaryGenrationHelper.GetGrandTotal(newSalary);
                newSalary.TotalSubtraction = SalaryGenrationHelper.GetTotalSubtraction(newSalary);
                newSalary.NeatSalary = SalaryGenrationHelper.GetNeatTotalSalary(newSalary);

                newSalaries.Add(newSalary);
            }
            return newSalaries; 
        }
    }
}