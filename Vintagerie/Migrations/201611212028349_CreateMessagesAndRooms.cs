namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMessagesAndRooms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageRooms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserAId = c.String(maxLength: 128),
                        UserBId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserBId)
                .Index(t => t.UserAId)
                .Index(t => t.UserBId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        SenderId = c.String(nullable: false, maxLength: 128),
                        ReceiverId = c.String(nullable: false, maxLength: 128),
                        MessageRoomId = c.Guid(nullable: false),
                        TimeSent = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.SenderId, t.ReceiverId })
                .ForeignKey("dbo.MessageRooms", t => t.MessageRoomId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ReceiverId)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId, cascadeDelete: true)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId)
                .Index(t => t.MessageRoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "ReceiverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "MessageRoomId", "dbo.MessageRooms");
            DropForeignKey("dbo.MessageRooms", "UserBId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MessageRooms", "UserAId", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "MessageRoomId" });
            DropIndex("dbo.Messages", new[] { "ReceiverId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropIndex("dbo.MessageRooms", new[] { "UserBId" });
            DropIndex("dbo.MessageRooms", new[] { "UserAId" });
            DropTable("dbo.Messages");
            DropTable("dbo.MessageRooms");
        }
    }
}
