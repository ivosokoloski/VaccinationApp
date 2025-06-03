namespace VaccinationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIg2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vaccines", "PatientId", c => c.Int(nullable: false));
            AddColumn("dbo.Vaccines", "VaccinationCenterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vaccines", "PatientId");
            CreateIndex("dbo.Vaccines", "VaccinationCenterId");
            AddForeignKey("dbo.Vaccines", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vaccines", "VaccinationCenterId", "dbo.VaccinationCenters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vaccines", "VaccinationCenterId", "dbo.VaccinationCenters");
            DropForeignKey("dbo.Vaccines", "PatientId", "dbo.Patients");
            DropIndex("dbo.Vaccines", new[] { "VaccinationCenterId" });
            DropIndex("dbo.Vaccines", new[] { "PatientId" });
            DropColumn("dbo.Vaccines", "VaccinationCenterId");
            DropColumn("dbo.Vaccines", "PatientId");
        }
    }
}
