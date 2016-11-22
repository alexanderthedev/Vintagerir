namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToMessages : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropPrimaryKey("dbo.Messages");
            AddColumn("dbo.Messages", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Messages", "SenderId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Messages", "Id");
            CreateIndex("dbo.Messages", "SenderId");
            AddForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropPrimaryKey("dbo.Messages");
            AlterColumn("dbo.Messages", "SenderId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Messages", "Id");
            AddPrimaryKey("dbo.Messages", new[] { "SenderId", "ReceiverId" });
            CreateIndex("dbo.Messages", "SenderId");
            AddForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
