namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "Name", c => c.String());
            AddColumn("dbo.Post", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "Name");
            DropColumn("dbo.Comment", "Name");
        }
    }
}
