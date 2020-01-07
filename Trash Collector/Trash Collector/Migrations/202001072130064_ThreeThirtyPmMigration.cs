namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThreeThirtyPmMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PickUpDay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PickUpDay", c => c.String());
        }
    }
}
