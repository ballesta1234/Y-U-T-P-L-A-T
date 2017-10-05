namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Indicador : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Indicador",
                c => new
                    {
                        IndicadorID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        FechaCreacion = c.DateTime(),
                        UltimoUsuarioModifico = c.String(),
                        FechaUltimaModificacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.IndicadorID);
            
            CreateTable(
                "dbo.ResponsableIndicador",
                c => new
                    {
                        ResponsableIndicadorID = c.Int(nullable: false, identity: true),
                        IndicadorID = c.Int(nullable: false),
                        PersonaID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ResponsableIndicadorID)
                .ForeignKey("dbo.Indicador", t => t.IndicadorID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.PersonaID)
                .Index(t => t.IndicadorID)
                .Index(t => t.PersonaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResponsableIndicador", "PersonaID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ResponsableIndicador", "IndicadorID", "dbo.Indicador");
            DropIndex("dbo.ResponsableIndicador", new[] { "PersonaID" });
            DropIndex("dbo.ResponsableIndicador", new[] { "IndicadorID" });
            DropTable("dbo.ResponsableIndicador");
            DropTable("dbo.Indicador");
        }
    }
}
