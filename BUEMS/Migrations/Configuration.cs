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
                    AccountNo = "Acc1",
                    Category = "শিক্ষক",
                    Department = "আই আই টি",
                    FullName = "আব্দুল মান্নান",
                    HasOwnTransportationMethod = true,
                    IdNo = "ID1",
                    IsAddiitonalDuties = true,
                    IsAssistantProctor = false,
                    IsChairman = true,
                    IsDean = true,
                    IsFreedomFighter = true,
                    IsProctor = false,
                    IsProvost = false,
                    IsStudentAdviser = false,
                    IsTeacher = true,
                    JoiningDate = "03/03/2012",
                    MainSalaryGrade = "10000",
                    Podobi = "অধ্যাপক",
                    Salary = 10000,
                    Sex = "Male"
                },
                new Employee
                {
                    SerialNo = 2,
                    AccountNo = "Acc2",
                    Category = "শিক্ষক",
                    Department = "আই আই টি",
                    FullName = "জামাল হোসেইন",
                    HasOwnTransportationMethod = false,
                    IdNo = "ID2",
                    IsAddiitonalDuties = false,
                    IsAssistantProctor = true,
                    IsChairman = false,
                    IsDean = false,
                    IsFreedomFighter = false,
                    IsProctor = true,
                    IsProvost = true,
                    IsStudentAdviser = true,
                    IsTeacher = false,
                    JoiningDate = "02/02/2012",
                    MainSalaryGrade = "16750",
                    Podobi = "অধ্যাপক",
                    Salary = 10000,
                    Sex = "Male"
                },
                new Employee
                {
                    SerialNo = 3,
                    AccountNo = "Acc3",
                    Category = "শিক্ষক",
                    Department = "আই আই টি",
                    FullName = "রিফাত",
                    HasOwnTransportationMethod = false,
                    IdNo = "ID2",
                    IsAddiitonalDuties = false,
                    IsAssistantProctor = true,
                    IsChairman = false,
                    IsDean = false,
                    IsFreedomFighter = true,
                    IsProctor = true,
                    IsProvost = true,
                    IsStudentAdviser = true,
                    IsTeacher = false,
                    JoiningDate = "01/01/2014",
                    MainSalaryGrade = "16750",
                    Podobi = "অধ্যাপক",
                    Salary = 10000,
                    Sex = "Male"
                });
            context.Titles.AddOrUpdate(i => i.SerialNo,
                new Title {SerialNo = 1, TitleName = "অধ্যাপক", Category = "শিক্ষক"},
                new Title {SerialNo = 2, TitleName = "সহকারী অধ্যাপক", Category = "শিক্ষক"},
                new Title {SerialNo = 3, TitleName = "ড্রাইভার", Category = "কর্মচারি"});

            context.Departments.AddOrUpdate(i => i.SerialNo,
                new Department {SerialNo = 1, DepartmentName = "ইংরেজি"},
                new Department {SerialNo = 2, DepartmentName = "গণিত"},
                new Department {SerialNo = 3, DepartmentName = "কম্পিউটার সায়েন্স"});

            context.Allowances.AddOrUpdate(i => i.SerialNo,
                new Allowance {SerialNo = 1, DutyName = "ডিন", AllowanceAmount = "২৫০০"},
                new Allowance {SerialNo = 2, DutyName = "চেয়ারম্যান", AllowanceAmount = "২৫০০"},
                new Allowance {SerialNo = 3, DutyName = "শিক্ষার্থী উপদেষ্টা", AllowanceAmount = "১৫০০"});

            context.Grades.AddOrUpdate(i => i.GradeNo,
                new Grade {GradeNo = 1, GradeRange = "৭৮০০০"},
                new Grade {GradeNo = 2, GradeRange = "৬৬০০০-৭৬৪৯০"},
                new Grade {GradeNo = 3, GradeRange = "৫৬৫০০-৭৪৪০০"},
                new Grade {GradeNo = 4, GradeRange = "৫০০০০-৭১২০০"});
        }
    }
}
