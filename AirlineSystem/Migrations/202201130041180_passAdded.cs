namespace AirlineSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "Password");
        }
    }
}
