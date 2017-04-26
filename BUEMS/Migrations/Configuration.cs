namespace BUEMS.Migrations
{
    using BUEMS.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BUEMS.Models.BUEMSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BUEMS.Models.BUEMSDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Employees.AddOrUpdate(e => e.SerialNo,
                new Employee
                {
                    SerialNo = 1,
                    AccountNo = "০৩৩৮১০০০০০০২৩",
                    Category = "শিক্ষক",
                    Department = "ইংরেজি বিভাগ",
                    FullName = "ড মোঃ মুহসিন উদ্দিন",
                    HasOwnTransportationMethod = true,
                    IdNo = "০০১০১০৭৭০০০",
                    IsAddiitonalDuties = false,
                    IsAssistantProctor = false,
                    IsChairman = false,
                    IsDean = true,
                    IsFreedomFighter = false,
                    IsProctor = false,
                    IsProvost = false,
                    IsStudentAdviser = false,
                    IsTeacher = true,
                    JoiningDate = "১০০৩২০১৬",
                    MainSalaryGrade = "৫৬৫০০-৭৪৪০০",
                    Podobi = "অধ্যাপক",
                    Salary = 56500,
                    Sex = "পুরুষ",
                    IncrementNo = "২"
                },
                new Employee
                {
                    SerialNo = 2,
                    AccountNo = "০৩৩৮১০০০০০০৫৬",
                    Category = "শিক্ষক",
                    Department = "ইংরেজি বিভাগ",
                    FullName = "মোহাম্মদ তানভীর কায়ছার",
                    HasOwnTransportationMethod = true,
                    IdNo = "০০১০১০২৮২০০",
                    IsAddiitonalDuties = false,
                    IsAssistantProctor = false,
                    IsChairman = true,
                    IsDean = false,
                    IsFreedomFighter = false,
                    IsProctor = false,
                    IsProvost = false,
                    IsStudentAdviser = false,
                    IsTeacher = true,
                    JoiningDate = "২৫১০২০১৩",
                    MainSalaryGrade = "৩৫৫০০-৬৭০১০",
                    Podobi = "অধ্যাপক",
                    Salary = 41110,
                    Sex = "পুরুষ",
                    IncrementNo = "২"
                });

            context.Titles.AddOrUpdate(i => i.SerialNo,
                new Title { SerialNo = 1, TitleName = "অধ্যাপক", Category = "শিক্ষক" },
                new Title { SerialNo = 2, TitleName = "সহকারী অধ্যাপক", Category = "শিক্ষক" },
                 new Title { SerialNo = 3, TitleName = "লেকচারার", Category = "শিক্ষক" },
                  new Title { SerialNo = 4, TitleName = "ট্রেজারার", Category = "কর্মচারি" },
                  new Title { SerialNo = 5, TitleName = "রেজিস্টার", Category = "কর্মচারি" },
                    new Title { SerialNo = 6, TitleName = "পরিচালক অর্থ ও হিসাব(চুক্তিভিত্তিক)", Category = "কর্মচারি" },
                      new Title { SerialNo = 7, TitleName = "পরীক্ষা নিয়ন্ত্রক", Category = "কর্মচারি" },
                        new Title { SerialNo = 8, TitleName = "উপ পরিচালক", Category = "কর্মচারি" },
                          new Title { SerialNo = 9, TitleName = "নির্বাহী প্রকৌশলী", Category = "কর্মচারি" },
                            new Title { SerialNo = 10, TitleName = "সহকারী রেজিস্টার", Category = "কর্মচারি" },
  new Title { SerialNo = 11, TitleName = "উপ পরীক্ষা নিয়ন্ত্রক", Category = "কর্মচারি" },
    new Title { SerialNo = 12, TitleName = "সেকশন অফিসার", Category = "কর্মচারি" },
      new Title { SerialNo = 13, TitleName = "সহকারী পরিচালক", Category = "কর্মচারি" },
        new Title { SerialNo = 14, TitleName = "একাউন্টস অফিসার", Category = "কর্মচারি" },
          new Title { SerialNo = 15, TitleName = "ফিজিক্যাল ইন্সট্র্যাক্টর", Category = "কর্মচারি" },
            new Title { SerialNo = 16, TitleName = "অ্যাসিস্ট্যান্ট প্রোগ্রামার", Category = "কর্মচারি" },
              new Title { SerialNo = 17, TitleName = "আইটি ইঞ্জিনিয়ার", Category = "কর্মচারি" },
              new Title { SerialNo = 18, TitleName = "অডিট অ্যান্ড একাউন্টস অফিসার", Category = "কর্মচারি" },
                  new Title { SerialNo = 19, TitleName = "ড্রাইভার", Category = "কর্মচারি" });

            context.Departments.AddOrUpdate(i => i.SerialNo,
                new Department { SerialNo = 1, DepartmentName = "ইংরেজি" },
                new Department { SerialNo = 2, DepartmentName = "গণিত" },
                new Department { SerialNo = 3, DepartmentName = "সমাজবিজ্ঞান" },
                new Department { SerialNo = 4, DepartmentName = "অর্থনীতি" },
                new Department { SerialNo = 5, DepartmentName = "মার্কেটিং" },
                new Department { SerialNo = 6, DepartmentName = "সয়েল সায়েন্স" },
                new Department { SerialNo = 7, DepartmentName = "লোক প্রশাসন" },
                new Department { SerialNo = 8, DepartmentName = "এআইএস" },
                new Department { SerialNo = 9, DepartmentName = "বাংলা" },
                new Department { SerialNo = 10, DepartmentName = "ম্যানেজমেন্ট" },
                new Department { SerialNo = 11, DepartmentName = "ফাইনান্স অ্যান্ড ব্যাংকিং" },
                new Department { SerialNo = 12, DepartmentName = "আইন" },
                new Department { SerialNo = 13, DepartmentName = "রসায়ণ" },
                new Department { SerialNo = 14, DepartmentName = "উদ্ভিদ বিজ্ঞান" },
                new Department { SerialNo = 15, DepartmentName = "জিওলজি" },
                new Department { SerialNo = 16, DepartmentName = "পদাথ বিজ্ঞান" },
                new Department { SerialNo = 17, DepartmentName = "দর্শন" },
                new Department { SerialNo = 18, DepartmentName = "কম্পিউটার সায়েন্স" });

            context.Allowances.AddOrUpdate(i => i.SerialNo,
                new Allowance { SerialNo = 1, DutyName = "ডিন", AllowanceAmount = "৩০০০" },
                new Allowance { SerialNo = 3, DutyName = "শিক্ষার্থী উপদেষ্টা", AllowanceAmount = "১৫০০" },
                new Allowance { SerialNo = 4, DutyName = "শিক্ষা সহয়তা ভাতা", AllowanceAmount = "0" },
                new Allowance { SerialNo = 5, DutyName = "চিকিৎসা ভাতা", AllowanceAmount = "১৫০০" },
                new Allowance { SerialNo = 6, DutyName = "সহকারী প্রক্টর", AllowanceAmount = "১৫০০" },
                new Allowance { SerialNo = 7, DutyName = "চেয়ারম্যান", AllowanceAmount = "৩০০০" },
                new Allowance { SerialNo = 8, DutyName = "প্রোভোস্ট", AllowanceAmount = "২৫০০" },
                new Allowance { SerialNo = 9, DutyName = "অতিরিক্ত দায়িত্ব", AllowanceAmount = "১০০০" },
                new Allowance { SerialNo = 10, DutyName = "গবেষণা ভাতা", AllowanceAmount = "৫০০" },
                new Allowance { SerialNo = 11, DutyName = "টেলিফোন ভাতা", AllowanceAmount = "৮০০" },
                new Allowance { SerialNo = 11, DutyName = "পরিবহন", AllowanceAmount = "২০০" },
                new Allowance { SerialNo = 11, DutyName = "রেভিনিউ স্ট্যাম্প", AllowanceAmount = "১০" }
                );

            context.Grades.AddOrUpdate(i => i.GradeNo,
                new Grade { GradeNo = 1, GradeRange = "৭৮০০০" },
                new Grade { GradeNo = 2, GradeRange = "৬৬০০০-৭৬৪৯০" },
                new Grade { GradeNo = 3, GradeRange = "৫৬৫০০-৭৪৪০০" },
                new Grade { GradeNo = 4, GradeRange = "৫০০০০-৭১২০০" });

            context.Taxes.AddOrUpdate(i => i.SerialNo,
                new Tax
                {
                    Grade = 1,
                    Scale = 1,
                    MainSalary = 78000,
                    MonthlyTaxMale = 4900,
                    MonthlyTaxFemale = 4275,
                    MonthlyTaxFreedomFighter = 2713
                },
                new Tax
                {
                    Grade = 2,
                    Scale = 1,
                    MainSalary = 66000,
                    MonthlyTaxMale = 3409,
                    MonthlyTaxFemale = 2784,
                    MonthlyTaxFreedomFighter = 1222
                },
                new Tax
                {
                    Grade = 2,
                    Scale = 2,
                    MainSalary = 68480,
                    MonthlyTaxMale = 3717,
                    MonthlyTaxFemale = 3092,
                    MonthlyTaxFreedomFighter = 1530
                },
                new Tax
                {
                    Grade = 2,
                    Scale = 3,
                    MainSalary = 71050,
                    MonthlyTaxMale = 4037,
                    MonthlyTaxFemale = 3412,
                    MonthlyTaxFreedomFighter = 1849
                },
                new Tax
                {
                    Grade = 2,
                    Scale = 4,
                    MainSalary = 73720,
                    MonthlyTaxMale = 4368,
                    MonthlyTaxFemale = 3743,
                    MonthlyTaxFreedomFighter = 2181
                },


                new Tax
                {
                    Grade = 2,
                    Scale = 5,
                    MainSalary = 76490,
                    MonthlyTaxMale = 4712,
                    MonthlyTaxFemale = 4087,
                    MonthlyTaxFreedomFighter = 2525
                },

                new Tax
                {
                    Grade = 3,
                    Scale = 1,
                    MainSalary = 56500,
                    MonthlyTaxMale = 2228,
                    MonthlyTaxFemale = 1603,
                    MonthlyTaxFreedomFighter = 150
                },
                  new Tax
                  {
                      Grade = 3,
                      Scale = 2,
                      MainSalary = 58760,
                      MonthlyTaxMale = 2509,
                      MonthlyTaxFemale = 1884,
                      MonthlyTaxFreedomFighter = 322
                  },
                  new Tax
                  {
                      Grade = 3,
                      Scale = 3,
                      MainSalary = 61120,
                      MonthlyTaxMale = 2802,
                      MonthlyTaxFemale = 2177,
                      MonthlyTaxFreedomFighter = 615
                  },
                  new Tax
                  {
                      Grade = 3,
                      Scale = 4,
                      MainSalary = 63570,
                      MonthlyTaxMale = 3107,
                      MonthlyTaxFemale = 2482,
                      MonthlyTaxFreedomFighter = 919
                  },
                  new Tax
                  {
                      Grade = 3,
                      Scale = 5,
                      MainSalary = 66120,
                      MonthlyTaxMale = 3424,
                      MonthlyTaxFemale = 2799,
                      MonthlyTaxFreedomFighter = 1236
                  }, new Tax
                  {
                      Grade = 3,
                      Scale = 6,
                      MainSalary = 66770,
                      MonthlyTaxMale = 3753,
                      MonthlyTaxFemale = 3128,
                      MonthlyTaxFreedomFighter = 1566
                  }, new Tax
                  {
                      Grade = 3,
                      Scale = 7,
                      MainSalary = 71530,
                      MonthlyTaxMale = 4096,
                      MonthlyTaxFemale = 3471,
                      MonthlyTaxFreedomFighter = 1908
                  },
                  new Tax
                  {
                      Grade = 3,
                      Scale = 8,
                      MainSalary = 74400,
                      MonthlyTaxMale = 4453,
                      MonthlyTaxFemale = 3828,
                      MonthlyTaxFreedomFighter = 2265
                  },

                  new Tax
                  {
                      Grade = 4,
                      Scale = 1,
                      MainSalary = 50000,
                      MonthlyTaxMale = 1421,
                      MonthlyTaxFemale = 796,
                      MonthlyTaxFreedomFighter = 250
                  },

                    new Tax
                    {
                        Grade = 4,
                        Scale = 2,
                        MainSalary = 52000,
                        MonthlyTaxMale = 1669,
                        MonthlyTaxFemale = 1044,
                        MonthlyTaxFreedomFighter = 250
                    }, new Tax
                    {
                        Grade = 4,
                        Scale = 3,
                        MainSalary = 54080,
                        MonthlyTaxMale = 1928,
                        MonthlyTaxFemale = 1303,
                        MonthlyTaxFreedomFighter = 250
                    }, new Tax
                    {
                        Grade = 4,
                        Scale = 4,
                        MainSalary = 56250,
                        MonthlyTaxMale = 2197,
                        MonthlyTaxFemale = 1572,
                        MonthlyTaxFreedomFighter = 250
                    }, new Tax
                    {
                        Grade = 4,
                        Scale = 5,
                        MainSalary = 58500,
                        MonthlyTaxMale = 2477,
                        MonthlyTaxFemale = 1850,
                        MonthlyTaxFreedomFighter = 281
                    }, new Tax
                    {
                        Grade = 4,
                        Scale = 6,
                        MainSalary = 60840,
                        MonthlyTaxMale = 2768,
                        MonthlyTaxFemale = 2143,
                        MonthlyTaxFreedomFighter = 580
                    }, new Tax
                    {
                        Grade = 4,
                        Scale = 7,
                        MainSalary = 63280,
                        MonthlyTaxMale = 3071,
                        MonthlyTaxFemale = 2446,
                        MonthlyTaxFreedomFighter = 883
                    }, new Tax
                    {
                        Grade = 4,
                        Scale = 8,
                        MainSalary = 65820,
                        MonthlyTaxMale = 3386,
                        MonthlyTaxFemale = 2761,
                        MonthlyTaxFreedomFighter = 1199
                    }, new Tax
                    {
                        Grade = 4,
                        Scale = 9,
                        MainSalary = 68460,
                        MonthlyTaxMale = 3714,
                        MonthlyTaxFemale = 3089,
                        MonthlyTaxFreedomFighter = 1527
                    }, new Tax
                    {
                        Grade = 4,
                        Scale = 10,
                        MainSalary = 71200,
                        MonthlyTaxMale = 4055,
                        MonthlyTaxFemale = 3430,
                        MonthlyTaxFreedomFighter = 1867
                    }
                );

            context.Salaries.AddOrUpdate(i => i.SerialNo,
                new Salary
                {
                    AccountNo = "Test1",
                    AdditionalDutiesAllowance = "",
                    AssistantProctorAllowance = "",
                    AssistantProvostAllowance = "",
                    BF = "",
                    BookAllowance = "",
                    Month = "ফেব্রুয়ারি/২০১৭"
                },
                new Salary
                {
                    AccountNo = "Test2",
                    AdditionalDutiesAllowance = "",
                    AssistantProctorAllowance = "",
                    AssistantProvostAllowance = "",
                    BF = "",
                    BookAllowance = "",
                    Month = "ফেব্রুয়ারি/২০১৭"
                },
                new Salary
                {
                    AccountNo = "Test3",
                    AdditionalDutiesAllowance = "",
                    AssistantProctorAllowance = "",
                    AssistantProvostAllowance = "",
                    BF = "",
                    BookAllowance = "",
                    Month = "ফেব্রুয়ারি/২০১৭"
                },
                new Salary
                {
                    AccountNo = "Test2",
                    AdditionalDutiesAllowance = "",
                    AssistantProctorAllowance = "",
                    AssistantProvostAllowance = "",
                    BF = "",
                    BookAllowance = "",
                    Month = "মার্চ/২০১৭"
                },
                new Salary
                {
                    AccountNo = "Test2",
                    AdditionalDutiesAllowance = "",
                    AssistantProctorAllowance = "",
                    AssistantProvostAllowance = "",
                    BF = "",
                    BookAllowance = "",
                    Month = "জানুয়ারি/২০১৭"
                });
        }
    }
}