namespace Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductArrivalsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductArrivals", "Information", c => c.String());
            AlterColumn("dbo.ProductArrivals", "ProductAmount", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductArrivals", "ProductPriceForOne", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductArrivals", "ProductPriceForOne", c => c.String());
            AlterColumn("dbo.ProductArrivals", "ProductAmount", c => c.String());
            DropColumn("dbo.ProductArrivals", "Information");
        }
    }
}
