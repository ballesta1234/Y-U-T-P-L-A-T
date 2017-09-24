namespace YUTPLAT.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Areas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Area",
                c => new
                    {
                        AreaID = c.Int(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.AreaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Area");
        }
    }
}
