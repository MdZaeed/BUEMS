namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SrantiandBoisakhi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salaries", "SrantiBinodonAllowance", c => c.String());
            AddColumn("dbo.Salaries", "BoisakhiAllowance", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salaries", "BoisakhiAllowance");
            DropColumn("dbo.Salaries", "SrantiBinodonAllowance");
        }
    }
}
