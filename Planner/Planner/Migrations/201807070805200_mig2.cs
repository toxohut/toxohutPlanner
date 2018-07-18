namespace Planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "Meeting_MeetingId", c => c.Int());
            CreateIndex("dbo.Event", "Meeting_MeetingId");
            AddForeignKey("dbo.Event", "Meeting_MeetingId", "dbo.Meeting", "MeetingId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "Meeting_MeetingId", "dbo.Meeting");
            DropIndex("dbo.Event", new[] { "Meeting_MeetingId" });
            DropColumn("dbo.Event", "Meeting_MeetingId");
        }
    }
}
