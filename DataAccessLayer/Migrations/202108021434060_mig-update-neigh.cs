namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migupdateneigh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Neighborhoods", "NeighborhoodCoordinate", c => c.String());
            DropColumn("dbo.Neighborhoods", "NeighborhoodNameCoordinate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Neighborhoods", "NeighborhoodNameCoordinate", c => c.String());
            DropColumn("dbo.Neighborhoods", "NeighborhoodCoordinate");
        }
    }
}
