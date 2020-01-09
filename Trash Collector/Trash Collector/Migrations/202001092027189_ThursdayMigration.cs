namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThursdayMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PickUpDay", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PickUpDay", c => c.Int(nullable: false));
        }
    }
}
