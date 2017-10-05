namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Indicador1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FrecuenciaMedicionIndicador",
                c => new
                    {
                        FrecuenciaMedicionIndicadorID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.FrecuenciaMedicionIndicadorID);
            
            CreateTable(
                "dbo.InteresadoIndicador",
                c => new
                    {
                        InteresadoIndicadorID = c.Int(nullable: false, identity: true),
                        IndicadorID = c.Int(nullable: false),
                        PersonaID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.InteresadoIndicadorID)
                .ForeignKey("dbo.Indicador", t => t.IndicadorID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.PersonaID)
                .Index(t => t.IndicadorID)
                .Index(t => t.PersonaID);
            
            AddColumn("dbo.Indicador", "ObjetivoID", c => c.Int(nullable: false));
            AddColumn("dbo.Indicador", "FrecuenciaMedicionIndicadorID", c => c.Int(nullable: false));
            CreateIndex("dbo.Indicador", "ObjetivoID");
            CreateIndex("dbo.Indicador", "FrecuenciaMedicionIndicadorID");
            AddForeignKey("dbo.Indicador", "FrecuenciaMedicionIndicadorID", "dbo.FrecuenciaMedicionIndicador", "FrecuenciaMedicionIndicadorID", cascadeDelete: true);
            AddForeignKey("dbo.Indicador", "ObjetivoID", "dbo.Objetivo", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Indicador", "ObjetivoID", "dbo.Objetivo");
            DropForeignKey("dbo.InteresadoIndicador", "PersonaID", "dbo.AspNetUsers");
            DropForeignKey("dbo.InteresadoIndicador", "IndicadorID", "dbo.Indicador");
            DropForeignKey("dbo.Indicador", "FrecuenciaMedicionIndicadorID", "dbo.FrecuenciaMedicionIndicador");
            DropIndex("dbo.InteresadoIndicador", new[] { "PersonaID" });
            DropIndex("dbo.InteresadoIndicador", new[] { "IndicadorID" });
            DropIndex("dbo.Indicador", new[] { "FrecuenciaMedicionIndicadorID" });
            DropIndex("dbo.Indicador", new[] { "ObjetivoID" });
            DropColumn("dbo.Indicador", "FrecuenciaMedicionIndicadorID");
            DropColumn("dbo.Indicador", "ObjetivoID");
            DropTable("dbo.InteresadoIndicador");
            DropTable("dbo.FrecuenciaMedicionIndicador");
        }
    }
}
