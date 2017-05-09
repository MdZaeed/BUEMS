namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeporaryIntroduced : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalaryHis",
                c => new
                    {
                        SerialNo = c.Int(nullable: false, identity: true),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.SerialNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SalaryHis");
        }
    }
}
