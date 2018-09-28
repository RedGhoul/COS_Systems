namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TookOutScansFromPatient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Photos", new[] { "Patient_Id" });
            DropColumn("dbo.Photos", "Patient_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "Patient_Id", c => c.Int());
            CreateIndex("dbo.Photos", "Patient_Id");
            AddForeignKey("dbo.Photos", "Patient_Id", "dbo.Patients", "Id");
        }
    }
}
