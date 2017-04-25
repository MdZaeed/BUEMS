using System;
using System.Linq;
using BUEMS.Models;

namespace BUEMS.Controllers
{
    public static class SalaryGenrationHelper
    {
        private static BUEMSDbContext _db;
        public static string GetAllowanceFromDb(string searchString)
        {
            _db=new BUEMSDbContext();
            string all = "০";
            var results = from a in _db.Allowances
                where a.DutyName.Equals(searchString)
                select a;
            foreach (Allowance allowance in results)
            {
                all = allowance.AllowanceAmount;
            }
            return all;
        }
        public static string CalculateHouseRent(int mainSalary)
        {
            int tax;
            if (mainSalary <= 9700)
            {
                tax = (int)(mainSalary * .55);
                if (tax < 5000)
                {
                    return "৫০০০";
                }
            }
            else if (mainSalary <= 16000)
            {
                tax = (int)(mainSalary * .5);
                if (tax < 5400)
                {
                    return "৫৪০০";
                }
            }
            else if (mainSalary <= 35500)
            {
                tax = (int)(mainSalary * .45);
                if (tax < 8000)
                {
                    return "৮০০০";
                }
            }
            else
            {
                tax = (int)(mainSalary * .4);
                if (tax < 16000)
                {
                    return "১৬০০০";
                }
            }
            return LanguageConverter.EnglishToBangla(tax + "");
        }

        public static string GetMedicalBill()
        {
            return GetAllowanceFromDb("চিকিৎসা ভাতা");
        }

        public static string GetCurriculumAssistanceBill()
        {
            return GetAllowanceFromDb("শিক্ষা সহায়তা ভাতা");
        }

        public static string GetProctorAssistanceBill(Boolean answer)
        {
            if (answer)
            {
                return GetAllowanceFromDb("সহকারী প্রক্টর");
            }
            return "০";
        }

        public static string GetDeanAllowance(Boolean answer)
        {
            if (answer)
            {
                return GetAllowanceFromDb("ডিন");
            }
            return "০";
        }

        public static string GetChairmanAllowance(Boolean answer)
        {
            if (answer)
            {
                return GetAllowanceFromDb("চেয়ারম্যান");
            }
            return "০";
        }

        public static string GetProvostAllowance(Boolean answer)
        {
            if (answer)
            {
                return GetAllowanceFromDb("প্রোভোস্ট");
            }
            return "০";
        }

        public static string GetAdditionalDutiesAllowance(Boolean answer)
        {
            if (answer)
            {
                return GetAllowanceFromDb("অতিরিক্ত দায়িত্ব");
            }
            return "০";
        }

        public static string GetStudentAdvisorAllowance(Boolean answer)
        {
            if (answer)
            {
                return GetAllowanceFromDb("শিক্ষার্থী উপদেষ্টা");
            }
            return "০";
        }

        public static string GetResearchAllowance()
        {
            return GetAllowanceFromDb("গবেষণা ভাতা");
        }


        public static string GetTelephoneAllowance()
        {
            return GetAllowanceFromDb("টেলিফোন ভাতা");
        }

        public static string GetGpf(int mainSalary)
        {
            return LanguageConverter.EnglishToBangla(((int)(mainSalary * .1)) +  "" );
        }
         
        public static string GetBf(int mainSalary, string category)
        {
            if (category.Equals("শিক্ষক"))
            {
                return LanguageConverter.EnglishToBangla((int)(mainSalary * .1) + "");
            }
            if (category.Equals("??????") || category.Equals("?????????") || category.Equals("?? ??????"))
            {
                return LanguageConverter.EnglishToBangla((int)(mainSalary * .25) + "");
            }
            return LanguageConverter.EnglishToBangla((int)(mainSalary * .125) + "");
        }

        public static string GetTransportationAllowance(Boolean answer)
        {
            if (!answer)
            {
                return GetAllowanceFromDb("পরিবহন");
            }
            return "০";
        }

