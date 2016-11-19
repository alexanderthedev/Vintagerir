namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPathForImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PictureInfoes", "Path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PictureInfoes", "Path");
        }
    }
}
