namespace AirlineSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trips", "ScTripId", "dbo.ScheduleTrips");
            DropIndex("dbo.Trips", new[] { "ScTripId" });
            RenameColumn(table: "dbo.Trips", name: "ScTripId", newName: "TripName");
            DropPrimaryKey("dbo.ScheduleTrips");
            AlterColumn("dbo.Trips", "TripName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ScheduleTrips", "TripName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ScheduleTrips", "TripName");
            CreateIndex("dbo.Trips", "TripName");
            AddForeignKey("dbo.Trips", "TripName", "dbo.ScheduleTrips", "TripName", cascadeDelete: true);
            DropColumn("dbo.ScheduleTrips", "ScTripId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ScheduleTrips", "ScTripId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Trips", "TripName", "dbo.ScheduleTrips");
            DropIndex("dbo.Trips", new[] { "TripName" });
            DropPrimaryKey("dbo.ScheduleTrips");
            AlterColumn("dbo.ScheduleTrips", "TripName", c => c.String(nullable: false));
            AlterColumn("dbo.Trips", "TripName", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ScheduleTrips", "ScTripId");
            RenameColumn(table: "dbo.Trips", name: "TripName", newName: "ScTripId");
            CreateIndex("dbo.Trips", "ScTripId");
            AddForeignKey("dbo.Trips", "ScTripId", "dbo.ScheduleTrips", "ScTripId", cascadeDelete: true);
        }
    }
}
