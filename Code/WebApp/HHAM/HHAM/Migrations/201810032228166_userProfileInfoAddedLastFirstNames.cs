namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userProfileInfoAddedLastFirstNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfileInfoes", "FirstName", c => c.String());
            AddColumn("dbo.UserProfileInfoes", "LastName", c => c.String());
            DropColumn("dbo.UserProfileInfoes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfileInfoes", "Name", c => c.String());
            DropColumn("dbo.UserProfileInfoes", "LastName");
            DropColumn("dbo.UserProfileInfoes", "FirstName");
        }
    }
}
