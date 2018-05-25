namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seagregafechainiciovalidez : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Indicador", "FechaInicioValidez", c => c.DateTime());
            AddColumn("dbo.Indicador", "FechaFinValidez", c => c.DateTime());
            DropColumn("dbo.Indicador", "FechaValidez");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Indicador", "FechaValidez", c => c.DateTime());
            DropColumn("dbo.Indicador", "FechaFinValidez");
            DropColumn("dbo.Indicador", "FechaInicioValidez");
        }
    }
}
