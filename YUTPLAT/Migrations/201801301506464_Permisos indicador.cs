namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Permisosindicador : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccesoIndicador",
                c => new
                    {
                        AccesoIndicadorID = c.Int(nullable: false, identity: true),
                        IndicadorID = c.Int(nullable: false),
                        PersonaID = c.String(maxLength: 128),
                        PermisoIndicador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccesoIndicadorID)
                .ForeignKey("dbo.Indicador", t => t.IndicadorID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.PersonaID)
                .Index(t => t.IndicadorID)
                .Index(t => t.PersonaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccesoIndicador", "PersonaID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AccesoIndicador", "IndicadorID", "dbo.Indicador");
            DropIndex("dbo.AccesoIndicador", new[] { "PersonaID" });
            DropIndex("dbo.AccesoIndicador", new[] { "IndicadorID" });
            DropTable("dbo.AccesoIndicador");
        }
    }
}
