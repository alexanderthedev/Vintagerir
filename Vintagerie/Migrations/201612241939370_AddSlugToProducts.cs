namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSlugToProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Slug", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Slug");
        }
    }
}
