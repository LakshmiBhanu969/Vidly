namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT dbo.MembershipTypes ON");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate) VALUES (1,0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate) VALUES (2,30,1,5)");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate) VALUES (3,90,3,15)");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate) VALUES (4,300,12,20)");
            Sql("SET IDENTITY_INSERT dbo.MembershipTypes OFF");
        }
        
        public override void Down()
        {
        }
    }
}
