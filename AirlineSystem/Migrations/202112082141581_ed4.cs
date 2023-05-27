namespace AirlineSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ed4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "TripId", "dbo.Trips");
            DropIndex("dbo.Tickets", new[] { "TripId" });
            DropPrimaryKey("dbo.Trips");
            AlterColumn("dbo.Tickets", "TripId", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Trips", "TripId", c => c.String(nullable: false, maxLength: 10));
            AddPrimaryKey("dbo.Trips", "TripId");
            CreateIndex("dbo.Tickets", "TripId");
            AddForeignKey("dbo.Tickets", "TripId", "dbo.Trips", "TripId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TripId", "dbo.Trips");
            DropIndex("dbo.Tickets", new[] { "TripId" });
            DropPrimaryKey("dbo.Trips");
            AlterColumn("dbo.Trips", "TripId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Tickets", "TripId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Trips", "TripId");
            CreateIndex("dbo.Tickets", "TripId");
            AddForeignKey("dbo.Tickets", "TripId", "dbo.Trips", "TripId", cascadeDelete: true);
        }
    }
}
