namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseUpdatedForGrade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IncrementNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "IncrementNo");
        }
    }
}
