namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecentMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "ExtraPickUpDate", c => c.String());
            AlterColumn("dbo.Customers", "SuspendedStart", c => c.String());
            AlterColumn("dbo.Customers", "SuspectedEnd", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "SuspectedEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "SuspendedStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "ExtraPickUpDate", c => c.DateTime(nullable: false));
        }
    }
}
