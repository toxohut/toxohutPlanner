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
                        Meeting_MeetingId = c.Int(),
                        ExpenseId_ExpenseId = c.Int(),
                        Status_StatusId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Meeting", t => t.Meeting_MeetingId)
                .ForeignKey("dbo.Expense", t => t.ExpenseId_ExpenseId)
                .ForeignKey("dbo.Status", t => t.Status_StatusId)
                .Index(t => t.Meeting_MeetingId)
                .Index(t => t.ExpenseId_ExpenseId)
                .Index(t => t.Status_StatusId);
            
            CreateTable(
                "dbo.Expense",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        PaymentTerm = c.DateTime(nullable: false, storeType: "date"),
                        PaymentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Done = c.Boolean(nullable: false),
                        MeetingId_MeetingId = c.Int(),
                        Provider_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ExpenseId)
                .ForeignKey("dbo.Meeting", t => t.MeetingId_MeetingId)
                .ForeignKey("dbo.User", t => t.Provider_UserId)
                .Index(t => t.MeetingId_MeetingId)
                .Index(t => t.Provider_UserId);
            
            CreateTable(
                "dbo.Meeting",
                c => new
                    {
                        MeetingId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Owner_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.MeetingId)
                .ForeignKey("dbo.User", t => t.Owner_UserId)
                .Index(t => t.Owner_UserId);
            
            CreateTable(
                "dbo.Guest",
                c => new
                    {
                        GuestId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Invited = c.Boolean(nullable: false),
                        Coming = c.Boolean(nullable: false),
                        Status_StatusId = c.Int(),
                        User_UserId = c.Int(),
                        Meeting_MeetingId = c.Int(),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.GuestId)
                .ForeignKey("dbo.Status", t => t.Status_StatusId)
                .ForeignKey("dbo.User", t => t.User_UserId)
                .ForeignKey("dbo.Meeting", t => t.Meeting_MeetingId)
                .ForeignKey("dbo.Event", t => t.Event_EventId)
                .Index(t => t.Status_StatusId)
                .Index(t => t.User_UserId)
                .Index(t => t.Meeting_MeetingId)
                .Index(t => t.Event_EventId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        TableId = c.Int(nullable: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Mail = c.String(unicode: false),
                        PasswordHash = c.String(unicode: false),
                        PasswordSalt = c.String(unicode: false),
                        FirsName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Vote",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        OpenAnswer = c.String(unicode: false),
                        UserId_UserId = c.Int(),
                        VotingAnswerId_VotingAnswerId = c.Int(),
                        VotingId_VotingId = c.Int(),
                    })
                .PrimaryKey(t => t.VoteId)
                .ForeignKey("dbo.User", t => t.UserId_UserId)
                .ForeignKey("dbo.VotingAnswer", t => t.VotingAnswerId_VotingAnswerId)
                .ForeignKey("dbo.Voting", t => t.VotingId_VotingId)
                .Index(t => t.UserId_UserId)
                .Index(t => t.VotingAnswerId_VotingAnswerId)
                .Index(t => t.VotingId_VotingId);
            
            CreateTable(
                "dbo.VotingAnswer",
                c => new
                    {
                        VotingAnswerId = c.Int(nullable: false, identity: true),
                        VotingId = c.Int(nullable: false),
                        AnswerText = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.VotingAnswerId)
                .ForeignKey("dbo.Voting", t => t.VotingId, cascadeDelete: true)
                .Index(t => t.VotingId);
            
            CreateTable(
                "dbo.Voting",
                c => new
                    {
                        VotingId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        IsOpenQuestion = c.Boolean(nullable: false),
                        EventParent_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.VotingId)
                .ForeignKey("dbo.Event", t => t.EventParent_EventId)
                .Index(t => t.EventParent_EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vote", "VotingId_VotingId", "dbo.Voting");
            DropForeignKey("dbo.Vote", "VotingAnswerId_VotingAnswerId", "dbo.VotingAnswer");
            DropForeignKey("dbo.VotingAnswer", "VotingId", "dbo.Voting");
            DropForeignKey("dbo.Voting", "EventParent_EventId", "dbo.Event");
            DropForeignKey("dbo.Vote", "UserId_UserId", "dbo.User");
            DropForeignKey("dbo.Event", "Status_StatusId", "dbo.Status");
            DropForeignKey("dbo.Guest", "Event_EventId", "dbo.Event");
            DropForeignKey("dbo.Event", "ExpenseId_ExpenseId", "dbo.Expense");
            DropForeignKey("dbo.Expense", "Provider_UserId", "dbo.User");
            DropForeignKey("dbo.Meeting", "Owner_UserId", "dbo.User");
            DropForeignKey("dbo.Guest", "Meeting_MeetingId", "dbo.Meeting");
            DropForeignKey("dbo.Guest", "User_UserId", "dbo.User");
            DropForeignKey("dbo.Guest", "Status_StatusId", "dbo.Status");
            DropForeignKey("dbo.Expense", "MeetingId_MeetingId", "dbo.Meeting");
            DropForeignKey("dbo.Event", "Meeting_MeetingId", "dbo.Meeting");
            DropIndex("dbo.Voting", new[] { "EventParent_EventId" });
            DropIndex("dbo.VotingAnswer", new[] { "VotingId" });
            DropIndex("dbo.Vote", new[] { "VotingId_VotingId" });
            DropIndex("dbo.Vote", new[] { "VotingAnswerId_VotingAnswerId" });
            DropIndex("dbo.Vote", new[] { "UserId_UserId" });
            DropIndex("dbo.Guest", new[] { "Event_EventId" });
            DropIndex("dbo.Guest", new[] { "Meeting_MeetingId" });
            DropIndex("dbo.Guest", new[] { "User_UserId" });
            DropIndex("dbo.Guest", new[] { "Status_StatusId" });
            DropIndex("dbo.Meeting", new[] { "Owner_UserId" });
            DropIndex("dbo.Expense", new[] { "Provider_UserId" });
            DropIndex("dbo.Expense", new[] { "MeetingId_MeetingId" });
            DropIndex("dbo.Event", new[] { "Status_StatusId" });
            DropIndex("dbo.Event", new[] { "ExpenseId_ExpenseId" });
            DropIndex("dbo.Event", new[] { "Meeting_MeetingId" });
            DropTable("dbo.Voting");
            DropTable("dbo.VotingAnswer");
            DropTable("dbo.Vote");
            DropTable("dbo.User");
            DropTable("dbo.Status");
            DropTable("dbo.Guest");
            DropTable("dbo.Meeting");
            DropTable("dbo.Expense");
            DropTable("dbo.Event");
        }
    }
}
