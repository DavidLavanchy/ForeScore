namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsFeaturedProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Round", "IsFeatured", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Round", "IsFeatured");
        }
    }
}
