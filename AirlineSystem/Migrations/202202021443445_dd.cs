namespace AirlineSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "Money", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "Money");
        }
    }
}
