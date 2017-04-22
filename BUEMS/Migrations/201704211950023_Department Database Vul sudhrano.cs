namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentDatabaseVulsudhrano : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "DepartmentName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "DepartmentName", c => c.Int(nullable: false));
        }
    }
}
