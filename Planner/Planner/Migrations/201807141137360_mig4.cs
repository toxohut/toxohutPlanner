namespace Planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Meeting", "UserOwnerId", "User");
            DropIndex("Meeting", new[] { "UserOwnerId" });
            DropColumn("Meeting", "UserOwnerId");
        }
        
        public override void Down()
        {
            AddColumn("Meeting", "UserOwnerId", c => c.Int(nullable: false));
            CreateIndex("Meeting", "UserOwnerId");
            AddForeignKey("Meeting", "UserOwnerId", "User", "UserId", cascadeDelete: true);
        }
    }
}
