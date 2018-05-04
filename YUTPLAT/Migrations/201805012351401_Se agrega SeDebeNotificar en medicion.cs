namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeagregaSeDebeNotificarenmedicion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicion", "SeDebeNotificar", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medicion", "SeDebeNotificar");
        }
    }
}
