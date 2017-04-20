namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newfieldshalfdone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salaries", "IdNo", c => c.String());
            AddColumn("dbo.Salaries", "Institute", c => c.String());
            AddColumn("dbo.Salaries", "Month", c => c.String());
            AddColumn("dbo.Salaries", "AccountNo", c => c.String());
            AddColumn("dbo.Salaries", "Grade", c => c.String());
            AddColumn("dbo.Salaries", "MoharghoAlloowance", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "DeanAllowance", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "ChairmanAllowance", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "ProvostAllowance", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "AssistantProvostAllowance", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "WardenDirectorAllowance", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "StudentAdvisorAllowance", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "BookAllowance", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "AdditionalDutiesAllowance", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "PresonAllowance", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "OthersAddition", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "FutureFund", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "FestivalAllowance", c => c.Int(nullable: false));
            DropColumn("dbo.Salaries", "DeanORChairmanOrProvostAllowance");
            DropColumn("dbo.Salaries", "AdditionalDutiesOrStudentAdvisorAllowance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Salaries", "AdditionalDutiesOrStudentAdvisorAllowance", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "DeanORChairmanOrProvostAllowance", c => c.Int(nullable: false));
            DropColumn("dbo.Salaries", "FestivalAllowance");
            DropColumn("dbo.Salaries", "FutureFund");
            DropColumn("dbo.Salaries", "OthersAddition");
            DropColumn("dbo.Salaries", "PresonAllowance");
            DropColumn("dbo.Salaries", "AdditionalDutiesAllowance");
            DropColumn("dbo.Salaries", "BookAllowance");
            DropColumn("dbo.Salaries", "StudentAdvisorAllowance");
            DropColumn("dbo.Salaries", "WardenDirectorAllowance");
            DropColumn("dbo.Salaries", "AssistantProvostAllowance");
            DropColumn("dbo.Salaries", "ProvostAllowance");
            DropColumn("dbo.Salaries", "ChairmanAllowance");
            DropColumn("dbo.Salaries", "DeanAllowance");
            DropColumn("dbo.Salaries", "MoharghoAlloowance");
            DropColumn("dbo.Salaries", "Grade");
            DropColumn("dbo.Salaries", "AccountNo");
            DropColumn("dbo.Salaries", "Month");
            DropColumn("dbo.Salaries", "Institute");
            DropColumn("dbo.Salaries", "IdNo");
        }
    }
}
