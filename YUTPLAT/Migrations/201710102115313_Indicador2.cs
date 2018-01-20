namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Indicador2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meta",
                c => new
                    {
                        MetaId = c.Int(nullable: false, identity: true),
                        Valor1 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Valor2 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Signo1 = c.Int(nullable: false),
                        Signo2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MetaId);
            
            AddColumn("dbo.Indicador", "MetaInaceptableMetaID", c => c.Int());
            AddColumn("dbo.Indicador", "MetaAMejorarMetaID", c => c.Int());
            AddColumn("dbo.Indicador", "MetaAceptableMetaID", c => c.Int());
            AddColumn("dbo.Indicador", "MetaSatisfactoriaMetaID", c => c.Int());
            AddColumn("dbo.Indicador", "MetaExcelenteMetaID", c => c.Int());
            CreateIndex("dbo.Indicador", "MetaInaceptableMetaID");
            CreateIndex("dbo.Indicador", "MetaAMejorarMetaID");
            CreateIndex("dbo.Indicador", "MetaAceptableMetaID");
            CreateIndex("dbo.Indicador", "MetaSatisfactoriaMetaID");
            CreateIndex("dbo.Indicador", "MetaExcelenteMetaID");
            AddForeignKey("dbo.Indicador", "MetaAceptableMetaID", "dbo.Meta", "MetaId");
            AddForeignKey("dbo.Indicador", "MetaAMejorarMetaID", "dbo.Meta", "MetaId");
            AddForeignKey("dbo.Indicador", "MetaExcelenteMetaID", "dbo.Meta", "MetaId");
            AddForeignKey("dbo.Indicador", "MetaInaceptableMetaID", "dbo.Meta", "MetaId");
            AddForeignKey("dbo.Indicador", "MetaSatisfactoriaMetaID", "dbo.Meta", "MetaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Indicador", "MetaSatisfactoriaMetaID", "dbo.Meta");
            DropForeignKey("dbo.Indicador", "MetaInaceptableMetaID", "dbo.Meta");
            DropForeignKey("dbo.Indicador", "MetaExcelenteMetaID", "dbo.Meta");
            DropForeignKey("dbo.Indicador", "MetaAMejorarMetaID", "dbo.Meta");
            DropForeignKey("dbo.Indicador", "MetaAceptableMetaID", "dbo.Meta");
            DropIndex("dbo.Indicador", new[] { "MetaExcelenteMetaID" });
            DropIndex("dbo.Indicador", new[] { "MetaSatisfactoriaMetaID" });
            DropIndex("dbo.Indicador", new[] { "MetaAceptableMetaID" });
            DropIndex("dbo.Indicador", new[] { "MetaAMejorarMetaID" });
            DropIndex("dbo.Indicador", new[] { "MetaInaceptableMetaID" });
            DropColumn("dbo.Indicador", "MetaExcelenteMetaID");
            DropColumn("dbo.Indicador", "MetaSatisfactoriaMetaID");
            DropColumn("dbo.Indicador", "MetaAceptableMetaID");
            DropColumn("dbo.Indicador", "MetaAMejorarMetaID");
            DropColumn("dbo.Indicador", "MetaInaceptableMetaID");
            DropTable("dbo.Meta");
        }
    }
}
