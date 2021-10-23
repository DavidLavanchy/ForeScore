namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeeTimeEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeeTime", "DateOfTeeTime", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.TeeTime", "DateCreated");
            DropColumn("dbo.TeeTime", "DateModified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TeeTime", "DateModified", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.TeeTime", "DateCreated", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.TeeTime", "DateOfTeeTime");
        }
    }
}
