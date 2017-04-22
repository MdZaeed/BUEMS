namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TitleDatabaseChanged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        SerialNo = c.Int(nullable: false, identity: true),
                        TitleName = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.SerialNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Titles");
        }
    }
}
