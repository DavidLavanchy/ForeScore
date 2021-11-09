namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FollowedBy : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.FollowedBy", "FollowingId", "FollowedById");
            
        }
        
        public override void Down()
        {

        }
    }
}
