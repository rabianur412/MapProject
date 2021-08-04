namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migupdateneighborhoodid : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Gates", name: "PostCode", newName: "NeighborhoodId");
            RenameIndex(table: "dbo.Gates", name: "IX_PostCode", newName: "IX_NeighborhoodId");
            DropColumn("dbo.Neighborhoods", "PostCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Neighborhoods", "PostCode", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Gates", name: "IX_NeighborhoodId", newName: "IX_PostCode");
            RenameColumn(table: "dbo.Gates", name: "NeighborhoodId", newName: "PostCode");
        }
    }
}
