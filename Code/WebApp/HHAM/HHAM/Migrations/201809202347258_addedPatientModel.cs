namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPatientModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Weight = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        DateAdmited = c.DateTime(nullable: false),
                        DateReleased = c.DateTime(nullable: false),
                        PersonalPhotoURL = c.String(),
                        Notes = c.String(),
                        Gender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.Gender_Id)
                .Index(t => t.Gender_Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Photos", "Patient_Id", c => c.Int());
            CreateIndex("dbo.Photos", "Patient_Id");
            AddForeignKey("dbo.Photos", "Patient_Id", "dbo.Patients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Patients", "Gender_Id", "dbo.Genders");
            DropIndex("dbo.Photos", new[] { "Patient_Id" });
            DropIndex("dbo.Patients", new[] { "Gender_Id" });
            DropColumn("dbo.Photos", "Patient_Id");
            DropTable("dbo.Genders");
            DropTable("dbo.Patients");
        }
    }
}
