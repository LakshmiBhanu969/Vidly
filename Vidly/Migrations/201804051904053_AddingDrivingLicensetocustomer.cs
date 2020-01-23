namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDrivingLicensetocustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DrivingLicense", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DrivingLicense");
        }
    }
}
