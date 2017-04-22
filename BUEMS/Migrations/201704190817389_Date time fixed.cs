namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datetimefixed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "JoiningDate", c => c.String());
            AlterColumn("dbo.Salaries", "JoiningDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Salaries", "JoiningDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "JoiningDate", c => c.DateTime(nullable: false));
        }
    }
}
