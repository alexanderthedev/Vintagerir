namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRequires : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Products", new[] { "UserId" });
            AlterColumn("dbo.Products", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            CreateIndex("dbo.Products", "UserId");
            AddForeignKey("dbo.Products", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Products", new[] { "UserId" });
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Products", "UserId");
            AddForeignKey("dbo.Products", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
