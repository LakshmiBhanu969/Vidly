using System.Data.Entity.Migrations.Model;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberinStocktoMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
          //  AlterColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));

           // Sql("Update Movies set NumberAvailable =NumberInStock ");
        }
        
        public override void Down()
        {
           // AlterColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
