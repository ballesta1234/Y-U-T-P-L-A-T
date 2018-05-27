namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seeliminaarchivogeneradomedicion : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Medicion", "ArchivoGenerado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicion", "ArchivoGenerado", c => c.Boolean(nullable: false));
        }
    }
}
