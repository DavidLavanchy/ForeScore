namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFullNameToFollowingEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FollowedBy", "FullName", c => c.String());
            AddColumn("dbo.Following", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Following", "FullName");
            DropColumn("dbo.FollowedBy", "FullName");
        }
    }
}
