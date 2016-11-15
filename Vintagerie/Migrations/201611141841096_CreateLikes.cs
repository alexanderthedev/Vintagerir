namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateLikes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LikeUserToProducts",
                c => new
                    {
                        ProductLikedId = c.Int(nullable: false),
                        LikerId = c.String(nullable: false, maxLength: 128),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductLikedId, t.LikerId })
                .ForeignKey("dbo.AspNetUsers", t => t.LikerId)
                .ForeignKey("dbo.Products", t => t.ProductLikedId, cascadeDelete: true)
                .Index(t => t.ProductLikedId)
                .Index(t => t.LikerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LikeUserToProducts", "ProductLikedId", "dbo.Products");
            DropForeignKey("dbo.LikeUserToProducts", "LikerId", "dbo.AspNetUsers");
            DropIndex("dbo.LikeUserToProducts", new[] { "LikerId" });
            DropIndex("dbo.LikeUserToProducts", new[] { "ProductLikedId" });
            DropTable("dbo.LikeUserToProducts");
        }
    }
}
