namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditUserDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Description", c => c.String());
            AddColumn("dbo.AspNetUsers", "CountryName", c => c.String());
            AddColumn("dbo.AspNetUsers", "DeliverWorldwide", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "PhotoProFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PhotoProFileName");
            DropColumn("dbo.AspNetUsers", "DeliverWorldwide");
            DropColumn("dbo.AspNetUsers", "CountryName");
            DropColumn("dbo.AspNetUsers", "Description");
        }
    }
}
