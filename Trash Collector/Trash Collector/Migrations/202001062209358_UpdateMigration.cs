namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Employees");
            AddColumn("dbo.Customers", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Employees", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Customers", "PickUpDay", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            AddPrimaryKey("dbo.Customers", "id");
            AddPrimaryKey("dbo.Employees", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Employees");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Customers", "PickUpDay", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Employees", "id");
            DropColumn("dbo.Customers", "id");
            AddPrimaryKey("dbo.Employees", "FirstName");
            AddPrimaryKey("dbo.Customers", "PickUpDay");
        }
    }
}
