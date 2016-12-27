namespace Vintagerie.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MessageRooms", "UserAId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MessageRooms", "UserBId", "dbo.AspNetUsers");
            DropIndex("dbo.MessageRooms", new[] { "UserAId" });
            DropIndex("dbo.MessageRooms", new[] { "UserBId" });
            DropTable("dbo.MessageRooms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MessageRooms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserAId = c.String(maxLength: 128),
                        UserBId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.MessageRooms", "UserBId");
            CreateIndex("dbo.MessageRooms", "UserAId");
            AddForeignKey("dbo.MessageRooms", "UserBId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.MessageRooms", "UserAId", "dbo.AspNetUsers", "Id");
        }
    }
}
