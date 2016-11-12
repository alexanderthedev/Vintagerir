namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUSerIdTostringForPictureInfo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PIctureInfoes", new[] { "User_Id" });
            DropColumn("dbo.PIctureInfoes", "UserId");
            RenameColumn(table: "dbo.PIctureInfoes", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.PIctureInfoes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.PIctureInfoes", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PIctureInfoes", new[] { "UserId" });
            AlterColumn("dbo.PIctureInfoes", "UserId", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.PIctureInfoes", name: "UserId", newName: "User_Id");
            AddColumn("dbo.PIctureInfoes", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.PIctureInfoes", "User_Id");
        }
    }
}
