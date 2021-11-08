namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdsToFollowEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FollowedBy", "UserId", c => c.String());
            AddColumn("dbo.Following", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Following", "UserId");
            DropColumn("dbo.FollowedBy", "UserId");
        }
    }
}
