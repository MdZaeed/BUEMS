namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowanceDatabaseCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allowances",
                c => new
                    {
                        SerialNo = c.Int(nullable: false, identity: true),
                        DutyName = c.String(),
                        AllowanceAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SerialNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Allowances");
        }
    }
}
