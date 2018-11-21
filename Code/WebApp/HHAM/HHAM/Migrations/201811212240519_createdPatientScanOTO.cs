namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdPatientScanOTO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scans", "PatientAssociatedWith_Id", c => c.Int());
            CreateIndex("dbo.Scans", "PatientAssociatedWith_Id");
            AddForeignKey("dbo.Scans", "PatientAssociatedWith_Id", "dbo.Patients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scans", "PatientAssociatedWith_Id", "dbo.Patients");
            DropIndex("dbo.Scans", new[] { "PatientAssociatedWith_Id" });
            DropColumn("dbo.Scans", "PatientAssociatedWith_Id");
        }
    }
}
