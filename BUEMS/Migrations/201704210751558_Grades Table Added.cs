namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GradesTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeNo = c.Int(nullable: false, identity: true),
                        GradeRange = c.String(),
                    })
                .PrimaryKey(t => t.GradeNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Grades");
        }
    }
}
