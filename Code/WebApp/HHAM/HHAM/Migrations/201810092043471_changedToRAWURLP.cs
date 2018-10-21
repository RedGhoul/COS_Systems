namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedToRAWURLP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scans", "RAW_URLProcessed", c => c.String());
            DropColumn("dbo.Scans", "ScanURL");
            DropColumn("dbo.Scans", "ScanURLProcessed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scans", "ScanURLProcessed", c => c.String());
            AddColumn("dbo.Scans", "ScanURL", c => c.String());
            DropColumn("dbo.Scans", "RAW_URLProcessed");
        }
    }
}
