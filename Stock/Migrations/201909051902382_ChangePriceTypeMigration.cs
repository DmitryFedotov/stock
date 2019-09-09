namespace Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePriceTypeMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "PriceForOne", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "PriceForOne", c => c.String());
        }
    }
}
