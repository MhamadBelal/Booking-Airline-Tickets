namespace AirlineSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedproject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "TripId", "dbo.Trips");
            DropIndex("dbo.Tickets", new[] { "TripId" });
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Payments", "CardId", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.Payments", "NameCard", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "EndDate", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "CVV", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "PhoneNo", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Tickets", "TripId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Trips", "Acual_depature", c => c.String(nullable: false));
            AlterColumn("dbo.Trips", "Acual_Arrival", c => c.String(nullable: false));
            AlterColumn("dbo.Trips", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.ScheduleTrips", "PlaceFrom", c => c.String(nullable: false));
            AlterColumn("dbo.ScheduleTrips", "PlaceTo", c => c.String(nullable: false));
            AlterColumn("dbo.ScheduleTrips", "Depature_Time", c => c.String(nullable: false));
            AlterColumn("dbo.ScheduleTrips", "Arrival_Time", c => c.String(nullable: false));
            AlterColumn("dbo.ScheduleTrips", "TripName", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Payments", "CardId");
            CreateIndex("dbo.Tickets", "TripId");
            AddForeignKey("dbo.Tickets", "TripId", "dbo.Trips", "TripId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TripId", "dbo.Trips");
            DropIndex("dbo.Tickets", new[] { "TripId" });
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.ScheduleTrips", "TripName", c => c.String());
            AlterColumn("dbo.ScheduleTrips", "Arrival_Time", c => c.String());
            AlterColumn("dbo.ScheduleTrips", "Depature_Time", c => c.String());
            AlterColumn("dbo.ScheduleTrips", "PlaceTo", c => c.String());
            AlterColumn("dbo.ScheduleTrips", "PlaceFrom", c => c.String());
            AlterColumn("dbo.Trips", "Date", c => c.String());
            AlterColumn("dbo.Trips", "Acual_Arrival", c => c.String());
            AlterColumn("dbo.Trips", "Acual_depature", c => c.String());
            AlterColumn("dbo.Tickets", "TripId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Users", "Gender", c => c.String());
            AlterColumn("dbo.Users", "PhoneNo", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Payments", "CVV", c => c.String());
            AlterColumn("dbo.Payments", "EndDate", c => c.String());
            AlterColumn("dbo.Payments", "NameCard", c => c.String());
            AlterColumn("dbo.Payments", "CardId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Payments", "CardId");
            CreateIndex("dbo.Tickets", "TripId");
            AddForeignKey("dbo.Tickets", "TripId", "dbo.Trips", "TripId");
        }
    }
}
