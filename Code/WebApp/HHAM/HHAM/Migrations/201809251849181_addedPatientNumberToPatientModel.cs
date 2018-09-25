namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPatientNumberToPatientModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "PatientNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "PatientNumber");
        }
    }
}
