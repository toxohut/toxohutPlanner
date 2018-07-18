namespace Planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("User", "Event_EventId", "Event");
            DropIndex("User", new[] { "Event_EventId" });
            CreateTable(
                "Guest",
                c => new
                    {
                        GuestId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Invited = c.Boolean(nullable: false),
                        Coming = c.Boolean(nullable: false),
                        Status_StatusId = c.Int(),
                        User_UserId = c.Int(),
                        Event_EventId = c.Int(),
                        Meeting_MeetingId = c.Int(),
                    })
                .PrimaryKey(t => t.GuestId)
                .ForeignKey("Status", t => t.Status_StatusId)
                .ForeignKey("User", t => t.User_UserId)
                .ForeignKey("Event", t => t.Event_EventId)
                .ForeignKey("Meeting", t => t.Meeting_MeetingId)
                .Index(t => t.Status_StatusId)
                .Index(t => t.User_UserId)
                .Index(t => t.Event_EventId)
                .Index(t => t.Meeting_MeetingId);
            
            CreateTable(
                "Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.StatusId);
            
            AddColumn("Event", "Status_StatusId", c => c.Int());
            AddColumn("Meeting", "Description", c => c.String(unicode: false));
            AddColumn("Meeting", "Owner_UserId", c => c.Int());
            CreateIndex("Event", "Status_StatusId");
            CreateIndex("Meeting", "Owner_UserId");
            AddForeignKey("Meeting", "Owner_UserId", "User", "UserId");
            AddForeignKey("Event", "Status_StatusId", "Status", "StatusId");
            DropColumn("User", "Event_EventId");
        }
        
        public override void Down()
        {
            AddColumn("User", "Event_EventId", c => c.Int());
            DropForeignKey("Event", "Status_StatusId", "Status");
            DropForeignKey("Meeting", "Owner_UserId", "User");
            DropForeignKey("Guest", "Meeting_MeetingId", "Meeting");
            DropForeignKey("Guest", "Event_EventId", "Event");
            DropForeignKey("Guest", "User_UserId", "User");
            DropForeignKey("Guest", "Status_StatusId", "Status");
            DropIndex("Meeting", new[] { "Owner_UserId" });
            DropIndex("Guest", new[] { "Meeting_MeetingId" });
            DropIndex("Guest", new[] { "Event_EventId" });
            DropIndex("Guest", new[] { "User_UserId" });
            DropIndex("Guest", new[] { "Status_StatusId" });
            DropIndex("Event", new[] { "Status_StatusId" });
            DropColumn("Meeting", "Owner_UserId");
            DropColumn("Meeting", "Description");
            DropColumn("Event", "Status_StatusId");
            DropTable("Status");
            DropTable("Guest");
            CreateIndex("User", "Event_EventId");
            AddForeignKey("User", "Event_EventId", "Event", "EventId");
        }
    }
}
