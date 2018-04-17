namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nuevoaniotablero : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnioTablero",
                c => new
                    {
                        AnioTableroID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Anio = c.Int(nullable: false),
                        Habilitado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AnioTableroID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AnioTablero");
        }
    }
}
