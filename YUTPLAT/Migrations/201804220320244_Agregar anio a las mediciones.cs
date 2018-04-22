namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregaranioalasmediciones : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicion", "Anio", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medicion", "Anio");
        }
    }
}
