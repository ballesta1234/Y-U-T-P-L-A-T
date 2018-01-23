namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Medicion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicion",
                c => new
                    {
                        MedicionId = c.Int(nullable: false, identity: true),
                        IndicadorID = c.Int(nullable: false),
                        Mes = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 3),
                        FechaCarga = c.DateTime(),
                        UsuarioCargo = c.String(),
                    })
                .PrimaryKey(t => t.MedicionId)
                .ForeignKey("dbo.Indicador", t => t.IndicadorID, cascadeDelete: true)
                .Index(t => t.IndicadorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicion", "IndicadorID", "dbo.Indicador");
            DropIndex("dbo.Medicion", new[] { "IndicadorID" });
            DropTable("dbo.Medicion");
        }
    }
}
