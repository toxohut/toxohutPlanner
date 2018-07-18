namespace Planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirsName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        Mail = c.String(unicode: false),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Event", t => t.Event_EventId)
                .Index(t => t.Event_EventId);
            
            AddColumn("dbo.Meeting", "UserOwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Meeting", "UserOwnerId");
            AddForeignKey("dbo.Meeting", "UserOwnerId", "dbo.User", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Event_EventId", "dbo.Event");
            DropForeignKey("dbo.Meeting", "UserOwnerId", "dbo.User");
            DropIndex("dbo.User", new[] { "Event_EventId" });
            DropIndex("dbo.Meeting", new[] { "UserOwnerId" });
            DropColumn("dbo.Meeting", "UserOwnerId");
            DropTable("dbo.User");
        }
    }
}
