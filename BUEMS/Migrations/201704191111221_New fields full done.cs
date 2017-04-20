namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newfieldsfulldone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salaries", "DevelopmentFund", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "StudentDevelopmentFund", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "TeacherFamilyDevelopment", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "Club", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "HouseRentSub", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "GasBill", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "InternetBill", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "GroupInsurance", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salaries", "GroupInsurance");
            DropColumn("dbo.Salaries", "InternetBill");
            DropColumn("dbo.Salaries", "GasBill");
            DropColumn("dbo.Salaries", "HouseRentSub");
            DropColumn("dbo.Salaries", "Club");
            DropColumn("dbo.Salaries", "TeacherFamilyDevelopment");
            DropColumn("dbo.Salaries", "StudentDevelopmentFund");
            DropColumn("dbo.Salaries", "DevelopmentFund");
        }
    }
}
