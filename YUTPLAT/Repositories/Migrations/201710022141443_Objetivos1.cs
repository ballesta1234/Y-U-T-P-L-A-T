namespace YUTPLAT.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Objetivos1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Objetivo", "AreaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Objetivo", "AreaID");
            AddForeignKey("dbo.Objetivo", "AreaID", "dbo.Area", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Objetivo", "AreaID", "dbo.Area");
            DropIndex("dbo.Objetivo", new[] { "AreaID" });
            DropColumn("dbo.Objetivo", "AreaID");
        }
    }
}
