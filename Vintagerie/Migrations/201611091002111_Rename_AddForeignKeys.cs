namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename_AddForeignKeys : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "ProductCategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.Products", name: "IX_Category_Id", newName: "IX_ProductCategoryId");
            AddColumn("dbo.Products", "TimeAdded", c => c.DateTime(nullable: false));
            DropColumn("dbo.Products", "TimeAdde");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "TimeAdde", c => c.DateTime(nullable: false));
            DropColumn("dbo.Products", "TimeAdded");
            RenameIndex(table: "dbo.Products", name: "IX_ProductCategoryId", newName: "IX_Category_Id");
            RenameIndex(table: "dbo.Products", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Products", name: "ProductCategoryId", newName: "Category_Id");
            RenameColumn(table: "dbo.Products", name: "UserId", newName: "User_Id");
        }
    }
}
