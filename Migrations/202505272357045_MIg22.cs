namespace VaccinationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIg22 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "LastName", c => c.String());
            AlterColumn("dbo.Patients", "FirstName", c => c.String());
        }
    }
}
