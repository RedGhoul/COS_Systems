namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNewPropsToBloodType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BloodTypes", "Value", c => c.String());
            AddColumn("dbo.BloodTypes", "Text", c => c.String());
            DropColumn("dbo.BloodTypes", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BloodTypes", "Type", c => c.String());
            DropColumn("dbo.BloodTypes", "Text");
            DropColumn("dbo.BloodTypes", "Value");
        }
    }
}
