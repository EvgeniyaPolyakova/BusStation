namespace Bus_Station.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingisActivecolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Route_Station", "isActive", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Route_Station", "isActive");
        }
    }
}
