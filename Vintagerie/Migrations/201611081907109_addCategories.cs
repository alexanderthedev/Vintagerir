namespace Vintagerie.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ProductCategories VALUES (1,'Clothes')");
            Sql("INSERT INTO ProductCategories VALUES (2,'Shoes')");
            Sql("INSERT INTO ProductCategories VALUES (3,'Jewelleries')");
            Sql("INSERT INTO ProductCategories VALUES (4,'Accessories')");
            Sql("INSERT INTO ProductCategories VALUES (5,'Other')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM ProductCategories WHERE Id IN (1,2,3,4,5)");

        }
    }
}
