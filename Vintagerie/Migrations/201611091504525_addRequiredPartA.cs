namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequiredPartA : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ProductDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductDescription", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
        }
    }
}
