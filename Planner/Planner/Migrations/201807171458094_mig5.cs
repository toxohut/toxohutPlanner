namespace Planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Password", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Password");
        }
    }
}
