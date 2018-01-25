namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArchivoSQL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArchivoSQL",
                c => new
                    {
                        ArchivoSQLId = c.Int(nullable: false, identity: true),
                        NombreArchivo = c.String(),
                    })
                .PrimaryKey(t => t.ArchivoSQLId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ArchivoSQL");
        }
    }
}
