namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nuevatablaindicadorautomatico : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IndicadorAutomatico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        IndicadorID = c.Int(nullable: false),
                        CategoriaIndicadorAutomatico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Indicador", t => t.IndicadorID, cascadeDelete: false)
                .Index(t => t.IndicadorID);
            
            DropColumn("dbo.Indicador", "EsAutomatico");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Indicador", "EsAutomatico", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.IndicadorAutomatico", "IndicadorID", "dbo.Indicador");
            DropIndex("dbo.IndicadorAutomatico", new[] { "IndicadorID" });
            DropTable("dbo.IndicadorAutomatico");
        }
    }
}
