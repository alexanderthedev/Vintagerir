namespace Vintagerie.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class changeBoolOfWorldwide : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "DeliverWorldwide", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "DeliverWorldwide", c => c.Boolean());
        }
    }
}
