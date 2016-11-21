namespace Vintagerie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContentToMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Content");
        }
    }
}
