namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gates", "PostCode", "dbo.Neighborhoods");
            DropPrimaryKey("dbo.Neighborhoods");
            AddColumn("dbo.Neighborhoods", "NeighborhoodId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Neighborhoods", "PostCode", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Neighborhoods", "NeighborhoodId");
            AddForeignKey("dbo.Gates", "PostCode", "dbo.Neighborhoods", "NeighborhoodId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gates", "PostCode", "dbo.Neighborhoods");
            DropPrimaryKey("dbo.Neighborhoods");
            AlterColumn("dbo.Neighborhoods", "PostCode", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Neighborhoods", "NeighborhoodId");
            AddPrimaryKey("dbo.Neighborhoods", "PostCode");
            AddForeignKey("dbo.Gates", "PostCode", "dbo.Neighborhoods", "PostCode", cascadeDelete: true);
        }
    }
}
