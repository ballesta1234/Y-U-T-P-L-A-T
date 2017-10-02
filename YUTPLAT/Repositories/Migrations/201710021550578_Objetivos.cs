namespace YUTPLAT.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Objetivos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Objetivo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        FechaCreacion = c.DateTime(),
                        UltimoUsuarioModifico = c.String(),
                        FechaUltimaModificacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Objetivo");
        }
    }
}
