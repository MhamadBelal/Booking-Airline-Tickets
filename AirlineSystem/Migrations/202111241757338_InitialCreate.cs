namespace AirlineSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        CardId = c.String(nullable: false, maxLength: 128),
                        NameCard = c.String(),
                        EndDate = c.String(),
                        CVV = c.String(),
                        UsereId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.Users", t => t.UsereId, cascadeDelete: true)
                .Index(t => t.UsereId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                        PhoneNo = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        TripId = c.String(maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Trips", t => t.TripId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TripId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        TripId = c.String(nullable: false, maxLength: 128),
                        Avaliable = c.Int(nullable: false),
                        Acual_depature = c.String(),
                        Acual_Arrival = c.String(),
                        Acual_Duration = c.String(),
                        Date = c.String(),
                        price = c.Int(nullable: false),
                        ScTripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TripId)
                .ForeignKey("dbo.ScheduleTrips", t => t.ScTripId, cascadeDelete: true)
                .Index(t => t.ScTripId);
            
            CreateTable(
                "dbo.ScheduleTrips",
                c => new
                    {
                        ScTripId = c.Int(nullable: false, identity: true),
                        PlaceFrom = c.String(),
                        PlaceTo = c.String(),
                        Depature_Time = c.String(),
                        Arrival_Time = c.String(),
                        NoP = c.Int(nullable: false),
                        TripName = c.String(),
                        Duration = c.String(),
                    })
                .PrimaryKey(t => t.ScTripId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "UsereId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "TripId", "dbo.Trips");
            DropForeignKey("dbo.Trips", "ScTripId", "dbo.ScheduleTrips");
            DropIndex("dbo.Trips", new[] { "ScTripId" });
            DropIndex("dbo.Tickets", new[] { "UserId" });
            DropIndex("dbo.Tickets", new[] { "TripId" });
            DropIndex("dbo.Payments", new[] { "UsereId" });
            DropTable("dbo.ScheduleTrips");
            DropTable("dbo.Trips");
            DropTable("dbo.Tickets");
            DropTable("dbo.Users");
            DropTable("dbo.Payments");
        }
    }
}
