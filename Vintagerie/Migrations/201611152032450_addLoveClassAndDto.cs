namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLoveClassAndDto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LovesUserToStores",
                c => new
                    {
                        LovedId = c.String(nullable: false, maxLength: 128),
                        LoverUserId = c.String(nullable: false, maxLength: 128),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.LovedId, t.LoverUserId })
                .ForeignKey("dbo.AspNetUsers", t => t.LovedId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.LoverUserId)
                .Index(t => t.LovedId)
                .Index(t => t.LoverUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LovesUserToStores", "LoverUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LovesUserToStores", "LovedId", "dbo.AspNetUsers");
            DropIndex("dbo.LovesUserToStores", new[] { "LoverUserId" });
            DropIndex("dbo.LovesUserToStores", new[] { "LovedId" });
            DropTable("dbo.LovesUserToStores");
        }
    }
}
