namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentDatabaseCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        SerialNo = c.Int(nullable: false, identity: true),
                        DepartmentName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SerialNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Departments");
        }
    }
}
