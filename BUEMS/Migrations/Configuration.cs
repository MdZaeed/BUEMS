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
                new Employee {
                    SerialNo = 1,
                    AccountNo = "Acc1",
                    Category = "শিক্ষক",
                    Department = "আই আই টি",
                    FullName = "আব্দুল মান্নান",
                    Grade = "1",
                    HasOwnTransportationMethod = true,
                    IdNo = "ID1",
                    IsAddiitonalDuties = true,
                    IsAssistantProctor = false,
                    IsChairman=true,
                    IsDean = true,
                    IsFreedomFighter = true,
                    IsProctor = false,
                    IsProvost = false,
                    IsStudentAdviser = false,
                    IsTeacher = true,
                    JoiningDate = "03/03/2012",
                    MainSalary = "10000",
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
                                    Grade = "1",
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
                                    MainSalary = "16750",
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
                                    Grade = "1",
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
                                    MainSalary = "16750",
                                    Podobi = "অধ্যাপক",
                                    Salary = 10000,
                                    Sex = "Male"
                                });
        }
    }
}
