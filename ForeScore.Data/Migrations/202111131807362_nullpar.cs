namespace ForeScore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullpar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HoleData", "HolePar", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HoleData", "HolePar", c => c.Int(nullable: false));
        }
    }
}
