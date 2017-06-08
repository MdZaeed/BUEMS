namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EnglishFullName", c => c.String());
            AddColumn("dbo.Employees", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Email");
            DropColumn("dbo.Employees", "EnglishFullName");
        }
    }
}
