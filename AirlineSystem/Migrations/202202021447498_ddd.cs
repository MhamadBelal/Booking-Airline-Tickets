namespace AirlineSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "Money", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "Money", c => c.String(nullable: false));
        }
    }
}
