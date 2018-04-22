namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregarareaapersona : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AreaID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "AreaID");
            AddForeignKey("dbo.AspNetUsers", "AreaID", "dbo.Area", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "AreaID", "dbo.Area");
            DropIndex("dbo.AspNetUsers", new[] { "AreaID" });
            DropColumn("dbo.AspNetUsers", "AreaID");
        }
    }
}
