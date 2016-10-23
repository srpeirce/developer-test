namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedViewingsEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Viewings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        Appointment = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        BuyerUserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Viewings");
        }
    }
}
