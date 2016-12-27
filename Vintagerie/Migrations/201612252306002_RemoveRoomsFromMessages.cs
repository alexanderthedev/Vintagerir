namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRoomsFromMessages : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "MessageRoomId", "dbo.MessageRooms");
            DropIndex("dbo.Messages", new[] { "MessageRoomId" });
            DropColumn("dbo.Messages", "MessageRoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "MessageRoomId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Messages", "MessageRoomId");
            AddForeignKey("dbo.Messages", "MessageRoomId", "dbo.MessageRooms", "Id", cascadeDelete: true);
        }
    }
}
