namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Archivogeneradoemmedicion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicion", "ArchivoGenerado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medicion", "ArchivoGenerado");
        }
    }
}
