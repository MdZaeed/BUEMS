namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        SerialNo = c.Int(nullable: false, identity: true),
                        IdNo = c.String(),
                        FullName = c.String(),
                        Podobi = c.String(),
                        Salary = c.Int(nullable: false),
                        Category = c.String(),
                        Department = c.String(),
                        JoiningDate = c.DateTime(nullable: false),
                        AccountNo = c.String(),
                        MainSalary = c.String(),
                        Grade = c.String(),
                        Sex = c.String(),
                        IsFreedomFighter = c.Boolean(nullable: false),
                        IsAddiitonalDuties = c.Boolean(nullable: false),
                        IsStudentAdviser = c.Boolean(nullable: false),
                        IsDean = c.Boolean(nullable: false),
                        IsChairman = c.Boolean(nullable: false),
                        IsProvost = c.Boolean(nullable: false),
                        IsProctor = c.Boolean(nullable: false),
                        IsAssistantProctor = c.Boolean(nullable: false),
                        HasOwnTransportationMethod = c.Boolean(nullable: false),
                        IsTeacher = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SerialNo);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        SerialNo = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        JoiningDate = c.DateTime(nullable: false),
                        MainSalary = c.Int(nullable: false),
                        PayableMainSalary = c.Int(nullable: false),
                        HouseRent = c.Int(nullable: false),
                        MedicalAllowance = c.Int(nullable: false),
                        CurriculumAssitanceAllowance = c.Int(nullable: false),
                        AssistantProctorAllowance = c.Int(nullable: false),
                        DeanORChairmanOrProvostAllowance = c.Int(nullable: false),
                        AdditionalDutiesOrStudentAdvisorAllowance = c.Int(nullable: false),
                        ResearchAllowance = c.Int(nullable: false),
                        TelephoneAllowance = c.Int(nullable: false),
                        Somonnoy = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        GPF = c.Int(nullable: false),
                        BF = c.Int(nullable: false),
                        TransportationAllowance = c.Int(nullable: false),
                        IncomeTax = c.Int(nullable: false),
                        RevenueStamp = c.Int(nullable: false),
                        TotalSubtraction = c.Int(nullable: false),
                        NeatSalary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SerialNo);
            
            CreateTable(
                "dbo.Taxes",
                c => new
                    {
                        SerialNo = c.Int(nullable: false, identity: true),
                        Scale = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                        MainSalary = c.Int(nullable: false),
                        MonthlyTaxMale = c.Int(nullable: false),
                        MonthlyTaxFemale = c.Int(nullable: false),
                        MonthlyTaxFreedomFighter = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SerialNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Taxes");
            DropTable("dbo.Salaries");
            DropTable("dbo.Employees");
        }
    }
}
