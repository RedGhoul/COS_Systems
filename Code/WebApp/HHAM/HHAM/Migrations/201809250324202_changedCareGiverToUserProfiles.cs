namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedCareGiverToUserProfiles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Patients", "UserProfileInfo_Id", "dbo.UserProfileInfoes");
            DropIndex("dbo.Patients", new[] { "UserProfileInfo_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Patient_Id" });
            CreateTable(
                "dbo.UserProfileInfoPatients",
                c => new
                    {
                        UserProfileInfo_Id = c.Int(nullable: false),
                        Patient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserProfileInfo_Id, t.Patient_Id })
                .ForeignKey("dbo.UserProfileInfoes", t => t.UserProfileInfo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.UserProfileInfo_Id)
                .Index(t => t.Patient_Id);
            
            DropColumn("dbo.Patients", "UserProfileInfo_Id");
            DropColumn("dbo.AspNetUsers", "Patient_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Patient_Id", c => c.Int());
            AddColumn("dbo.Patients", "UserProfileInfo_Id", c => c.Int());
            DropForeignKey("dbo.UserProfileInfoPatients", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.UserProfileInfoPatients", "UserProfileInfo_Id", "dbo.UserProfileInfoes");
            DropIndex("dbo.UserProfileInfoPatients", new[] { "Patient_Id" });
            DropIndex("dbo.UserProfileInfoPatients", new[] { "UserProfileInfo_Id" });
            DropTable("dbo.UserProfileInfoPatients");
            CreateIndex("dbo.AspNetUsers", "Patient_Id");
            CreateIndex("dbo.Patients", "UserProfileInfo_Id");
            AddForeignKey("dbo.Patients", "UserProfileInfo_Id", "dbo.UserProfileInfoes", "Id");
            AddForeignKey("dbo.AspNetUsers", "Patient_Id", "dbo.Patients", "Id");
        }
    }
}
