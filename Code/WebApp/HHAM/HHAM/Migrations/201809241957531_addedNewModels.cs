namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNewModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Patients", "Married", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "PrimaryAddress", c => c.String());
            AddColumn("dbo.Patients", "SecondaryAddress", c => c.String());
            AddColumn("dbo.Patients", "BloodType_Id", c => c.Int());
            CreateIndex("dbo.Patients", "BloodType_Id");
            AddForeignKey("dbo.Patients", "BloodType_Id", "dbo.BloodTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "BloodType_Id", "dbo.BloodTypes");
            DropIndex("dbo.Patients", new[] { "BloodType_Id" });
            DropColumn("dbo.Patients", "BloodType_Id");
            DropColumn("dbo.Patients", "SecondaryAddress");
            DropColumn("dbo.Patients", "PrimaryAddress");
            DropColumn("dbo.Patients", "Married");
            DropTable("dbo.BloodTypes");
        }
    }
}
