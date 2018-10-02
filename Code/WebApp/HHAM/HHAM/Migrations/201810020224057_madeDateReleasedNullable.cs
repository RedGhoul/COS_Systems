namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeDateReleasedNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "DateAdmited", c => c.DateTime());
            AlterColumn("dbo.Patients", "DateReleased", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "DateReleased", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Patients", "DateAdmited", c => c.DateTime(nullable: false));
        }
    }
}
