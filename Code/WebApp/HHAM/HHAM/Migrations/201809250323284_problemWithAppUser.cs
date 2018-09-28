namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class problemWithAppUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserPatients", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserPatients", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.ApplicationUserPatients", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserPatients", new[] { "Patient_Id" });
            AddColumn("dbo.AspNetUsers", "Patient_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Patient_Id");
            AddForeignKey("dbo.AspNetUsers", "Patient_Id", "dbo.Patients", "Id");
            DropTable("dbo.ApplicationUserPatients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserPatients",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Patient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Patient_Id });
            
            DropForeignKey("dbo.AspNetUsers", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.AspNetUsers", new[] { "Patient_Id" });
            DropColumn("dbo.AspNetUsers", "Patient_Id");
            CreateIndex("dbo.ApplicationUserPatients", "Patient_Id");
            CreateIndex("dbo.ApplicationUserPatients", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationUserPatients", "Patient_Id", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserPatients", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
