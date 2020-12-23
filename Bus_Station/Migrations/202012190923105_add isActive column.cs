namespace Bus_Station.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addisActivecolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trip_Route", "isActive", c => c.Byte());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trip_Route", "isActive");
        }
    }
}
