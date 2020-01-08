namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoolMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PickupConfirmation", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PickupConfirmation", c => c.String());
        }
    }
}
