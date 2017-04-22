namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowanceDatabaseEdited : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Allowances", "AllowanceAmount", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Allowances", "AllowanceAmount", c => c.Int(nullable: false));
        }
    }
}
