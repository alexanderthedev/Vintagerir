namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsernameProductNameTOpictureInfos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PictureInfoes", "UserName", c => c.String());
            AddColumn("dbo.PictureInfoes", "ProductName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PictureInfoes", "ProductName");
            DropColumn("dbo.PictureInfoes", "UserName");
        }
    }
}
