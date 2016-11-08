namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredOnProducts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.ProductCategories");
            DropForeignKey("dbo.Products", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Products", new[] { "User_Id" });
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Category_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Products", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Products", "Category_Id");
            CreateIndex("dbo.Products", "User_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.ProductCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.ProductCategories");
            DropIndex("dbo.Products", new[] { "User_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            AlterColumn("dbo.Products", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Products", "Category_Id", c => c.Byte());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            CreateIndex("dbo.Products", "User_Id");
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.ProductCategories", "Id");
        }
    }
}
