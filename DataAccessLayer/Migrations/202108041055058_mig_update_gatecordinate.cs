namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_gatecordinate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gates", "GateCoordinate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gates", "GateCoordinate", c => c.Int(nullable: false));
        }
    }
}
