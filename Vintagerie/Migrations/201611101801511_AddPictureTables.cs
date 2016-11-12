namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPictureTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PIctureInfoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                        ImageName = c.String(),
                        IsFeautured = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.ProductId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PIctureInfoes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PIctureInfoes", "ProductId", "dbo.Products");
            DropIndex("dbo.PIctureInfoes", new[] { "User_Id" });
            DropIndex("dbo.PIctureInfoes", new[] { "ProductId" });
            DropTable("dbo.PIctureInfoes");
        }
    }
}
