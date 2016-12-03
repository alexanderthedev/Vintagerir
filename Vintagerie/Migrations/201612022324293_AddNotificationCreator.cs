namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotificationCreator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "CreatorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Notifications", "CreatorId");
            AddForeignKey("dbo.Notifications", "CreatorId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "CreatorId", "dbo.AspNetUsers");
            DropIndex("dbo.Notifications", new[] { "CreatorId" });
            DropColumn("dbo.Notifications", "CreatorId");
        }
    }
}
