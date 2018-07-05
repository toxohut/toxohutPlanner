namespace Planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Meeting",
                c => new
                    {
                        MeetingId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.MeetingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Meeting");
            DropTable("dbo.Event");
        }
    }
}
