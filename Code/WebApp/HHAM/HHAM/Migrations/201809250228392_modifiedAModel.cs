namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedAModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Age");
        }
    }
}
