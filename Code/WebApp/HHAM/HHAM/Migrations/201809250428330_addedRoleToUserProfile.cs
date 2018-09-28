namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRoleToUserProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfileInfoes", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfileInfoes", "Role");
        }
    }
}
