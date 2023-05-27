namespace AirlineSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ed3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Payments", "CardId", c => c.String(nullable: false, maxLength: 16));
            AddPrimaryKey("dbo.Payments", "CardId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Payments", "CardId", c => c.String(nullable: false, maxLength: 17));
            AddPrimaryKey("dbo.Payments", "CardId");
        }
    }
}
