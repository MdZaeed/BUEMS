using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations.Model;

namespace BUEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class BanglaConversionb : DbMigration
    {
        internal static class MigrationExtensions
        {
            public static void DeleteDefaultContraint(IDbMigration migration, string tableName, string colName,
                bool suppressTransaction = false)
            {
                var sql = new SqlOperation(String.Format(@"DECLARE @SQL varchar(1000)
        SET @SQL='ALTER TABLE {0} DROP CONSTRAINT ['+(SELECT name
        FROM sys.default_constraints
        WHERE parent_object_id = object_id('{0}')
        AND col_name(parent_object_id, parent_column_id) = '{1}')+']';
        PRINT @SQL;
        EXEC(@SQL);", tableName, colName)) {SuppressTransaction = suppressTransaction};
                migration.AddOperation(sql);
            }

            internal static void DeleteDefaultContraint(string p1, string p2)
            {
                throw new NotImplementedException();
            }
        }

        public override void Up()
        {
            AlterColumn("dbo.Salaries", "HouseRent", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this,"dbo.Salaries", "MoharghoAlloowance");
            AlterColumn("dbo.Salaries", "MoharghoAlloowance", c => c.String());
            AlterColumn("dbo.Salaries", "MedicalAllowance", c => c.String());
            AlterColumn("dbo.Salaries", "TelephoneAllowance", c => c.String());
            AlterColumn("dbo.Salaries", "CurriculumAssitanceAllowance", c => c.String());
            AlterColumn("dbo.Salaries", "AssistantProctorAllowance", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "DeanAllowance");
            AlterColumn("dbo.Salaries", "DeanAllowance", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "ChairmanAllowance");
            AlterColumn("dbo.Salaries", "ChairmanAllowance", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "ProvostAllowance");
            AlterColumn("dbo.Salaries", "ProvostAllowance", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "AssistantProvostAllowance");
            AlterColumn("dbo.Salaries", "AssistantProvostAllowance", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "WardenDirectorAllowance");
            AlterColumn("dbo.Salaries", "WardenDirectorAllowance", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "StudentAdvisorAllowance");
            AlterColumn("dbo.Salaries", "StudentAdvisorAllowance", c => c.String());
            AlterColumn("dbo.Salaries", "ResearchAllowance", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "BookAllowance");
            AlterColumn("dbo.Salaries", "BookAllowance", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "AdditionalDutiesAllowance");
            AlterColumn("dbo.Salaries", "AdditionalDutiesAllowance", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "PresonAllowance");
            AlterColumn("dbo.Salaries", "PresonAllowance", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "OthersAddition");
            AlterColumn("dbo.Salaries", "OthersAddition", c => c.String());
            AlterColumn("dbo.Salaries", "Somonnoy", c => c.String());
            AlterColumn("dbo.Salaries", "Total", c => c.String());
            AlterColumn("dbo.Salaries", "GPF", c => c.String());
            AlterColumn("dbo.Salaries", "BF", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "FutureFund");
            AlterColumn("dbo.Salaries", "FutureFund", c => c.String());
            AlterColumn("dbo.Salaries", "TransportationAllowance", c => c.String());
            AlterColumn("dbo.Salaries", "IncomeTax", c => c.String());
            AlterColumn("dbo.Salaries", "RevenueStamp", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "DevelopmentFund");
            AlterColumn("dbo.Salaries", "DevelopmentFund", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "StudentDevelopmentFund");
            AlterColumn("dbo.Salaries", "StudentDevelopmentFund", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "TeacherFamilyDevelopment");
            AlterColumn("dbo.Salaries", "TeacherFamilyDevelopment", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "Club");
            AlterColumn("dbo.Salaries", "Club", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "HouseRentSub");
            AlterColumn("dbo.Salaries", "HouseRentSub", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "GasBill");
            AlterColumn("dbo.Salaries", "GasBill", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "InternetBill");
            AlterColumn("dbo.Salaries", "InternetBill", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "GroupInsurance");
            AlterColumn("dbo.Salaries", "GroupInsurance", c => c.String());
            AlterColumn("dbo.Salaries", "TotalSubtraction", c => c.String());
            AlterColumn("dbo.Salaries", "NeatSalary", c => c.String());
            MigrationExtensions.DeleteDefaultContraint(this, "dbo.Salaries", "FestivalAllowance");
            AlterColumn("dbo.Salaries", "FestivalAllowance", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.Salaries", "FestivalAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "NeatSalary", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "TotalSubtraction", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "GroupInsurance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "InternetBill", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "GasBill", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "HouseRentSub", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "Club", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "TeacherFamilyDevelopment", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "StudentDevelopmentFund", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "DevelopmentFund", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "RevenueStamp", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "IncomeTax", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "TransportationAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "FutureFund", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "BF", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "GPF", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "Total", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "Somonnoy", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "OthersAddition", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "PresonAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "AdditionalDutiesAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "BookAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "ResearchAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "StudentAdvisorAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "WardenDirectorAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "AssistantProvostAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "ProvostAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "ChairmanAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "DeanAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "AssistantProctorAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "CurriculumAssitanceAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "TelephoneAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "MedicalAllowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "MoharghoAlloowance", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "HouseRent", c => c.Int(nullable: false));
        }
    }
}
