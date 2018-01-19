namespace YUTPLAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndicadorNuevacolumnagrupo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Indicador", "Grupo", c => c.Long(nullable: false));
            Sql("UPDATE dbo.Indicador SET Grupo = IndicadorID");
        }

        public override void Down()
        {
            DropColumn("dbo.Indicador", "Grupo");
        }
    }
}
