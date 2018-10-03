namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedNameAndAddedDICOM_URL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scans", "ScanURL", c => c.String());
            AddColumn("dbo.Scans", "ScanURLProcessed", c => c.String());
            AddColumn("dbo.Scans", "DICOM_URL", c => c.String());
            DropColumn("dbo.Scans", "DisplayURL");
            DropColumn("dbo.Scans", "DisplayURLProcessedImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scans", "DisplayURLProcessedImage", c => c.String());
            AddColumn("dbo.Scans", "DisplayURL", c => c.String());
            DropColumn("dbo.Scans", "DICOM_URL");
            DropColumn("dbo.Scans", "ScanURLProcessed");
            DropColumn("dbo.Scans", "ScanURL");
        }
    }
}
