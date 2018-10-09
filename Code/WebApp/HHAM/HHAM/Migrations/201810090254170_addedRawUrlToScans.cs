namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRawUrlToScans : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scans", "RAW_URL", c => c.String());
            DropColumn("dbo.Scans", "DICOM_URL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scans", "DICOM_URL", c => c.String());
            DropColumn("dbo.Scans", "RAW_URL");
        }
    }
}
