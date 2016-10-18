namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeBuyerIdMandatoryForOffer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Offers", "BuyerUserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Offers", "BuyerUserId", c => c.String());
        }
    }
}
