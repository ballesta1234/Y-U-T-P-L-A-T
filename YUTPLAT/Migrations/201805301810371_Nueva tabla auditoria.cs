namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nuevatablaauditoria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auditoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        TipoAuditoria = c.Int(nullable: false),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auditoria", "Usuario_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Auditoria", new[] { "Usuario_Id" });
            DropTable("dbo.Auditoria");
        }
    }
}
