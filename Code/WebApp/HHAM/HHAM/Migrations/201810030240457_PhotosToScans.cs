namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotosToScans : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Photos", newName: "Scans");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Scans", newName: "Photos");
        }
    }
}
