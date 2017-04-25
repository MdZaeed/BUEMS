using System;
using System.Linq;
using BUEMS.Models;

namespace BUEMS.Controllers
{
    public static class SalaryGenrationHelper
    {
        private static BUEMSDbContext _db;
        public static int GetAllowanceFromDb(string searchString)
        {
            _db=new BUEMSDbContext();
            int all = 0;
            var results = from a in _db.Allowances
                where a.DutyName.Equals(searchString)
                select a;
            foreach (Allowance allowance in results)
            {
                all = Int32.Parse(LanguageConverter.BanglaToEnglish(allowance.AllowanceAmount));
            }
            return all;
        }
        public static int CalculateHouseRent(int mainSalary)
        {
            int tax;
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

        public static int GetMedicalBill()
        {
            return 1500;
        }

        public static int GetCurriculumAssistanceBill()
        {
            return 0;
        }

        public static int GetProctorAssistanceBill(Boolean answer)
        {
            if (answer)
            {
                return 1500;
            }
            return 0;
        }

        public static int GetDeanAllowance(Boolean answer)
        {
            if (answer)
            {
                return GetAllowanceFromDb("ডিন");
            }
            return 0;
        }

        public static int GetChairmanAllowance(Boolean answer)
        {
            if (answer)
            {
                return 1500;
            }
            return 0;
        }

        public static int GetProvostAllowance(Boolean answer)
        {
            if (answer)
            {
                return 1000;
            }
            return 0;
        }

        public static int GetAdditionalDutiesAllowance(Boolean answer)
        {
            if (answer)
            {
                return 1000;
            }
            return 0;
        }

        public static int GetStudentAdvisorAllowance(Boolean answer)
        {
            if (answer)
            {
                return 1500;
            }
            return 0;
        }

        public static int GetResearchAllowance()
        {
            return 500;
        }

        public static int GetTelephoneAllowance()
        {
            return 800;
        }

        public static int GetGpf(int mainSalary)
        {
            return (int)(mainSalary * .1);
        }

        public static int GetBf(int mainSalary, string category)
        {
            if (category.Equals("শিক্ষক"))
            {
                return (int)(mainSalary * .1);
            }
            if (category.Equals("??????") || category.Equals("?????????") || category.Equals("?? ??????"))
            {
                return (int)(mainSalary * .25);
            }
            return (int)(mainSalary * .125);
        }

        public static int GetTransportationAllowance(Boolean answer)
        {
            if (answer)
            {
                return 0;
            }
            return 200;
        }

        public static int GetTax(int scale, int grade, string sex, Boolean isFreedomFighter)
        {
            return 0;
        }

        public static int GetRevenueStampCost()
        {
            return 10;
        }

        public static int GetGrandTotal(Salary salary)
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

        public static int GetTotalSubtraction(Salary salary)
        {
            int subbed = salary.GPF
                + salary.BF
                + salary.TransportationAllowance
                + salary.IncomeTax
                + salary.RevenueStamp;
            return subbed;
        }

        public static int GetNeatTotalSalary(Salary salary)
        {
            int neat = salary.Total - salary.TotalSubtraction;
            return neat;
        }
    }
}