        public static string GetTax(int scale, int grade, string sex, Boolean isFreedomFighter)
        {
            return "০";
        }

        public static string GetRevenueStampCost()
        {
            return GetAllowanceFromDb("রেভিনিউ স্ট্যাম্প");
        }

//Seed method from here
        public static string GetBookAllowance()
        {
            return GetAllowanceFromDb("বই ভাতা");
        }

        public static string GetClubAllowance()
        {
            return GetAllowanceFromDb("ক্লাব");
        }

        public static string GetDevelopmentFund()
        {
            return GetAllowanceFromDb("কল্যাণ ফান্ড");
        }

        public static string GetFestivalAllowance()
        {
            return GetAllowanceFromDb("উৎসব ভাতা");
        }

        public static string GetGasBill()
        {
            return GetAllowanceFromDb("গ্যাস বিল");
        }

        public static string GetGroupInsurance()
        {
            return GetAllowanceFromDb("গ্রুপ ইন্সুরেন্স");
        }

        public static string GetHouseRentSub()
        {
            return GetAllowanceFromDb("বাড়ি ভাড়া");
        }

        public static string GetInternetBill()
        {
            return GetAllowanceFromDb("ইন্টারনেট বিল");
        }

        public static string GetMoharghoAllowance()
        {
            return GetAllowanceFromDb("মহার্ঘ্য ভাতা");
        }

        public static string GtePresonAllowance()
        {
            return GetAllowanceFromDb("প্রেষণ ভাতা");
        }

        public static string GetStudentDevelopmentAllowance()
        {
            return GetAllowanceFromDb("ছাত্র কল্যাণ ভাতা");
        }

        public static string GetTeacherFamilyDevelopmentFund()
        {
            return GetAllowanceFromDb("শিক্ষক পরিবার কল্যান");
        }

        public static string GetGrandTotal(Salary salary)
        {
            int grandTotal = (salary.PayableMainSalary)
                + Int32.Parse(LanguageConverter.BanglaToEnglish(salary.HouseRent))
                + Int32.Parse(LanguageConverter.BanglaToEnglish(salary.MedicalAllowance))
                + Int32.Parse(LanguageConverter.BanglaToEnglish(salary.CurriculumAssitanceAllowance))
                + Int32.Parse(LanguageConverter.BanglaToEnglish(salary.AssistantProctorAllowance))
                + Int32.Parse(LanguageConverter.BanglaToEnglish(salary.DeanAllowance))
                + Int32.Parse(LanguageConverter.BanglaToEnglish(salary.AdditionalDutiesAllowance))
                + Int32.Parse(LanguageConverter.BanglaToEnglish(salary.ResearchAllowance))
                + Int32.Parse(LanguageConverter.BanglaToEnglish(salary.TelephoneAllowance))
                + Int32.Parse(LanguageConverter.BanglaToEnglish(salary.Somonnoy));
            return LanguageConverter.EnglishToBangla(grandTotal + "");
        }

        public static string GetTotalSubtraction(Salary salary)
        {
            int subbed = Int32.Parse(LanguageConverter.BanglaToEnglish(salary.GPF))
                + Int32.Parse(LanguageConverter.BanglaToEnglish(salary.BF))
                + Int32.Parse(LanguageConverter.BanglaToEnglish(salary.TransportationAllowance))
                + Int32.Parse(LanguageConverter.BanglaToEnglish(salary.IncomeTax))
                + Int32.Parse(LanguageConverter.BanglaToEnglish(salary.RevenueStamp));
            return LanguageConverter.EnglishToBangla(subbed + "");
        }

        public static string GetNeatTotalSalary(Salary salary)
        {
            int neat = Int32.Parse(LanguageConverter.BanglaToEnglish(salary.Total))
                - Int32.Parse(LanguageConverter.BanglaToEnglish(salary.TotalSubtraction));
            return LanguageConverter.EnglishToBangla(neat + "");
        }
    }
}