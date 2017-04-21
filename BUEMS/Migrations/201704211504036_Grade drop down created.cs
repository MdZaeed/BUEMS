namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Gradedropdowncreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "MainSalaryGrade", c => c.String());
            DropColumn("dbo.Employees", "MainSalary");
            DropColumn("dbo.Employees", "Grade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Grade", c => c.String());
            AddColumn("dbo.Employees", "MainSalary", c => c.String());
            DropColumn("dbo.Employees", "MainSalaryGrade");
        }
    }
}
