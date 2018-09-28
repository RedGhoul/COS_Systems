namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCareGiversToPatientModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserPatients",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Patient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Patient_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Patient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserPatients", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.ApplicationUserPatients", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserPatients", new[] { "Patient_Id" });
            DropIndex("dbo.ApplicationUserPatients", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserPatients");
        }
    }
}
