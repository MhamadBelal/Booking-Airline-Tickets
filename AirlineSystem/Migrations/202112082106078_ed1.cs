namespace AirlineSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ed1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Payments", "CardId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Payments", "CardId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Payments", "CardId", c => c.String(nullable: false, maxLength: 16));
            AddPrimaryKey("dbo.Payments", "CardId");
        }
    }
}
