namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserProfileModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfileInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        UrlProfilePicture = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Patients", "UserProfileInfo_Id", c => c.Int());
            CreateIndex("dbo.Patients", "UserProfileInfo_Id");
            AddForeignKey("dbo.Patients", "UserProfileInfo_Id", "dbo.UserProfileInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfileInfoes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Patients", "UserProfileInfo_Id", "dbo.UserProfileInfoes");
            DropIndex("dbo.UserProfileInfoes", new[] { "User_Id" });
            DropIndex("dbo.Patients", new[] { "UserProfileInfo_Id" });
            DropColumn("dbo.Patients", "UserProfileInfo_Id");
            DropTable("dbo.UserProfileInfoes");
        }
    }
}
